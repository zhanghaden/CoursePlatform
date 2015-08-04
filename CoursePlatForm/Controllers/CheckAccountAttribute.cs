using CommonClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursePlatForm.Controllers
{
    public class CheckAccountAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool Pass = false;
            if (TakeCookie.GetCookie("userId") == null)//如果没有cookie，则未登陆
            {

                httpContext.Response.StatusCode = 401;//无权限状态码  
                Pass = false;
            }
            else
            {
                if (TakeCookie.GetCookie("userRole") != null)
                {
                    if (Roles.Contains(TakeCookie.GetCookie("userRole")))
                        Pass = true;
                    else
                    {
                        httpContext.Response.StatusCode = 401;//无权限状态码  
                        Pass = false;
                    }
                }
                else
                {
                    Pass = false;
                }
            }

            return Pass;
        }


        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else
            {
                //string path = context.HttpContext.Request.Path;
                string strUrl = "/SoftDown/index";

                context.HttpContext.Response.Redirect(strUrl, true);

            }

        }
    }
}