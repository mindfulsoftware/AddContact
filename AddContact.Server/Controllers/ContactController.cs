using AddContact.Server.Managers;
using AddContact.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AddContact.Server.Controllers
{
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        readonly IContactManager contactManager;

        public ContactController(IContactManager contactManager)
        {
            this.contactManager = contactManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contact = await contactManager.GetById(id);
                return CreateOkWithData(contact);
            }
            catch (Exception ex)
            {
                return CreateBadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact) {
            try {
                var result = await contactManager.Update(contact);
                return CreateOkWithData(result);
            }
            catch (Exception ex) {
                return CreateBadRequest(ex);
            }
        }
    }
}
