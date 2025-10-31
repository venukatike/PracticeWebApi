using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCore.API_ApiLayer.Attributes
{
    public class CustomActionFilter : IAuthorizationFilter, IResourceFilter,
        IActionFilter,IExceptionFilter,IResultFilter
    {
        //IAuthorizationFilter - 1 Method
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }

        //IResourceFilter - 2 Method
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            throw new NotImplementedException();
        }

        //IActionFilter - 2 Method
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }


        //IExceptionFilter - 1 Method
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }

        //IResultFilter - 2 Method
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
