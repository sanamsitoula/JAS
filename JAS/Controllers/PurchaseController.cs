
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
    public class PurchaseController : ApiController
    {
        private IPurchaseServices _purchaseservices;
        public PurchaseController()
        {

        }
        public PurchaseController(IPurchaseServices purchaseservices)
        {
            _purchaseservices = purchaseservices;
        }


        [HttpPost]
        [Route("api/item/getpurchasedetails")]
        public IHttpActionResult GetPurchaseList([FromBody]SearchViewModel m)
        {
          //  var data = "sanam";
         var data = _purchaseservices.ListPurchase(m);
            //listNotice which comes from interfaces.
            return Ok(data);

        }


        //[HttpPost]
        //[Route("api/item/getFilterPurchaseData")]
        //public IHttpActionResult getFilterPurchaseData(SearchViewModel m)
        //{
        //    //  var data = "sanam";
        //    var data = _purchaseservices.ListPurchaseFromSearch(m);
        //    //listNotice which comes from interfaces.
        //    return Ok(data);

        //}





        [HttpGet]
        [Route("api/purchase/getChartTopItemPurchase")]
        public IHttpActionResult getChartTopItemPurchase()
        {
            //  var data = "sanam";
            var data = _purchaseservices.getChartTopItemPurchaseList();
            //listNotice which comes from interfaces.
            return Ok(data);

        }

        [HttpGet]
        [Route("api/purchase/getChartItemSalePurchase")]
        public IHttpActionResult getChartItemSalePurchase()
        {
            //  var data = "sanam";
            var data = _purchaseservices.getChartItemSalePurchaseList();
            //listNotice which comes from interfaces.
            return Ok(data);

        }

        [HttpPost]
        [Route("api/purchase/addpurchase")]
        public IHttpActionResult AddPurchase(List<PurchaseViewModel> m)
        {
            var result = _purchaseservices.AddPurchase(m);
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
