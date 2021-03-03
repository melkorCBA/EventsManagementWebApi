using EventDataAccess;
using EventsManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using System.Web;

namespace EventsManagementWebApi.Controllers
{
    public class EventsController : ApiController
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("api/events/public")]
        public IEnumerable<PublicEvent> GetPublic()
        {
            using (eventMangerEntities entities = new eventMangerEntities())
            {
                var events = entities.PublicEvents.ToList();
                return events;
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("api/events/all/{userID?}")]
        public IEnumerable<spGetAllEvents1_Result> GetAll(int userID)
        {

            
            using (eventMangerEntities entities = new eventMangerEntities())
            {
                var AlleventsWithUserEvents = entities.spGetAllEvents1(userID).ToList();
                return AlleventsWithUserEvents;

            }
        }



       


        public Event Get(int id)
        {
            using (eventMangerEntities entities = new eventMangerEntities())
            {
                return entities.Events.FirstOrDefault(e => e.EventID == id);
            }
        }

        public IHttpActionResult Post(SaveEventModel saveEventModel)
        {
            using (eventMangerEntities entities = new eventMangerEntities())
            {

                var result = entities.Events.Add(Mapper.Map<SaveEventModel, Event>(saveEventModel));

                return Ok(result);
            }
        }

        //public IHttpActionResult Delete(int id)
        //{

        //}

        //public IHttpActionResult Put(SaveEventModel saveEventModel)
        //{

        //}
    }
}
