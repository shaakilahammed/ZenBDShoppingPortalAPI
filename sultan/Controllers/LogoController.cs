using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZenBD_API.Models;
using ZenBD_API.Repositories;

namespace ZenBD_API.Controllers
{
    [RoutePrefix("api/logos")]
    public class LogoController : ApiController
    {
        LogoRepositories LogoRepo = new LogoRepositories();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(LogoRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = LogoRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(LogoRepo.Get(id));
        }
        [Route("")]
        public IHttpActionResult Post(Logo logo)
        {
            LogoRepo.Insert(logo);
            return Created("api/logos" + logo.LogoId, logo);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Logo logo)
        {
            logo.LogoId = id;
            LogoRepo.Update(logo);
            return Ok(logo);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = LogoRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            LogoRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
