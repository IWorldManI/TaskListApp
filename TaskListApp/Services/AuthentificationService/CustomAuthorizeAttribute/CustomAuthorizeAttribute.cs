using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TaskListApp.Services.AuthentificationService;

[AttributeUsage(AttributeTargets.Method)]
public class CustomAuthorizeAttribute : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var service = context.HttpContext.RequestServices.GetService<AuthenticationService>();
        try
        {
            service.EnsureTokenIsValid();
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}
