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
    [RoutePrefix("api/services")]
    public class ServiceController : ApiController
    {
        ServiceRepository ServiceRepo = new ServiceRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(ServiceRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = ServiceRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(ServiceRepo.Get(id));
        }
        [Route("")]
        public IHttpActionResult Post(AllService allService)
        {
            ServiceRepo.Insert(allService);
            return Created("api/services" + allService.serviceId, allService);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] AllService allService)
        {
            allService.serviceId = id;
            ServiceRepo.Update(allService);
            return Ok(allService);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = ServiceRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            ServiceRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
