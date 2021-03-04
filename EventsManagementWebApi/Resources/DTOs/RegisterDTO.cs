using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EventsManagementWebApi.Resources.DTOs
{
    public class RegisterDTO
    {
        
        public string responseMessage { get; set; }

        // 1 for success 0 for failier
        public int Status { get; set; }
    }
}