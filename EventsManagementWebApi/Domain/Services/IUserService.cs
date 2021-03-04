using EventsManagementWebApi.Services.Comunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventsManagementWebApi.Domain.Services
{
    public interface IUserService
    {
        Task<LoginResponse> LoginAsync(string username, string password);
        Task<RegisterResponse> RegisterAsync(string username, string fullname, string password);
    }
}