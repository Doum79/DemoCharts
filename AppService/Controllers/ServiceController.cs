using AppService.Models;
using AppService.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace AppService.Controllers
{
    [RoutePrefix("api/Balance")]
    class ServiceController : ApiController
    {

        public readonly IServiceDictionnary _serviceDictionary;
        public ServiceController(IServiceDictionnary balanceDictionary)
        {

            _serviceDictionary = balanceDictionary;
        }

        [Route("{id}")]
    [HttpGet]
    // GET: api/Balance/customerId
    public JsonResult<Ressources> Get(string id)
    {
        var errString = "The client does not exist. Please retry with a valid client id.";
        var balance = ServiceDictionary.AppService;
        try
        {
            var client = new Ressources
            {
                //CPU = id,
                //Memory = ,
                //Message = "SUCCESS!"
            };

            return Json(client); // return ClientBalance Object
        }
        catch (Exception ex)
        {
            return Json(new Ressources
            {
                //CPU = id,
                //Memory = null,
                //Message = "FAILURE! " + errString + " " + ex.Message
            }); // return ClientBalance Object
        }
    }
}
    }

