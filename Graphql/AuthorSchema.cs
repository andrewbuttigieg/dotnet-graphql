using GraphQL;
using GraphQL.Types;

namespace dotnet_graphql
{
    public class AuthorSchema : Schema
    {
        public AuthorSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<AuthorQuery>();
            Mutation = resolver.Resolve<AuthorMutation>();
        }
    }
}