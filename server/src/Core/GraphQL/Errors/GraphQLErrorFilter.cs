using HotChocolate;

namespace Workshop.Core.GraphQL.Errors
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Message);
        }
    }
}