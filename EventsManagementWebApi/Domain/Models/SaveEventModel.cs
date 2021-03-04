using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsManagementWebApi.Models
{
    public class SaveEventModel
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Nullable<double> Duration { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public Nullable<bool> Private { get; set; }
        public Nullable<int> PublisherId { get; set; }
        
    }
}