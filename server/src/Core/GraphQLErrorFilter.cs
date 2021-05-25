using HotChocolate;

namespace Logging
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Message);
        }
    }
}