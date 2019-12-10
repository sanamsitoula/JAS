
using JAS.Services;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JAS.Controllers
{
    [Authorize]
    public class ReportController : ApiController
    {
        private IReportServices _reportservices;
        public ReportController()
        {

        }
        public ReportController(IReportServices reportservices)
        {
            _reportservices = reportservices;
        }


        [HttpPost]
        [Route("api/report/getGLdetails")]
        public IHttpActionResult GetGLList([FromBody]SearchViewModel m)
        {
          //  var data = "sanam";
         var data = _reportservices.ListGledger(m);
            //listNotice which comes from interfaces.
            return Ok(data);

        }


    





      

     



      


     

    }
}
