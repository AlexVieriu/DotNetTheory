namespace Api_FromAttributes.Models;

public class PersonServices : IPersonServices
{
    private List<Person> persons;
    public PersonServices()
    {
        persons = new()
        {
            new Person() { Id = 1, Name = "Alex", Age = 33 },
            new Person() { Id = 2, Name = "Alina", Age = 34 },
            new Person() { Id = 3, Name = "Cristi", Age = 35 }
        };
    }

    public Person GetPersonById(int id)
    {
        if (id > 0)
            return persons.FirstOrDefault(x => x.Id == id);

        return null;
    }

}
