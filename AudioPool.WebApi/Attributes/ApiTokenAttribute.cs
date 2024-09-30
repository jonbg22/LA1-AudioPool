using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AudioPool.WebApi.Attributes;

public class ApiTokenAttribute : Attribute, IAuthorizationFilter
{
    private const string ApiTokenHeader = "api-token";
    private const string ValidApiToken = "YourHardCodedApiToken";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiTokenHeader, out var extractedApiToken))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!string.Equals(extractedApiToken, ValidApiToken, StringComparison.Ordinal))
            context.Result = new UnauthorizedResult();
    }
}