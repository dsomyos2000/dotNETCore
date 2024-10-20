using Microsoft.AspNetCore.Http;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API key missing");
            return;
        }

        if (apiKey != "YOUR_API_KEY")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid API key");
            return;
        }

        await _next(context);
    }
}
//-----
public class ApiKeyValidator : IApiKeyValidator
{
    private readonly IConfiguration _configuration;

    public ApiKeyValidator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool Validate(string apiKey)
    {
        // Retrieve the expected API key from the app settings
        var expectedApiKey = _configuration.GetValue<string>("ApiKeys:MyApiKey");

        // Compare the provided API key with the expected API key
        return apiKey == expectedApiKey;
    }
}
/-----
public interface IApiKeyValidator
{
    bool Validate(string apiKey);
}
//----
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add the ApiKeyValidator as a singleton
        services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Add the ApiKeyMiddleware to the middleware pipeline
        app.UseMiddleware<ApiKeyMiddleware>();

        // Add any additional middleware here, such as authentication middleware
    }
}

