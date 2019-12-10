
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
    [Authorize(Roles = "admin")]
    [Authorize]
    public class GroupController : ApiController
    {
        private IGroupServices _groupservices;
        public GroupController()
        {

        }
        public GroupController(IGroupServices groupservices)
        {
            _groupservices = groupservices;
        }

        
        [HttpGet]
        [Route("api/group/getgroupdetails")]
        public IHttpActionResult GetGroupList()
        {
          //  var data = "sanam";
         var data = _groupservices.ListGroup();
            //listNotice which comes from interfaces.
            return Ok(data);

        }

        [HttpPost]
        [Route("api/group/addgroup")]
        public IHttpActionResult AddGroup([FromBody]GroupViewModel m)
        {
            var result = _groupservices.AddGroup(m);
            return Ok(result);
        }


        [HttpGet]
        [Route("api/group/GetGroupById")]
        public IHttpActionResult GetGroupById(int id)
        {
            var result = _groupservices.GetGroupById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/group/updategroup")]
        public IHttpActionResult EditGroup(GroupViewModel model)
        {
            var result = _groupservices.EditGroup(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/group/DeleteGroup")]
        public IHttpActionResult DeleteGroup([FromBody] int? id)
        {
            var data = _groupservices.DeleteGroup(id ?? 0);
            return Ok(data);
        }


    }
}
