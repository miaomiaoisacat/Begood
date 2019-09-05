using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace BeGood.Api.Filters
{
    public class CusAuthorizeFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

        }
    }
}
