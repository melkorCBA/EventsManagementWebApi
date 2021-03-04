using EventDataAccess;
using EventsManagementWebApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventsManagementWebApi.Presistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        protected readonly eventMangerEntities _context;

        public UnitOfWork(eventMangerEntities context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}