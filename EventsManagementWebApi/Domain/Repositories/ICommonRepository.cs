using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventsManagementWebApi.Domain.Repositories
{
    public interface ICommonRepository<T> where T : class
    {
        IEnumerable<T> ListAsync();

        Task<T> FindByIdAsync(object id);

        void AddAsync(T obj);

        void Update(T obj);

        void Remove(T obj);
    }
}