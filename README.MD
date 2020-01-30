# Dotnet example of a Graphql server  

## Status  
![.NET Core](https://github.com/andrewbuttigieg/dotnet-graphql/workflows/.NET%20Core/badge.svg)  
## To run  
cd to repo and run `dotnet run`  
## Mutation example  
http://localhost:5000/graphiql/?query=mutation%20createAuthor(%24author%3AAuthorInput!)%7B%0A%09createAuthor(author%3A%20%24author)%0A%20%20%7B%0A%20%20%20%20id%0A%20%20%20%20name%0A%20%20%7D%0A%7D&operationName=createAuthor&variables=%7B%0A%20%20%22author%22%3A%20%7B%0A%20%20%20%20%22name%22%3A%20%22Boba%20Fett%22%2C%0A%20%20%20%20%22book%22%3A%20%7B%22name%22%3A%20%22lala%22%7D%0A%20%20%7D%0A%7D  
 
> mutation createAuthor($author:AuthorInput!){  
	createAuthor(author: $author)  
  {  
    id  
    name  
    books {  
      id  
      name  
    }  
  }  
}  

Variables  
> {  
  "author": {  
    "name": "Boba Fett",  
    "books": [{"name": "lala", "genre":"Romance"}]  
  }  
}  

## Query example  
http://localhost:5000/graphiql/?query=%7B%0Aauthors%7B%0A%20%20id%0A%20%20name%0A%20%20books%7B%0A%20%20%20%20name%0A%20%20%20%20%0A%20%20%7D%0A%7D%7D  
