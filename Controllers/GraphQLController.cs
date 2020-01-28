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
        private ISchema schema;

        //private readonly ApplicationDbContext _db;

        //public GraphQLController(ApplicationDbContext db) => _db = db;
        public GraphQLController(AuthorData authorData, ISchema schema){
            this.authorData = authorData;
            this.schema = schema;
        }

    public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
    {
      var inputs = query.Variables.ToInputs();

    //   var schema = new Schema
    //   {
    //     Query = new AuthorQuery(authorData),
    //     Mutation = new AuthorMutation(authorData)
    //   };

      var result = await new DocumentExecuter().ExecuteAsync(_ =>
      {
        _.Schema = this.schema;
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