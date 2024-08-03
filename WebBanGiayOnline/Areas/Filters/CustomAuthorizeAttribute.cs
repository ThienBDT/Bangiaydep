using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanGiayOnline.Areas.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // Người dùng đã đăng nhập nhưng không có quyền truy cập
                filterContext.Result = new ViewResult
                {
                    ViewName = "Unauthorized"
                };
            }
            else
            {
                // Người dùng chưa đăng nhập
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}