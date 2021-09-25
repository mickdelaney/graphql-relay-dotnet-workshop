using System.Threading;
using System.Threading.Tasks;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Http;

namespace Workshop.Gateway
{
    public class RequestInterceptor : DefaultHttpRequestInterceptor
    {
        public ValueTask OnCreateAsync
        (
            HttpContext context,
            IRequestExecutor requestExecutor,
            IQueryRequestBuilder requestBuilder,
            CancellationToken cancellationToken
        )
        {
            
            return base.OnCreateAsync
            (
                context, requestExecutor, requestBuilder, cancellationToken
            );
        }
    }
}