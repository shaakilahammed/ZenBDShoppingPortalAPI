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
    [RoutePrefix("api/featuredProducts")]
    public class FeaturedProductsController : ApiController
    {
        
        FeaturedProductsRepository FeaturedProductsRepo = new FeaturedProductsRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(FeaturedProductsRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = FeaturedProductsRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(FeaturedProductsRepo.Get(id));
        }
        [Route("")]
        public IHttpActionResult Post(FeaturedProduct featuredProduct)
        {
            FeaturedProductsRepo.Insert(featuredProduct);
            return Created("api/featuredProducts" + featuredProduct.FeaturedId, featuredProduct);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] FeaturedProduct featuredProduct)
        {
            featuredProduct.FeaturedId = id;
            FeaturedProductsRepo.Update(featuredProduct);
            return Ok(featuredProduct);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = FeaturedProductsRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            FeaturedProductsRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
