using AutoMapper;
using EventDataAccess;
using EventsManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsManagementWebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        
        
            public AutoMapperConfig()
            {
                Mapper.CreateMap<Event, SaveEventModel>().ReverseMap();
                Mapper.CreateMap<IEnumerable<PublicEvent>, IEnumerable<spGetAllEvents1_Result>>().ReverseMap();
                
            }
           
        
    }
}