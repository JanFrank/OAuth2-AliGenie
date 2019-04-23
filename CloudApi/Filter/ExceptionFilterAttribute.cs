using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using CloudApi.ToolHelper;
namespace CloudApi.Filter
{
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            CloudApi.ToolHelper.FunctionHelper.writeLog("", actionExecutedContext.Exception.GetType().ToString() + "：" + actionExecutedContext.Exception.Message + "——堆栈信息：" +
                actionExecutedContext.Exception.StackTrace, "error");
        }
    }
}