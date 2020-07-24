using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common.Interfaces
{
    public interface IAuthRepository<TUser>
    {
        void Register(TUser user);
        TUser Login(string login, string passwd);
    }
}
