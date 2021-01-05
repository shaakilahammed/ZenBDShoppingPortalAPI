using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZenBD_API.Links;
using ZenBD_API.Models;
using ZenBD_API.Repositories;

namespace ZenBD_API.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        UserRepository UserRepo = new UserRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(UserRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = UserRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            //User user = UserRepo.Get(id);
            user.links = UserLinks.getLinks(id, 1);
            //return Ok(user);
            return Ok(UserRepo.Get(id));
        }
        [Route("")]
        public IHttpActionResult Post(User user)
        {
            UserRepo.Insert(user);
            return Created("api/users" + user.UserId, user);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] User user)
        {
            user.UserId = id;
            UserRepo.Update(user);
            return Ok(user);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = UserRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            UserRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("{id}/Profile")]
        public IHttpActionResult GetProfile(int id)
        {
            User user = UserRepo.Get(id);
            user.links = UserLinks.getLinks(id, 2);
            return Ok(user);
        }
        [Route("login")]
         public IHttpActionResult PostValiddata(User user)
        {
            if (UserRepo.Validdata(user))
            {
                return Ok(UserRepo.SearchByUserName(user));
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }

    }
}
