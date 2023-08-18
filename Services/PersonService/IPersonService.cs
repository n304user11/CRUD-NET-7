using PersonApiDotNet7.Models;

namespace CRUD_NET_7.Services.PersonService
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPeople();
        Task<Person> GetPersonById(int id);
        Task<List<Person>> AddPerson(Person person);
        Task UpdatePersonById(int id, Person person);
        Task DeletePersonById(int id);
    }
}
