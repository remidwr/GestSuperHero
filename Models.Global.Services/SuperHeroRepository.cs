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
    public class SuperHeroRepository : ISuperHeroRepository<SuperHero>
    {
        private Connection _connection;

        public SuperHeroRepository()
        {
            ConnectionInfo Ci = new ConnectionInfo(@"Data Source=PC-DE-REMS;Initial Catalog=DBHeros;Integrated Security=True;");
            _connection = new Connection(SqlClientFactory.Instance, Ci);
        }

        public IEnumerable<SuperHero> Get(int userId)
        {
            Command command = new Command("SELECT Id, Nom, Force, Endurance, Intelligence, Charisme, UserId FROM SuperHeros WHERE UserId = @UserId;");
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, (dr) => dr.ToSuperHero());
        }

        public SuperHero Get(int userId, int id)
        {
            Command command = new Command("SELECT Id, Nom, Force, Endurance, Intelligence, Charisme, UserId FROM SuperHeros WHERE UserId = @UserId AND Id = @Id;");
            command.AddParameter("UserId", userId);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, (dr) => dr.ToSuperHero()).SingleOrDefault();
        }

        public SuperHero Insert(SuperHero entity)
        {
            Command command = new Command("INSERT INTO SuperHeros(Nom, Force, Endurance, Intelligence, Charisme, UserId) OUTPUT inserted.Id VALUES (@Nom, @Force, @Endurance, @Intelligence, @Charisme, @UserId);");
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("Force", entity.Force);
            command.AddParameter("Endurance", entity.Endurance);
            command.AddParameter("Intelligence", entity.Intelligence);
            command.AddParameter("Charisme", entity.Charisme);
            command.AddParameter("UserId", entity.UserId);
            entity.Id = (int)_connection.ExecuteScalar(command);
            return entity;
        }

        public bool Update(int id, SuperHero entity)
        {
            Command command = new Command("UPDATE SuperHeros SET Nom = @Nom, Force = @Force, Endurance = @Endurance, Intelligence = @Intelligence, Charisme = @Charisme WHERE Id = @Id AND UserId = @UserId;");
            command.AddParameter("Id", id);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("Force", entity.Force);
            command.AddParameter("Endurance", entity.Endurance);
            command.AddParameter("Intelligence", entity.Intelligence);
            command.AddParameter("Charisme", entity.Charisme);
            command.AddParameter("UserId", entity.UserId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int userId, int id)
        {
            Command command = new Command("DELETE FROM SuperHeros WHERE Id = @Id AND UserId = @UserId;");
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
