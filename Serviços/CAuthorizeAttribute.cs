using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace GerenciadorFinanca
{
    public class CAuthorizeAttribute : TypeFilterAttribute 
    {
        public CAuthorizeAttribute(string claimType, string claimValue) : base(typeof(RequisitoClaimFilter)) =>
            Arguments = new object[] { new Claim (claimType, claimValue) };  
    }

    public class RequisitoClaimFilter : IAuthorizationFilter {

        readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim){
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context) {

            var user = context.HttpContext.User as ClaimsPrincipal;

            if (user == null || !user.Identity.IsAuthenticated){

                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!user.HasClaim(_claim.Type, _claim.Value)){

                context.Result = new StatusCodeResult(403);
            }

        }


    }
}