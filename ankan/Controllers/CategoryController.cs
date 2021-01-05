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
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        
          CategoryRepository CatRepo = new CategoryRepository();

            [Route("")]
            public IHttpActionResult Get()
            {
                return Ok(CatRepo.GetAll());
            }

            [Route("{id}")]
            public IHttpActionResult Get(int id)
            {
                var user = CatRepo.Get(id);
                if (user == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                return Ok(CatRepo.Get(id));
            }
            [Route("")]
            public IHttpActionResult Post(Category category)
            {
                CatRepo.Insert(category);
                return Created("api/categories" + category.CategoryId, category);
            }
            [Route("{id}")]
            public IHttpActionResult Put([FromUri] int id, [FromBody] Category category)
            {
                category.CategoryId = id;
                CatRepo.Update(category);
                return Ok(category);
            }
            [Route("{id}")]
            public IHttpActionResult Delete(int id)
            {
                var user = CatRepo.Get(id);
                if (user == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                CatRepo.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
    }
}
