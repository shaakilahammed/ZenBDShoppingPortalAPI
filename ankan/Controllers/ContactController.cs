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
    [RoutePrefix("api/contacts")]

    public class ContactController : ApiController
    {
        ContactRepository ContactRepo = new ContactRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(ContactRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = ContactRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(ContactRepo.Get(id));
        }
        [Route("")]
        public IHttpActionResult Post(Contact contact)
        {
            ContactRepo.Insert(contact);
            return Created("api/contacts" + contact.ContactId, contact);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Contact contact)
        {
            contact.ContactId = id;
            ContactRepo.Update(contact);
            return Ok(contact);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = ContactRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            ContactRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
