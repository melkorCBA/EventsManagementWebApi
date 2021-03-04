using EventDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace EventsManagementWebApi.Presistance.Repositories
{
    public class BaseRepository
    {
        [Dependency]
        protected readonly eventMangerEntities _context;

        public BaseRepository(eventMangerEntities context)
        {
            _context = context;
        }
    }
}