using System.Linq;
using GraphQL.Types;

namespace dotnet_graphql{
    public class AuthorQuery : ObjectGraphType
  {
    public AuthorQuery(AuthorData authorData)//ApplicationDbContext db)
    {
      Field<AuthorType>(
        "Author",
        arguments: new QueryArguments(
          new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
        resolve: context =>
        {
          var id = context.GetArgument<int>("id");
        //   var author = db
        //     .Authors
        //     .Include(a => a.Books)
        //     .FirstOrDefault(i => i.Id == id);
        //   return author;
            return authorData.authors.FirstOrDefault(x => x.Id == id);
        });

      Field<ListGraphType<AuthorType>>(
        "Authors",
        resolve: context =>
        {
                        return authorData.authors;
          //var authors = db.Authors.Include(a => a.Books);
          //return authors;
        });
    }
  }
}