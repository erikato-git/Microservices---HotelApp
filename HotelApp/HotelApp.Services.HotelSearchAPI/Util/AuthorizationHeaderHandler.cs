using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace HotelApp.Services.HotelSearchAPI.Util
{
    // Bhrugen's example.
    // DelegatingHandler centralize token access when making requests by HttpClientFactory: https://shadynagy.com/managing-authentication-tokens-http-client-factory-and-delegating-handlers/
    public class AuthorizationHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthorizationHeaderHandler(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string accessToken = await _accessor.HttpContext.GetTokenAsync("access_token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
