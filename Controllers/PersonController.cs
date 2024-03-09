using CodingBasics.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingBasics.Services;

/// <summary>
/// Controller for handling person-related requests.
/// </summary>
[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService;

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonController"/> class.
    /// </summary>
    /// <param name="personService">The service for managing person data.</param>
    public PersonController(PersonService personService)
    {
        _personService = personService;
    }


    /// <summary>
    /// Gets a paginated list of persons.
    /// </summary>
    /// <param name="pageNumber">The current page number for pagination.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <returns>A list of persons in the specified page range.</returns>
    [HttpGet]
    public async Task<ActionResult<List<VEmployee>>> GetPersonsAsync(int pageNumber, int pageSize)
    {
        try
        {
            var person = await _personService.GetPersonsAsync(pageNumber, pageSize);
            return Ok(person);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving persons");
        }
    }

    /// <summary>
    /// Gets a list of persons by their first name.
    /// </summary>
    /// <param name="firstName">The first name to filter persons by.</param>
    /// <returns>A list of persons matching the provided first name.</returns>
    [HttpGet("{firstName}")]
    public async Task<ActionResult<List<EmployeeInfoDto>>> GetPersonByNameAsync(string firstName)
    {
        try
        {
            var person = await _personService.GetPersonByNameAsync(firstName);
            return Ok(person);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving person");
        }
    }

    /// <summary>
    /// Gets a paginated list of persons by their type.
    /// </summary>
    /// <param name="personType">The type of persons to filter by.</param>
    /// <returns>A list of persons matching the provided type in the specified page range.</returns>
    [HttpGet("personType/{personType}")]
    public async Task<ActionResult<List<EmployeeInfoDto>>> GetPersonByPersonTypeAsync(string personType)
    {
        try
        {
            var person = await _personService.GetPersonByPersonTypeAsync(personType);
            return Ok(person);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving person");
        }
    }

    /// <summary>
    /// Gets a list of persons by both name and type.
    /// </summary>
    /// <param name="firstName">The first name to filter persons by.</param>
    /// <param name="personType">The type of persons to filter by.</param>
    /// <returns>A list of persons matching both the provided first name and type.</returns>
    [HttpGet("personTypeAndName")]
    public async Task<ActionResult<List<EmployeeInfoDto>>> GetPersonByPersonNameAndTypeAsync(string firstName, string personType)
    {
        try
        {
            var person = await _personService.GetPersonByNameAndTypeAsync(firstName, personType);
            return Ok(person);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving person");
        }
    }
}