using Microsoft.EntityFrameworkCore;
using PersonApiDotNet7.Models;

namespace CRUD_NET_7.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;

        public PersonService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllPeople()
        {
            var people = await _context.Person.ToListAsync();
            return people;
        }

        public async Task<Person> GetPersonById(int id)
        {
            var person = await _context.Person.FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }

        public async Task<List<Person>> AddPerson(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return await _context.Person.ToListAsync();
        }

        public async Task UpdatePersonById(int id, Person person)
        {
            var personFound = await _context.Person.FindAsync(id);

            if (person.Name != personFound.Name && person.Name != string.Empty) personFound.Name = person.Name;
            if (person.FirstName != personFound.FirstName && person.FirstName != string.Empty) personFound.FirstName = person.FirstName;
            if (person.LastName != personFound.LastName && person.LastName != string.Empty) personFound.LastName = person.LastName;
            if (person.Place != personFound.Place && person.Place != string.Empty) personFound.Place = person.Place;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonById(int id)
        {
            var person = await _context.Person.FirstOrDefaultAsync(x => x.Id == id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
