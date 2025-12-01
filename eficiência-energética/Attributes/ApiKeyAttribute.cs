using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eficiência_energética.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string API_KEY_HEADER = "X-Api-Key";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // 1. Retrieve the IConfiguration service from the DI container
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            
            // 2. Get the configured API Key
            var apiKey = configuration.GetValue<string>("ApiKey");

            // 3. Check if the header is present
            if (!context.HttpContext.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "API Key was not provided."
                };
                return;
            }

            // 4. Validate the key
            if (!string.Equals(apiKey, extractedApiKey, StringComparison.OrdinalIgnoreCase)) // Basic comparison
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Unauthorized client."
                };
                return;
            }

            await next();
        }
    }
}
