using System.Collections.Generic;
using System.Linq;

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
            authors.Add(new Author(){
                Id = 2,
                Name = "Mark Twain"
            });
            authors.Add(new Author(){
                Id = 3,
                Name = "Ernest Hemingway"
            });
            authors.Add(new Author(){
                Id = 4,
                Name = "Jane Austen"
            });
        }

        public Author Add(string name)
        {
            authors.Add(new Author(){
                Name = name,
                Id = authors.Count() + 1
            });

            return authors.Last();
        }
    }
}