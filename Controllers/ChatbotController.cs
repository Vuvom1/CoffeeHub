using CoffeeHub.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
        private readonly GeminiService _geminiService;
        private readonly FunctionService _functionService;

        public ChatbotController(GeminiService geminiService, FunctionService functionService)
        {
            _geminiService = geminiService;
            _functionService = functionService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessUserInput([FromBody] string request)
        {
            var response = await _geminiService.ResponseUserInput(request);
            
            return Ok(response);
        }

        [HttpPost("clear-context")]
        public IActionResult ClearContext()
        {
            
            return Ok("Chat context has been cleared.");
        }
    }
}
