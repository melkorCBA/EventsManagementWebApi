using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsManagementWebApi.Services.Comunication
{
    public class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}