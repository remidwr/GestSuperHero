using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Common.Interfaces
{
    public interface ISuperHeroRepository<TSuperHero>
    {
        IEnumerable<TSuperHero> Get(int userId);
        TSuperHero Get(int userId, int id);
        TSuperHero Insert(TSuperHero entity);
        bool Update(int id, TSuperHero entity);
        bool Delete(int userId, int id);
    }
}
