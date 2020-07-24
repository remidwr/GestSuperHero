using Models.Common.Interfaces;
using Models.Global.Entities;
using Models.Global.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Tools.Database;

namespace Models.Global.Services
{
    public class AuthRepository : IAuthRepository<User>
    {
        private Connection _connection;

        public AuthRepository()
        {
            ConnectionInfo Ci = new ConnectionInfo(@"Data Source=PC-DE-REMS;Initial Catalog=DBHeros;Integrated Security=True;");
            _connection = new Connection(SqlClientFactory.Instance, Ci);
        }

        public User Login(string login, string passwd)
        {
            Command command = new Command("Login", true);
            command.AddParameter("Email", login);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, (dr) => dr.ToUser()).SingleOrDefault();
        }

        public void Register(User user)
        {
            Command command = new Command("Register", true);
            command.AddParameter("Nom", user.Nom);
            command.AddParameter("Prenom", user.Prenom);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);

            _connection.ExecuteNonQuery(command);
        }
    }
}
