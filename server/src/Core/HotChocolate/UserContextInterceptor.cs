using System.Threading;
using System.Threading.Tasks;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Http;

namespace Workshop.Core.HotChocolate
{
    public class UserContextInterceptor : DefaultHttpRequestInterceptor
    {
        public override ValueTask OnCreateAsync
        (
            HttpContext context,
            IRequestExecutor requestExecutor,
            IQueryRequestBuilder requestBuilder,
            CancellationToken cancellationToken
        )
        {
            requestBuilder.SetProperty("User", context.User);
            
            return base.OnCreateAsync
            (
                context, requestExecutor, requestBuilder, cancellationToken
            );
        }
    }
}