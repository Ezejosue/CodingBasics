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
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of <see cref="Employee"/>.</returns>
    public async Task<List<VEmployee>> GetPersonsAsync(int pageNumber, int pageSize)
    {
        try
        {
            return await _context.VEmployees
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
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Employee"/> matching the provided first name.</returns>
    public async Task<List<EmployeeInfoDto>> GetPersonByNameAsync(string firstName)
    {
        try
        {
            firstName = firstName.ToLower();
            var query = (from e in _context.Employees
                         join p in _context.People on e.BusinessEntityId equals p.BusinessEntityId
                         where (p.FirstName.ToLower() + " " + p.LastName.ToLower()).Contains(firstName)
                         select new EmployeeInfoDto
                         {
                             BusinessEntityID = e.BusinessEntityId,
                             EmployeeName = p.FirstName + " " + p.LastName,
                             PersonType = p.PersonType,
                             Gender = e.Gender,
                             DateOfBirth = e.BirthDate.ToString(),
                             MaritalStatus = e.MaritalStatus,
                             JobTitle = e.JobTitle,
                             VacationHours = e.VacationHours,
                             HireDate = e.HireDate.ToString()
                         });


            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            // Handle the exception here
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<EmployeeInfoDto>(); // Return an empty list or handle the error accordingly
        }
    }

    /// <summary>
    /// Retrieves persons filtered by their type with pagination.
    /// </summary>
    /// <param name="personType">The person type to filter by.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paginated list of <see cref="Employee"/> of the specified type.</returns>
    public async Task<List<EmployeeInfoDto>> GetPersonByPersonTypeAsync(string personType)
    {
        try
        {
            var employees = await _context.Employees
                                          .Join(_context.People,
                                                e => e.BusinessEntityId,
                                                p => p.BusinessEntityId,
                                                (e, p) => new { e, p })
                                          .Where(ep => ep.p.PersonType == personType)
                                          .Select(ep => new EmployeeInfoDto
                                          {
                                              BusinessEntityID = ep.e.BusinessEntityId,
                                              EmployeeName = ep.p.FirstName + " " + ep.p.LastName,
                                              PersonType = ep.p.PersonType,
                                              Gender = ep.e.Gender,
                                              DateOfBirth = ep.e.BirthDate.ToString(),
                                              MaritalStatus = ep.e.MaritalStatus,
                                              JobTitle = ep.e.JobTitle,
                                              VacationHours = ep.e.VacationHours,
                                              HireDate = ep.e.HireDate.ToString()
                                          })
                                          .ToListAsync();

            if (employees == null)
            {
                throw new ApplicationException("Employee not found");
            }
            else
            {
                return employees;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving employees: " + ex.Message);
        }
    }

    /// <summary>
    /// Searches for persons by both name and type.
    /// </summary>
    /// <param name="firstName">The first name to search for.</param>
    /// <param name="personType">The person type to filter by.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Employee"/> matching both the provided first name and person type.</returns>
    public async Task<List<EmployeeInfoDto>> GetPersonByNameAndTypeAsync(string firstName, string personType)
    {
        try
        {
            var employees = await _context.Employees
                                          .Join(_context.People,
                                                e => e.BusinessEntityId,
                                                p => p.BusinessEntityId,
                                                (e, p) => new { e, p })
                                          .Where(ep => ep.p.FirstName.Contains(firstName) && ep.p.PersonType == personType)
                                          .Select(ep => new EmployeeInfoDto
                                          {
                                              BusinessEntityID = ep.e.BusinessEntityId,
                                              EmployeeName = ep.p.FirstName + " " + ep.p.LastName,
                                              PersonType = ep.p.PersonType,
                                              Gender = ep.e.Gender,
                                              DateOfBirth = ep.e.BirthDate.ToString(),
                                              MaritalStatus = ep.e.MaritalStatus,
                                              JobTitle = ep.e.JobTitle,
                                              VacationHours = ep.e.VacationHours,
                                              HireDate = ep.e.HireDate.ToString()
                                          })
                                          .ToListAsync();

            if (employees == null)
            {
                throw new ApplicationException("Employee not found");
            }
            else
            {
                return employees;
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving employees: " + ex.Message);
        }
    }


}