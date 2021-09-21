using DbProvider.Abstractions;
using DbProvider.Models;
using Myapp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DbProvider.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IJWTService _jwtService;
        private readonly IUserRepository _repo;


        public AccountService(IJWTService jwtService, IUserRepository repo)
        {
            _repo = repo;
            _jwtService = jwtService;
        }

        public async Task<(int status, string token)> Authenticate(AccountServiceModel model)
        {
            var userEntity = await _repo.GetByUserPass(model.UserName, model.Password);

            if (userEntity != null)
            {
                var token = _jwtService.GenerateSecurityToken(userEntity.Email);

                return (200, token);
            }
            return (400, string.Empty);
        }
    }
}
