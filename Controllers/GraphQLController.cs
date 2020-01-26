using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_graphql{
    [Route("graphql")]
  [ApiController]
  public class GraphQLController : Controller
  {
        private AuthorData authorData;

        //private readonly ApplicationDbContext _db;

        //public GraphQLController(ApplicationDbContext db) => _db = db;
        public GraphQLController(AuthorData authorData) => this.authorData = authorData;

    public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
    {
      var inputs = query.Variables.ToInputs();

      var schema = new Schema
      {
        Query = new AuthorQuery(authorData)
      };

      var result = await new DocumentExecuter().ExecuteAsync(_ =>
      {
        _.Schema = schema;
        _.Query = query.Query;
        _.OperationName = query.OperationName;
        _.Inputs = inputs;
      });

      if(result.Errors?.Count > 0)
      {
        //return BadRequest();
        return Ok(result.Errors);
      }

      return Ok(result);
      }
  }
}