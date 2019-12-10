
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
    public class GeneralLedgerController : ApiController
    {
        private IGeneralLedgerServices _generalledgerservices;
        public GeneralLedgerController()
        {

        }
        public GeneralLedgerController(IGeneralLedgerServices generalledgerservices)
        {
            _generalledgerservices = generalledgerservices;
        }


        [HttpGet]
        [Route("api/gl/getgldetails")]
        public IHttpActionResult GetGLList()
        {
          //  var data = "sanam";
         var data = _generalledgerservices.ListGL();
            //listNotice which comes from interfaces.
            return Ok(data);

        }

        [HttpPost]
        [Route("api/gl/addgl")]
        public IHttpActionResult AddGL([FromBody]GLViewModel m)
        {
            var result = _generalledgerservices.AddGL(m);
            return Ok(result);
        }


        //[HttpGet]
        //[Route("api/group/GetGroupById")]
        //public IHttpActionResult GetGroupById(int id)
        //{
        //    var result = _itemservices.GetGroupById(id);
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Route("api/group/updategroup")]
        //public IHttpActionResult EditGroup(GroupViewModel model)
        //{
        //    var result = _itemservices.EditGroup(model);
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Route("api/group/DeleteGroup")]
        //public IHttpActionResult DeleteGroup([FromBody] int? id)
        //{
        //    var data = _itemservices.DeleteGroup(id ?? 0);
        //    return Ok(data);
        //}


    }
}
