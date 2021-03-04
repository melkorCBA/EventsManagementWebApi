using EventDataAccess;
using EventsManagementWebApi.Domain.Repositories;
using EventsManagementWebApi.Resources.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventsManagementWebApi.Presistance.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(eventMangerEntities context) : base(context)
        {

        }

        public LoginDTO LoginAsync(string username, string password)
        {
            // proc ouput params
            ObjectParameter responseMessage = new ObjectParameter("responseMessage", "");
            ObjectParameter Status = new ObjectParameter("Status", 0);
            ObjectParameter LoggedUserID = new ObjectParameter("LoggedUserID", 0);

            //entities.spLogin(userLoginModel.Username, userLoginModel.Password, signInResponseMessage, UserId, signInStatus);
            _context.spLogin(username, password, responseMessage, LoggedUserID, Status);

            var loginResponse = new LoginDTO();
            loginResponse.LoggedUserID = Convert.ToInt32(LoggedUserID.Value);
            loginResponse.Status = Convert.ToInt32(Status.Value);
            loginResponse.ResponseMessage = responseMessage.Value.ToString();

            return loginResponse;
        }

        public RegisterDTO RegisterAsync(string username, string fullname, string password)
        {
            // proc ouput params
            ObjectParameter responseMessage = new ObjectParameter("responseMessage", "");
            ObjectParameter Status = new ObjectParameter("Status", 0);
            

            _context.spAddUser(username, password, fullname, responseMessage, Status);

            var registerResponse = new RegisterDTO();
            registerResponse.responseMessage = responseMessage.Value.ToString();
            registerResponse.Status = Convert.ToInt32(Status.Value);

            return registerResponse;

        }
    }
}