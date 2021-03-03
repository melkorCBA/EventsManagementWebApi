using EventDataAccess;
using EventsManagementWebApi.Extentions;
using EventsManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace EventsManagementWebApi.Controllers
{
    
    public class UsersController : ApiController
    {
        
        
        
        [HttpPost]
        [AllowAnonymous]
        [Route("api/users/register")]
        public IHttpActionResult PostRegister(UserRegister userRegisterModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            ObjectParameter signUpResponseMessage= new ObjectParameter("responseMessage", "" );
            ObjectParameter signInResponseMessage = new ObjectParameter("responseMessage", "");
            ObjectParameter signUpStatus= new ObjectParameter("Status", 0);
            ObjectParameter signInStatus = new ObjectParameter("Status", 0);
            ObjectParameter UserId = null;
            using (eventMangerEntities entities = new eventMangerEntities())
            {
                entities.spAddUser(userRegisterModel.username, userRegisterModel.password, userRegisterModel.fullName, signUpResponseMessage, signUpStatus);
                if(Convert.ToInt32(signUpStatus.Value) == 1)
                {
                     entities.spLogin(userRegisterModel.username, userRegisterModel.password, signInResponseMessage, UserId, signInStatus);
                    if(Convert.ToInt32(signInStatus.Value) == 1) { 
                        return Ok((int)UserId.Value); 
                    }
                    else
                    {
                        return Content(HttpStatusCode.BadRequest, signInResponseMessage.Value);
                    }
                    
         
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, signUpResponseMessage.Value);
                }

            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("api/users/Login")]
        public IHttpActionResult PostLogin(UserLogin userLoginModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            ObjectParameter signInResponseMessage = new ObjectParameter("responseMessage", "");
            ObjectParameter signInStatus = new ObjectParameter("Status", 0);
            ObjectParameter UserId = new ObjectParameter("LoggedUserID", 0);
            using (eventMangerEntities entities = new eventMangerEntities())
            {
                entities.spLogin(userLoginModel.Username, userLoginModel.Password, signInResponseMessage, UserId, signInStatus);
                if (Convert.ToInt32(signInStatus.Value) == 1)
                {
                    return Ok(new
                    {
                        LoggedInUserId = UserId.Value
                    });
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, signInResponseMessage.Value);
                }
            }

               
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
