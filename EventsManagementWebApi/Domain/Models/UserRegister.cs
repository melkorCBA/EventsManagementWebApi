using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsManagementWebApi.Models
{
    public class UserRegister
    {
        public string username { get; set; }
         public string password {get; set; }
         public string fullName {get; set; }
    }
}