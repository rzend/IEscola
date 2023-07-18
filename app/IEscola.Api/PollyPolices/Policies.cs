using Polly;
using Polly.Retry;
using Polly.Timeout;
using Polly.Wrap;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace IEscola.Api.PollyPolices
{
    public static class Policies
    {
        private static AsyncTimeoutPolicy<HttpResponseMessage> TimeoutPolicy
        {
            get
            {
                return Policy.TimeoutAsync<HttpResponseMessage>(2, (context, timeSpan, task) =>
                {
                    Console.WriteLine($"[App|Policy]: Politica por Timeout disparada após {timeSpan.Seconds} segundos");
                    return Task.CompletedTask;
                });
            }
        }

        private static AsyncRetryPolicy<HttpResponseMessage> RetryPolicy
        {
            get
            {
                return Policy
                    .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                    .Or<TimeoutRejectedException>()
                    .WaitAndRetryAsync(new[]
                        {
                            TimeSpan.FromSeconds(1),
                            TimeSpan.FromSeconds(2),
                            TimeSpan.FromSeconds(5)
                        },
                        (delegateResult, retryCount) =>
                        {
                            Console.WriteLine($"[App|Policy]: Retentativa disparada, tentativa: {retryCount}");
                        });
            }
        }

        public static AsyncPolicyWrap<HttpResponseMessage> PolicyStrategy => Policy.WrapAsync(RetryPolicy, TimeoutPolicy);
    }
}
