using EventsManagementWebApi.Resources.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsManagementWebApi.Services.Comunication
{
    public class LoginResponse : BaseResponse
    {
        public LoginDTO LoginDTO { get; set; }
        public LoginResponse(bool success, string message, LoginDTO loginDTO): base(success, message)
        {
            LoginDTO = loginDTO;
        }

        public LoginResponse(LoginDTO loginDTO) : this(true, string.Empty, loginDTO) { }

        public LoginResponse(string message) : this(false, message, null) { }
    }
}