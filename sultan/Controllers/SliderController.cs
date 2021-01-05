using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZenBD_API.Authentication;
using ZenBD_API.Models;
using ZenBD_API.Repositories;

namespace ZenBD_API.Controllers
{
    [RoutePrefix("api/sliders")]
    public class SliderController : ApiController
    {
        SliderRepository SliderRepo = new SliderRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(SliderRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = SliderRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(SliderRepo.Get(id));
        }
        [Route("")]
        public IHttpActionResult Post(Slider slider)
        {
            SliderRepo.Insert(slider);
            return Created("api/sliders" + slider.SliderId, slider);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Slider slider)
        {
            slider.SliderId = id;
            SliderRepo.Update(slider);
            return Ok(slider);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = SliderRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            SliderRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
