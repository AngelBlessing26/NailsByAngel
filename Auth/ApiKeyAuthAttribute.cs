using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NailssByAngel.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var configuration = context.HttpContext.RequestServices
                .GetService(typeof(IConfiguration)) as IConfiguration;

            var apiKey = configuration["ApiKey"];

            if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var providedKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (apiKey != providedKey)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
