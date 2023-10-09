using Microsoft.AspNetCore.Mvc;

namespace DotNetSQL.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly PersonDbContext context;

    public PersonController(ILogger<PersonController> logger, PersonDbContext context)
    {
        _logger = logger;
        this.context = context;
    }

    [HttpGet]
    public IEnumerable<Person> GetPersons()
    {
        return context.Person.ToList();
    }

    [HttpPost]
    public void CreatePerson([FromBody] Person person)
    {
        context.Person.Add(person);
        context.SaveChanges();
    }
}
