using JAS.DAL;
using JAS.Services;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace JAS.Controllers
{
    [System.Web.Http.Authorize]
    public class UserController : ApiController
    {
        private IUserServices _userservices;
        public UserController(IUserServices userservices)
        {
            _userservices = userservices;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/create")]
        public IHttpActionResult RegisterUser([FromBody] UserViewModel model)
        {
            var data = _userservices.UserRegistration(model);
            return Ok(data);
        }


        ////https://www.c-sharpcorner.com/article/how-to-activate-link-after-sending-email-of-activation-link-by-user-in-mvc-and-w2/
     
        [AllowAnonymous]
        [HttpGet]
        [Route("api/user/confirmemail")]
        public IHttpActionResult ConfirmRegisterEmail(string Activation_code)
        {
           

            var data = _userservices.Confirm_Registration_Mail(Activation_code);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/user/GetUserById")]
        public IHttpActionResult GetUserById(int id)
        {
            var data = _userservices.GetUserById(id);


            return Ok(data);


        }








    }
}
