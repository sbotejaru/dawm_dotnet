using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    /* [ApiController]
     [Route("api/home")]
     public class HomeController : ControllerBase
     {


         [HttpGet("example-get")]
         public ActionResult<string> Get()
         {
             return Ok("This is a simple example for [GET] http://localhost5000/api/home/example-get");
         }

         [HttpGet("example-get-route-data")]
         public ActionResult<string> GetWith_RouteParameter([FromRoute] int data)
         {
             return Ok($"This is a simple example for [GET] http://localhost5000/api/home/example-get/{data}");
         }

         [HttpGet("example-get-queryparam-data")]
         public ActionResult<string> GetWith_QueryParameter([FromQuery] int data)
         {
             return Ok($"This is a simple example for [GET] http://localhost5000/api/home/example-get/?data={data}");
         }

         [HttpPost("example-post-simple")]
         public ActionResult<string> Post([FromBody] int data)
         {
            *//*
             * Request body can be:
             * 123
             *//*

             var result = $"This is a simple example for [POST] http://localhost5000/api/home/example-post\n";
             result += $"Data is: {data}";

             return Ok(result);
         }

         [HttpPost("example-post-json")]
         public ActionResult<string> Post_Json([FromBody] Payload payload)
         {
             *//*
              * Request body can be:
              * { "data" : 123 }
              *//*

             var result = $"This is a simple example for [POST] http://localhost5000/api/home/example-post\n";
             result += $"Data is: {payload?.Data}";

             return Ok(result);


     } }*/

    /*public class Payload
    {
        public int Data { get; set; }
    }*/
}
