using EventsManagementWebApi.Resources.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsManagementWebApi.Services.Comunication
{
    public class RegisterResponse : BaseResponse
    {
        public RegisterDTO RegisterDTO { get; set; }

        public RegisterResponse(bool success, string message, RegisterDTO registerDTO) : base (success, message)
        {
            RegisterDTO = registerDTO;
        }

        public RegisterResponse(RegisterDTO registerDTO) : this(true, string.Empty, registerDTO) { }

        public RegisterResponse(string message) : this(false, message, null) { }
    }
}