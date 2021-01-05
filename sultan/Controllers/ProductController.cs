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
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        ProductRepository ProductRepo = new ProductRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(ProductRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = ProductRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            user.links = UserLinks.getLinks(id, 2);
            return Ok(ProductRepo.Get(id));
        }
        [Route("")]
        
        public IHttpActionResult Post(Product product)
        {
            if (product.Quantity <= 0)
            {
                product.Quantity = 0;
            }
            if (product.Price <= 0)
            {
                product.Price = 0;
            }
            ProductRepo.Insert(product);
            return Created("api/products" + product.ProductId, product);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Product product)
        {
            product.ProductId = id;
            if (product.Quantity <= 0)
            {
                product.Quantity = 0;
            }
            if (product.Price <= 0)
            {
                product.Price = 0;
            }
            ProductRepo.Update(product);
            return Ok(product);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = ProductRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            ProductRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
