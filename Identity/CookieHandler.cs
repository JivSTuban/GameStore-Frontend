using System.Net;

namespace GameStore.Frontend.Identity
{
    public class CookieHandler : DelegatingHandler
    {
        /// <summary>
        /// Main method to override for the handler.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="cancellationToken">The token to handle cancellations.</param>
        /// <returns>The <see cref="HttpResponseMessage"/>.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Handle cookies manually if needed.
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                UseCookies = true
            };

            using (var httpClient = new HttpClient(handler))
            {
                // Add the request headers.
                request.Headers.Add("X-Requested-With", new string[] { "XMLHttpRequest" });

                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}
