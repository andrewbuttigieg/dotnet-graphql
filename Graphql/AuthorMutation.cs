using GraphQL.Types;

namespace dotnet_graphql
{
    public class AuthorMutation:ObjectGraphType{
        public AuthorMutation(AuthorData authorData)
        {
            Name = "Mutation";
            Field<AuthorType>(
                "createAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> {Name = "author"}
                ),
                resolve: context =>
                {
                    var author = context.GetArgument<AuthorInputType>("author");
                    return authorData.Add(author.Name);
                }
            );
        }
    }
}