using EventDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventsManagementWebApi.Domain.Repositories
{
    public interface IEventRepository : ICommonRepository<Event>
    {
        new void AddAsync(Event e);


        new Task<Event> FindByIdAsync(object id);


        new IEnumerable<Event> ListAsync();


        new void Remove(Event e);


        new void Update(Event e);
       
    }
}