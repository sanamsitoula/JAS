
using JAS.Services;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace JAS.Controllers
{
    [Authorize(Roles = "admin")]
    [Authorize]
    public class ItemController : ApiController
    {
        private IItemServices _itemservices;
        public ItemController()
        {

        }
        public ItemController(IItemServices itemservices)
        {
            _itemservices = itemservices;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/item/getitemdetails")]
        public IHttpActionResult GetItemList()
        {
          //  var data = "sanam";
         var data = _itemservices.ListItem();
            //listNotice which comes from interfaces.
            return Ok(data);

        }

        [HttpPost]
        [Route("api/item/additem")]
        public IHttpActionResult AddItem()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            int uploadCount = 0;
            string sPath = System.Web.Hosting.HostingEnvironment.MapPath("/Client/Resources/uploads/items/");
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                System.Web.HttpPostedFile file = files[i];
                string fileName = new FileInfo(file.FileName).Name;
                if(file.ContentLength>0)
                {
                    Guid id = Guid.NewGuid();
                    string modifiedFileName = id.ToString() + "_" + fileName;

                    if(!File.Exists(sPath + Path.GetFileName(modifiedFileName))){

                        file.SaveAs(sPath + Path.GetFileName(modifiedFileName));
                        uploadCount++;

                        ItemViewModel ivm = new ItemViewModel();
                        ivm.item_name = HttpContext.Current.Request.Form["item_name"];
                        ivm.item_code = HttpContext.Current.Request.Form["item_code"];

                        ivm.item_description = HttpContext.Current.Request.Form["item_description"];
                        ivm.photo = modifiedFileName;
                        ivm.group_id = Convert.ToInt32( HttpContext.Current.Request.Form["group_id"]);
                        ivm.item_cp = Convert.ToInt32(HttpContext.Current.Request.Form["item_cp"]);
                        ivm.item_sp = Convert.ToInt32(HttpContext.Current.Request.Form["item_sp"]);
                        ivm.item_unit = HttpContext.Current.Request.Form["item_unit"];
                        ivm.item_quantity = Convert.ToInt32(HttpContext.Current.Request.Form["item_quantity"]);

                        
                        var result = _itemservices.AddItem(ivm);
                    
                    }
                }
            }
            if (uploadCount > 0)
            {
                return Ok("Sucessfull");

            }

            return Ok();
          //  return InternalServerError();


        }



        [HttpGet]
        [Route("api/item/GetItemById")]
        public IHttpActionResult GetItemById(int id)
        {
            var result = _itemservices.GetItemById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/item/updateitem")]
        public IHttpActionResult EditItem(ItemViewModel model)
        {
            var result = _itemservices.EditItem(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/item/DeleteItem")]
        public IHttpActionResult DeleteItem([FromBody] int? id)
        {
            var data = _itemservices.DeleteItem(id ?? 0);
            return Ok(data);
        }


    }
}
