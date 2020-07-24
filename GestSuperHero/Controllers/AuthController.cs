using GestSuperHero.Models;
using GestSuperHero.Models.Services;
using Models.Common.Interfaces;
using Models.Global.Entities;
using Models.Global.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestSuperHero.Controllers
{
    public class AuthController : ApiController
    {
        IAuthRepository<User> _authRepository;

        public AuthController()
        {
            _authRepository = new AuthRepository();
        }

        [HttpPost]
        [Route("api/auth/login")]
        public User Login([FromBody] LoginInfo loginInfo)
        {
            User user = _authRepository.Login(loginInfo.Login, loginInfo.Passwd);

            if (!(user is null))
                user.Token = TokenService.Instance.EncodeToken(user);

            return user;
        }

        [HttpPost]
        [Route("api/auth/register")]
        public void Register([FromBody] User user)
        {
            _authRepository.Register(user);
        }
    }
}
