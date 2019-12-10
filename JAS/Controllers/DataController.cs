using JAS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace JAS.Controllers
{
    public class DataController : ApiController
    {

        private IRoleServices _roleservices;

        public DataController()
        {

        }
        public DataController(IRoleServices roleservices)
        {
            _roleservices = roleservices;
        }


       // [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var email = prinicpal.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            var result = "Hello " + identity.Name + " Email: " + email + " Role: " + string.Join(",", roles.ToList());
            var role = roles.ToList();
            var data = new { name = identity.Name, details = result, role_name= role };
            return Ok(data);
        }


       // [Authorize(Roles = "customers")]
        [HttpGet]
        [Route("api/data/customerdata")]
        public IHttpActionResult GetForUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var email = prinicpal.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
            var result = "Hello " + identity.Name + " Email: " + email + " Role: " + string.Join(",", roles.ToList());
            var role = roles.ToList();
            var data = new { name = identity.Name, details = result, role_name = role };
            return Ok(data);
        }


    }
}
