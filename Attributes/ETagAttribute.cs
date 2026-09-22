using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Sandbox.Attributes
{
    public class ETagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(
            HttpActionContext actionContext)
        {
            var ifMatch = actionContext.Request.Headers.IfMatch;

            if (ifMatch == null || ifMatch.Count == 0)
            {
                actionContext.Response =
                    actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        "If-Match header is required.");

                return;
            }

            var etagHeader = ifMatch.FirstOrDefault();

            var etag = etagHeader.Tag;

            try
            {
                var rowVersion = Convert.FromBase64String(etag);

                actionContext.Request.Properties["RowVersion"] = rowVersion;
            }
            catch (FormatException)
            {
                actionContext.Response =
                    actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest,
                        "Invalid ETag.");

                return;
            }

            base.OnActionExecuting(actionContext);
        }



    }
}