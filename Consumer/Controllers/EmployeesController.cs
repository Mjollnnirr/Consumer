using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Entity.DataTransferObjects.Employee;
using Microsoft.AspNetCore.Http;
using CommonData.StatusCode;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Consumer.Controllers;

[Route("api/[controller]"), ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    // GET: api/values
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _employeeService.GetAll();
            return StatusCode(StatusCodes.Status200OK, data);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response(4088, ex.Message));
        }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(EmployeeCreateDto employee)
    {
        try
        {
            await _employeeService.Create(employee);
            return StatusCode(StatusCodes.Status200OK, new Response(2044, "Successfully created"));
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response(4055, ex.Message));
        }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

