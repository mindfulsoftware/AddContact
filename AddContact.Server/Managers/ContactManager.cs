using AddContact.Server.Models;
using AddContact.Server.Repository;
using System.Threading.Tasks;

namespace AddContact.Server.Managers
{
    public interface IContactManager
    {
        Task<Contact> GetById(int id);
        Task<Contact> Update(Contact contact);
    }

    public class ContactManager : IContactManager
    {
        readonly IContactRepository contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<Contact> GetById(int id)
        {
            return await contactRepository.GetById(id);
        }

        public async Task<Contact> Update(Contact contact)
        {
            await contactRepository.Update(contact);
            return await GetById(contact.Id);
        }
    }
}
