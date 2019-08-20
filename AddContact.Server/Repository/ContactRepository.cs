using AddContact.Server.Infrastructure;
using AddContact.Server.Models;
using Dapper;
using System.Threading.Tasks;

namespace AddContact.Server.Repository
{
    public interface IContactRepository
    {
        Task<Contact> GetById(int id);
        Task Update(Contact contact);
    }

    public class ContactRepository : RepositoryBase, IContactRepository
    {
        public ContactRepository(IConfig config) : base(config)
        {
        }

        public async Task<Contact> GetById(int id)
        {
            var dp = new DynamicParameters(new { id });
            var result = await ExecProcWithFirstResult<Contact>("dbo.p_ContactGetById", dp);
            return result;
        }

        public async Task Update(Contact contact)
        {
            var dp = new DynamicParameters(new { contact.Id, contact.Name, contact.Phone, contact.PostCode, contact.StreetAddress, contact.Suburb });
            await ExecProc("dbo.p_ContactGetById", dp);
        }
    }
}
