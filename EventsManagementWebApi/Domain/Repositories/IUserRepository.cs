using EventsManagementWebApi.Resources.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventsManagementWebApi.Domain.Repositories
{
    public interface IUserRepository
    {
        LoginDTO LoginAsync(string username, string password);
        RegisterDTO RegisterAsync(string username, string fullname, string password);
    }
}