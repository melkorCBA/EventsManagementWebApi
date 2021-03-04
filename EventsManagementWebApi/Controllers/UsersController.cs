using EventDataAccess;
using EventsManagementWebApi.Domain.Services;
using EventsManagementWebApi.Extentions;
using EventsManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace EventsManagementWebApi.Controllers
{
    
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("api/users/register")]
        public async Task<IHttpActionResult> PostRegister(UserRegister userRegisterModel)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, ModelState.GetErrorMessages());
            
            var registerResponse = await _userService.RegisterAsync(userRegisterModel.username, userRegisterModel.fullName, userRegisterModel.password);
            if(!registerResponse.Success)
            {
                
                return Content(HttpStatusCode.InternalServerError, registerResponse.Message);
            }


            // login new user
            var loginResponse = await _userService.LoginAsync(userRegisterModel.username, userRegisterModel.password);


            if (!loginResponse.Success)
            {
                return Content(HttpStatusCode.InternalServerError, loginResponse.Message);
            }

            return Content(HttpStatusCode.OK, loginResponse);

            
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("api/users/Login")]
        public async Task<IHttpActionResult> PostLogin(UserLogin userLoginModel)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, ModelState.GetErrorMessages());

            var loginResponse = await _userService.LoginAsync(userLoginModel.Username, userLoginModel.Password);

            if (!loginResponse.Success)
            {
                return Content(HttpStatusCode.InternalServerError, loginResponse.Message);
            }

            return Content(HttpStatusCode.OK, loginResponse);

               
        }

            public IEnumerable<User> Get()
        {
            using (eventMangerEntities entities = new eventMangerEntities())
            {
                var test = entities.Users.ToList();
                return test;
            }
        }


    }
}
