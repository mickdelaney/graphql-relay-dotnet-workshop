using HotChocolate;

namespace Workshop.Core
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Message);
        }
    }
}