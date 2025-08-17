using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.DotNetV8.Controllers.Attributes
{
    public class CustomAuthFilter : AuthorizeFilter
    {
        //public CustomAuthFilter(IConfiguration configuration, AuthorizationPolicy policy) : base(policy)
        //{
        //    Configuration = configuration;
        //}

        //public static IConfiguration Configuration { get; set; }

        //public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        //{
        //    ClaimsIdentity id2 = context.HttpContext.User.Identity as ClaimsIdentity;

        //    var routeData = context.HttpContext.GetRouteData();
        //    var actionName = routeData?.Values["action"]?.ToString();
        //    var action = string.IsNullOrWhiteSpace(actionName) ? string.Empty : actionName;

        //    if(action=="FhirCallback")
        //    {
        //        return base.OnAuthorizationAsync(context);
        //    }
        //    if (string.IsNullOrEmpty(id2.Name))
        //    {
        //        var serviceAccount = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "ServiceAccount").Value.FirstOrDefault();
        //        if(serviceAccount != null)
        //        {
        //            id2.AddClaim(new Claim("API_ServiceAccount", serviceAccount?.ToUpper(), ClaimValueTypes.String));
        //        }
        //        var claims = id2.Claims;
        //        string username = claims.FirstOrDefault(x => x.Type == "aud").Value + "\\" + claims.FirstOrDefault(x => x.Type == "subject").Value;

        //        id2.AddClaim(new Claim("hhtp://schemas.xmlsoap.org", username.ToUpper(), ClaimValueTypes.String));
        //    }
        //    return base.OnAuthorizationAsync(context);
        //}
    }
}
