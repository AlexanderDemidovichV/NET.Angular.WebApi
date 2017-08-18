using ContactApp.Models;
using ContactApp.Services;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ContactApp.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class ContactsController : ApiController
    {
        // GET: api/Contacts
        public IQueryable<Contact> Get()
        {
            //Thread.Sleep(3000);
            return ContactsService.Instance.GetContacts();
        }

        // GET: api/Contacts/5
        public IHttpActionResult Get(int id)
        {
            var contact = ContactsService.Instance.GetContacts().FirstOrDefault((c) => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST: api/Contacts
        public IHttpActionResult Post(Contact contact)
        {
            if (ModelState.IsValid)
            {
                ContactsService.Instance.Add(contact);

                return Ok(contact);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Contacts/5
        public IHttpActionResult Put(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            if (ContactsService.Instance.Update(contact))
            {
                return Ok();
            }
            return BadRequest();
        }


        // DELETE: api/Contacts/5
        public IHttpActionResult Delete(int id)
        {
            var contact = ContactsService.Instance.GetContacts().FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            ContactsService.Instance.Remove(id);
            return Ok();
        }
    }
}
