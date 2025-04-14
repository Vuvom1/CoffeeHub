using System;
using System.Net.Http.Headers;
using System.Text;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffeeHub.Services.Implementations;

public class GeminiService
{
    private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore
    };
    private readonly string _apiUrl;
    private readonly string _accessToken;
    private readonly IMenuItemService _menuItemService;
    private readonly IMenuItemCategoryService _menuItemCategoryService;

    public GeminiService(IConfiguration configuration, IMenuItemService menuItemService, IMenuItemCategoryService menuItemCategoryService)
    {
        _apiUrl = configuration["GeminiService:ApiUrl"] ?? throw new ArgumentNullException(nameof(configuration), "ApiUrl cannot be null");
        _accessToken = configuration["GeminiService:AccessToken"] ?? throw new ArgumentNullException(nameof(configuration), "AccessToken cannot be null");
        _menuItemService = menuItemService ?? throw new ArgumentNullException(nameof(menuItemService), "MenuItemService cannot be null");
        _menuItemCategoryService = menuItemCategoryService ?? throw new ArgumentNullException(nameof(menuItemCategoryService), "MenuItemCategoryService cannot be null");

    }

    public async Task<string> ResponseUserInput([FromBody] string request)
    {
        string prompt = request;
        string functionsJson;
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "configurations", "Functions.json");
        if (File.Exists(filePath))
        {
            functionsJson = File.ReadAllText(filePath);
        }
        else
        {
            return "Configuration file not found.";
        }

        // Send prompt and function schema to Gemini API
        string geminiResponse = await ProcessPromptAsync(prompt, functionsJson);

        // Parse Gemini's response
        var response = JsonConvert.DeserializeObject<dynamic>(geminiResponse);

        var responseParts = response?.candidates?[0]?.content?.parts;

        if (responseParts == null || (responseParts is Array array && array.Length == 0))
        {
            return "No response found.";
        }

        if (responseParts != null && responseParts![0].text != null)
        {
            return responseParts![0].text ?? "No text found in response parts.";
        }

        // Extract the function name and parameters from Gemini's output
        var functionCall = responseParts![0].functionCall;
        string functionName = functionCall.name;
        var parameters = functionCall.args;

        if (functionName == null)
        {
            return "No function found.";
        }

        // Execute the recommended function
        var functionResult = await ExecuteFunctionAsync(functionName, parameters);

        // Refine the response with Gemini
        string refinementPrompt = $@"
                You provided the following response earlier:'{functionResult}'.

                Please improve this response by:
                1. Simplifying the language to make it more customer-friendly and approachable.
                2. Highlighting specific actions the customer can take based on the information provided.
                3. Ensuring the response remains concise and polite, while adding only relevant details that enrich the customer experience.
                4. Maintaining a warm, professional tone without unnecessary meta-language or explanations.
                5. Avoiding technical jargon or overly complex language that may confuse the customer.
                6. Ensuring the response is tailored to the user's intent and provides clear, actionable information.
                7. Ending the response with a question or prompt that encourages further engagement or action.
                8. Reviewing the response for spelling, grammar, and punctuation to maintain a professional appearance.
                9. Ensuring the response aligns with the brand's voice and values to provide a consistent customer experience.
                10. Avoiding provide information about how the response was generated or any internal processes and focusing solely on the customer's needs.";

        // // Refine the response with Gemini
        string naturalLanguageResponse = await RefineResponseWithGeminiAsync(refinementPrompt);

        // Extract the refined response from Gemini's output
        var deserializedResponse = JsonConvert.DeserializeObject<dynamic>(naturalLanguageResponse);
        if (deserializedResponse?.candidates?[0]?.content?.parts?[0]?.text == null)
        {
            return "No refined response found.";
        }
        var refinedResponse = deserializedResponse.candidates[0].content.parts[0].text;

        // Return the refined response
        return refinedResponse;
    }

    public async Task<string> ProcessPromptAsync(string prompt, string functionsJson)
    {
        using (var httpClient = new HttpClient())
        {
            var payload = new
            {
                system_instruction = new
                {
                    parts = new
                    {
                        text = "You are a helpful assistant for a coffee website. You can provide information about coffee products, take orders, and answer customer queries. "
                             + "Here is some static information about the store: "
                             + "The store is located at 123 Coffee Street, Coffee City. "
                             + "Store hours are Monday to Friday, 8 AM to 8 PM, and Saturday to Sunday, 9 AM to 6 PM. "
                             + "You can contact the store at (123) 456-7890 or email support@coffeehub.com. "
                             + "Do not perform any other tasks."
                    }
                },
                tools = JsonConvert.DeserializeObject(functionsJson),
                tool_config = new
                {
                    function_calling_config = new
                    {
                        mode = "auto"
                    }
                },
                contents = new
                {
                    role = "user",
                    parts = new
                    {
                        text = prompt
                    }
                }
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            int retryCount = 10;
            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    var response = await httpClient.PostAsync(_apiUrl + "?key=" + _accessToken, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
                    {
                        // Wait before retrying
                        await Task.Delay(3000);
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
                    }
                }
                catch (HttpRequestException ex) when (i < retryCount - 1)
                {
                    // Log the exception and retry
                    Console.WriteLine($"Retrying due to: {ex.Message}");
                    await Task.Delay(3000);
                }
            }

            throw new HttpRequestException("Gemini API Request Failed after multiple retries.");
        }
    }

    public async Task<string> RefineResponseWithGeminiAsync(string functionResultJson)
    {
        using (var httpClient = new HttpClient())
        {

            // Construct the prompt
            string prompt = $@"
                You are a data assistant that turns JSON data into conversational responses. 
                Examples of how you should interpret data:

                Input:
                {{
                    ""items"": [""Latte"", ""Espresso"", ""Cappuccino""]
                }}
                Response:
                The top coffee items are Latte, Espresso, and Cappuccino. Would you like to add one of these to your order?

                Input:
                {{
                    ""name"": ""Latte"",
                    ""description"": ""A creamy coffee beverage made with steamed milk."",
                    ""price"": 4.50
                }}
                Response:
                    Latte is a creamy coffee beverage made with steamed milk. It costs $4.50. Would you like me to add this to your order?

                    Now process the following JSON and provide a polite, actionable response:
                    \n\n{functionResultJson}";


            var payload = new
            {
                system_instruction = new
                {
                    parts = new
                    {
                        text = "You are a conversational assistant for data interpretation. Your role is to analyze structured data in JSON format and provide specific, actionable responses tailored to the user's intent. Avoid generic summaries and instead recommend useful next steps or clarify the data's purpose."
                    }
                },
                contents = new[]
                {
                new
                {
                    role = "user",
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            var response = await httpClient.PostAsync(_apiUrl + "?key=" + _accessToken, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"Gemini API Request Failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
        }
    }

    public async Task<string> ClearContextAsync()
    {
        using (var httpClient = new HttpClient())
        {
            var payload = new
            {
                system_instruction = new
                {
                    parts = new
                    {
                        text = "Clear the context and start a new conversation."
                    }
                }
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            var response = await httpClient.PostAsync(_apiUrl + "?key=" + _accessToken, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"Gemini API Request Failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
        }
    }

    private async Task<string> ExecuteFunctionAsync(string functionName, dynamic parameters)
    {
        switch (functionName)
        {
            case "GetPopularMenuItems":
                int topCount = parameters.topCount;
                var popularMenuItems = await _menuItemService.GetPopularMenuItemsAsync(topCount);
                return JsonConvert.SerializeObject(popularMenuItems.ToList(), new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            case "GetMenuItemDetails":          
                string menuItemName = parameters.name;
                var menuItemDetails = await GetMenuItemDetails(menuItemName);
                return menuItemDetails;
            case "SuggestMenuItemsWithPreferences":
                string preferences = parameters.preferences;

                var suggestedMenuItems = await _menuItemService.GetAllAsync();
                if (preferences != null)
                {
                    suggestedMenuItems = suggestedMenuItems.Where(item => item.Name.Contains(preferences, StringComparison.OrdinalIgnoreCase)
                    || item.Description.Contains(preferences, StringComparison.OrdinalIgnoreCase));
                }
                return JsonConvert.SerializeObject(suggestedMenuItems.ToList(), _jsonSerializerSettings);
            case "RetrieveMenuItemsByCategory":
                string category = parameters.category;
                var menuItemsByCategory = await _menuItemCategoryService.GetByNameWithMenuItemsAsync(category);
                return JsonConvert.SerializeObject(menuItemsByCategory.MenuItems.ToList(), _jsonSerializerSettings);
            case "GetNewestMenuItems":
                int newestTopCount = parameters.topCount;
                var newestMenuItems = await _menuItemService.GetNewestMenuItemsAsync(newestTopCount);
                return JsonConvert.SerializeObject(newestMenuItems.ToList(), _jsonSerializerSettings);
            case "RecommendBudgetFriendlyMenuItems":
                var budget = parameters.budget;
                var budgetFriendlyMenuItems = await GetRecommendBudgetFriendlyMenuItems(budget);

                return budgetFriendlyMenuItems;
            default:
                throw new Exception($"Function '{functionName}' not implemented.");
        }
    }

    private async Task<string> GetRecommendBudgetFriendlyMenuItems(dynamic budget)
    {
        var budgetFriendlyMenuItems = await _menuItemService.GetAllAsync();

        budgetFriendlyMenuItems = budgetFriendlyMenuItems.Where(item => item.Price <= (decimal)budget);

        return JsonConvert.SerializeObject(budgetFriendlyMenuItems.ToList(), _jsonSerializerSettings);
    }

    private async Task<string> GetMenuItemDetails(string name)
    {
        var menuItem = await _menuItemService.GetByNameAsync(name);
        if (menuItem == null)
        {
            var menuItems = await _menuItemService.GetAllAsync();
            var similarMenuItems = menuItems.Where(item => item.Name.Contains(name, StringComparison.OrdinalIgnoreCase) || item.Description.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (similarMenuItems.Any())
            {
                return JsonConvert.SerializeObject(new {message = $"There is no menu items name '{name}'",
                    similarMenuItems = similarMenuItems.ToList()
                }, _jsonSerializerSettings);
            }
            else
            {
                return JsonConvert.SerializeObject(new { message = "No similar menu items found" }, _jsonSerializerSettings);
            }
        }

        if (menuItem.IsAvailable == false)
        {
            return JsonConvert.SerializeObject(new { message = "This menu item is no longer in sale" }, _jsonSerializerSettings);
        }

        return JsonConvert.SerializeObject(menuItem, _jsonSerializerSettings);
    }

}
