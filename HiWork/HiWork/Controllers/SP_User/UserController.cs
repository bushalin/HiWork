using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using HiWork.Services;
using HiWork.Models.SP_User;

namespace HiWork.Controllers
{
    
    [RoutePrefix("Api/SP_User")]
    public class UserController : ApiController
    {
        private readonly ISP_UserServices _services;
        public UserController()
        {
            _services = new SP_UserServices();
        }



        [Route("GetUserList")]
        [HttpGet]
        public IHttpActionResult GetUserList()
        {

            return Ok(_services.GetUserList().Data);
        }

        [Route("GetUserDetailsById/{userId:int}")]
        [HttpGet]
        public IHttpActionResult GetUserDetailsById(int userId)
        {
            return Ok(_services.GetUserDetailsById(userId).Data);
        }

        [Route("SaveUser")]
        [HttpPost]
        public IHttpActionResult SaveUser(User obj)
        {
            return Ok(_services.SaveUser(obj).Data);
        }

    }
}
