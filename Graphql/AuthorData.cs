using System.Collections.Generic;

namespace dotnet_graphql
{
    public class AuthorData{
        public readonly List<Author> authors = new List<Author>();

        public AuthorData()
        {
            authors.Add(new Author(){
                Id = 1,
                Name = "Andrew Buttigieg"
            });
        }
    }
}