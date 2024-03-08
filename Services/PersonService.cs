using CodingBasics.Data;
using CodingBasics.Models;
using Microsoft.EntityFrameworkCore;


namespace CodingBasics.Services;

/// <summary>
/// Provides services for managing persons in the AdventureWorks2019 database.
/// </summary>
public class PersonService
{
    private readonly AdventureWorks2019Context _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonService"/> class.
    /// </summary>
    /// <param name="context">The database context to be used.</param>
    public PersonService(AdventureWorks2019Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a paginated list of persons from the database.
    /// </summary>
    /// <param name="pageNumber">The page number of the pagination.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of <see cref="Person"/>.</returns>
    public async Task<List<Person>> GetPersonsAsync(int pageNumber, int pageSize)
    {
        try
        {
            return await _context.People
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
        catch (ApplicationException ex)
        {
            throw new ApplicationException("An error occurred while retrieving persons: " + ex.Message);
        }
    }

    /// <summary>
    /// Searches for persons by their first name.
    /// </summary>
    /// <param name="firstName">The first name to search for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Person"/> matching the provided first name.</returns>
    public async Task<List<Person>> GetPersonByNameAsync(string firstName)
    {
        try
        {
            var person = await _context.People
                                 .Where(p => p.FirstName.Contains(firstName)).ToListAsync();

            if (person == null)
            {
                throw new ApplicationException("Person not found");
            }
            else
            {
                return person;

            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving person: " + ex.Message);
        }
    }

    /// <summary>
    /// Retrieves persons filtered by their type with pagination.
    /// </summary>
    /// <param name="personType">The person type to filter by.</param>
    /// <param name="pageNumber">The page number for pagination.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of <see cref="Person"/> of the specified type.</returns>
    public async Task<List<Person>> GetPersonByPersonTypeAsync(string personType, int pageNumber, int pageSize)
    {
        try
        {
            var person = await _context.People
                                 .Where(p => p.PersonType == personType)
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

            if (person == null)
            {
                throw new ApplicationException("Person not found");
            }
            else
            {
                return person;

            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving person: " + ex.Message);
        }
    }

    /// <summary>
    /// Searches for persons by both name and type.
    /// </summary>
    /// <param name="firstName">The first name to search for.</param>
    /// <param name="personType">The person type to filter by.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Person"/> matching both the provided first name and person type.</returns>
    public async Task<List<Person>> GetPersonByNameAndTypeAsync(string firstName, string personType)
    {
        try
        {
            var person = await _context.People
                                 .Where(p => p.FirstName.Contains(firstName) && p.PersonType == personType)
                                 .ToListAsync();

            if (person == null)
            {
                throw new ApplicationException("Person not found");
            }
            else
            {
                return person;

            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving person: " + ex.Message);
        }
    }


}