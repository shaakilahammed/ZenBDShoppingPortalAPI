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
    [RoutePrefix("api/invoiceItems")]
    public class InvoiceItemController : ApiController
    {
        InvoiceItemRepository InvoiceItemRepo = new InvoiceItemRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(InvoiceItemRepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var user = InvoiceItemRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(InvoiceItemRepo.Get(id));
        }
        [Route("invoices/{id}")]
        public IHttpActionResult GetByInvoiceId(int id)
        {
            var user = InvoiceItemRepo.GetAllItem(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(InvoiceItemRepo.GetAllItem(id));
        }
        [Route("")]
        public IHttpActionResult Post(InvoiceItem invoiceItem)
        {
            InvoiceItemRepo.Insert(invoiceItem);
            return Created("api/invoiceItems" + invoiceItem.InvoiceNumber, invoiceItem);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] InvoiceItem invoiceItem)
        {
            invoiceItem.InvoiceNumber = id;
            InvoiceItemRepo.Update(invoiceItem);
            return Ok(invoiceItem);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = InvoiceItemRepo.Get(id);
            if (user == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            InvoiceItemRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
