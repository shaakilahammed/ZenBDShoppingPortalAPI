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
    [RoutePrefix("api/invoices")]
    public class InvoiceController : ApiController
    {
        InvoiceRepository InvoiceRepo = new InvoiceRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(InvoiceRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = InvoiceRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(InvoiceRepo.Get(id));
        }
        [Route("user/{id}")]
        public IHttpActionResult GetByUserId(int id)
        {
            var user = InvoiceRepo.GetAllInvoice(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(InvoiceRepo.GetAllInvoice(id));
        }
        [Route("")]
        public IHttpActionResult Post(Invoice invoice)
        {
            InvoiceRepo.Insert(invoice);
            return Created("api/invoices" + invoice.InvoiceNumber, invoice);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Invoice invoice)
        {
            invoice.InvoiceNumber = id;
            InvoiceRepo.Update(invoice);
            return Ok(invoice);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = InvoiceRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            InvoiceRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
