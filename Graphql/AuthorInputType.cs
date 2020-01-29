using GraphQL.Types;

namespace dotnet_graphql
{
    public class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "AuthorInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<ListGraphType<BookInputType>>("books");
        }
    }
}