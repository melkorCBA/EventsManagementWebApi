using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EventsManagementWebApi.Models
{
    public class UserLogin
    {
        [DisplayName("username")]
        public string Username { get; set; }
        [DisplayName("password")]
        public string Password { get; set; }
    }
}