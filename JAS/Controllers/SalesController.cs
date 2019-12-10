
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
    public class SalesController : ApiController
    {
        private ISalesServices _saleservices;
        public SalesController()
        {

        }
        public SalesController(ISalesServices saleservices)
        {
            _saleservices = saleservices;
        }


        [HttpGet]
        [Route("api/sale/getsaledetails")]
        public IHttpActionResult GetSaleList()
        {
          //  var data = "sanam";
         var data = _saleservices.ListSale();
            //listNotice which comes from interfaces.
            return Ok(data);

        }


        [HttpGet]
        [Route("api/sale/getChartTopItemSale")]
        public IHttpActionResult getChartTopItemSale()
        {
            //  var data = "sanam";
            var data = _saleservices.getChartTopItemSaleList();
            //listNotice which comes from interfaces.
            return Ok(data);

        }



        [HttpPost]
        [Route("api/sale/addsale")]
        public IHttpActionResult AddSale(List<SalesViewModel> m)
        {
            var result = _saleservices.AddSale(m);
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
