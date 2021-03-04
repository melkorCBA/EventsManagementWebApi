using EventDataAccess;
using EventsManagementWebApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventsManagementWebApi.Presistance.Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
         
        public EventRepository(eventMangerEntities context) : base(context)
        {

        }

        public  void AddAsync(Event e)
        {
            _context.Events.Add(e);
        }

        public async Task<Event> FindByIdAsync(object id)
        {
            return await _context.Events.FindAsync(Convert.ToInt32(id));
        }

        public IEnumerable<Event> ListAsync()
        {
            return _context.Events.ToList();
        }

        public void Remove(Event e)
        {
            _context.Events.Remove(e);
        }

        public async void Update(Event e)
        {
            var ev = await _context.Events.FindAsync(e.EventID);
            if(ev == null)
            {
                return;
            }

            _context.Entry(ev).CurrentValues?.SetValues(e);
        }
    }
}