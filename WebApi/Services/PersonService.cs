using System.Threading.Tasks;
using WebApi.Database.Models;
using WebApi.Database.Repositories.Base;
using WebApi.Services.Base;

namespace WebApi.Services{
    public interface IPersonService:IBaseService<Person>
    {
        Task<Person> GetPersonByName(string name,string lastName = "");
        Task<Person> GetPersonByEmail(string email);
    }

    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IBaseRepository<Person> repository) : base(repository)
        {
        }

        public Task<Person> GetPersonByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<Person> GetPersonByName(string name, string lastName = "")
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> ValidateOnCreateAsync(Person model)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> ValidateOnDeleteAsync(Person model)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> ValidateOnUpdateAsync(Person model)
        {
            throw new System.NotImplementedException();
        }
    }
}