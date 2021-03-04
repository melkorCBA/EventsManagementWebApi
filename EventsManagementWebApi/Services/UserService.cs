using EventsManagementWebApi.Domain.Repositories;
using EventsManagementWebApi.Domain.Services;
using EventsManagementWebApi.Services.Comunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventsManagementWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                var loginDTO = _userRepository.LoginAsync(username, password);
                await _unitOfWork.CompleteAsync();
                if(loginDTO.Status != 1)
                {
                    return new LoginResponse(loginDTO.ResponseMessage);
                }

                return new LoginResponse(loginDTO);
            }
            catch(Exception ex)
            {
                return new LoginResponse($"An error occurred when logging user: {ex.Message}");
            }
        }

        public async Task<RegisterResponse> RegisterAsync(string username, string fullname, string password)
        {
            try {
                var registerDTO = _userRepository.RegisterAsync(username, fullname, password);
                await _unitOfWork.CompleteAsync();
                if(registerDTO.Status != 1)
                {
                    return new RegisterResponse(registerDTO.responseMessage);
                }


                return new RegisterResponse(registerDTO);

            }
            catch (Exception ex)
            {
                return new RegisterResponse($"An error occurred when registering user: {ex.Message}");
            }
        }
    }
}