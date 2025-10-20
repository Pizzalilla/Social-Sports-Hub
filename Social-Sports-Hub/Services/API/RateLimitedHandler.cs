using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Social_Sport_Hub.Services.Http
{
    public sealed class RateLimitHandler : DelegatingHandler
    {
        private readonly TimeSpan _delay;
        public RateLimitHandler(TimeSpan? delay = null) { _delay = delay ?? TimeSpan.FromMilliseconds(300); }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await Task.Delay(_delay, cancellationToken);
            var resp = await base.SendAsync(request, cancellationToken);
            if ((int)resp.StatusCode == 429)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                return await base.SendAsync(request, cancellationToken);
            }
            return resp;
        }
    }
}
