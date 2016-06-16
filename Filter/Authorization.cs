using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace J7.Filter
{
    public class AuthorizationCheck : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData["User"] != null)
            {
                //UserDetail user = filterContext.Controller.ViewData["CurrentUser"] as UserDetail;
                var isLocked = true;
                //冻结用户组判断
                if (isLocked)
                {
                    string requestRawUrl = filterContext.HttpContext.Request.RawUrl.ToLower();
                    if (requestRawUrl.IndexOf("?") >= 0) //
                    {
                        requestRawUrl = requestRawUrl.Substring(0, requestRawUrl.IndexOf("?"));
                    }
                    switch (requestRawUrl)
                    {
                        //不需要冻结用户组检测的页面
                        case "/member/helper":
                            //todo something...
                            break;
                        default:
                            if (requestRawUrl.StartsWith("/ajax/"))
                            {
                                //filterContext.Result = Utilities.GetJsonResponseContent(new Error(200, "freeze", "您的账号已经被冻结"));
                            }
                            else
                            {
                                filterContext.HttpContext.Response.Redirect("/member/unfreeze");
                                filterContext.HttpContext.Response.End();
                            }
                            break;
                    }
                }
            }
        }

    }
}
