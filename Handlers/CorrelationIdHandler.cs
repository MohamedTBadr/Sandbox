using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Sandbox.Handlers
{
    public class CorrelationIdHandler:DelegatingHandler
    {
        private const string HeaderName = "X-Correlation-ID";
        protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            string correlationId;

            if (request.Headers.TryGetValues(
                HeaderName,
                out var values))
            {
                correlationId = values.FirstOrDefault();
            }
            else
            {
                correlationId = null;
            }

            if (string.IsNullOrWhiteSpace(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
            }

            request.Properties[HeaderName] = correlationId;

            var response = await base.SendAsync(
                request,
                cancellationToken);

            //remove the header if it already exists and add the correlation ID to the response headers
            response.Headers.Remove(HeaderName);
            response.Headers.Add(HeaderName, correlationId);

            return response;
        }
    }
}