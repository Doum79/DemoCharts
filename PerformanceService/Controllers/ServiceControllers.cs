using PerformanceService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace PerformanceService.Controllers
{

    [RoutePrefix("api/testing")]
    class ServiceControllers : ApiController
    {
        [Route("{id}")]
        [HttpGet]
        // GET: api/Balance/customerId
        public JsonResult<string> Get(string id)
        {
            var errString = "The client does not exist. Please retry with a valid client id.";

           
            
            return Json(id); /*return ClientBalance Object*/
           
           
        }
    }
}
