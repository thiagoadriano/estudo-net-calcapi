using CalculatorApi.Model;
using System.Net;

namespace CalculatorApi.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 8; i++) {
                people.Add(MockPerson(i));
            }
            return people;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "First " + i,
                LastName = "Last " + i,
                Address = "Morada " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person{ 
                Id = id,
                FirstName = "Thiago",
                LastName = "Adriano",
                Address = "Minha Morada",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
