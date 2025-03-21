using System;

namespace CoffeeHub.Middleware;

public class LogggingMiddleware
{
    private readonly RequestDelegate _next;

    public LogggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var authorizationHeader = context.Request.Headers["Authorization"].ToString();
        Console.WriteLine($"Authorization Header: {authorizationHeader}");

        await _next(context);
    }
}
