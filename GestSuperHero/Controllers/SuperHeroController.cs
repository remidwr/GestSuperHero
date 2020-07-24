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
    public class SuperHeroController : ApiController
    {
        ISuperHeroRepository<SuperHero> _superHeroRepository;

        public SuperHeroController()
        {
            _superHeroRepository = new SuperHeroRepository();
        }

        // GET api/values
        [Route("api/SuperHero/{userId}")]
        public IEnumerable<SuperHero> Get()
        {
            return _superHeroRepository.Get(GetUserId());
        }

        // GET api/values/5
        [Route("api/SuperHero/{userId}/{id}")]
        public SuperHero Get(int id)
        {
            return _superHeroRepository.Get(GetUserId(), id);
        }

        // POST api/values
        public SuperHero Post([FromBody] SuperHero superHero)
        {
            return _superHeroRepository.Insert(superHero);
        }

        // PUT api/values/5
        [Route("api/SuperHero/{id}")]
        public bool Put(int id, [FromBody] SuperHero superHero)
        {
            return _superHeroRepository.Update(id, superHero);
        }

        // DELETE api/values/5
        [Route("api/SuperHero/{userId}/{id}")]
        public void Delete(int id)
        {
            _superHeroRepository.Delete(GetUserId(), id);
        }

        private int GetUserId()
        {
            return (int)RequestContext.RouteData.Values["userId"];
        }
    }
}
