using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using CommonData.StatusCode;
using Entity.DataTransferObjects.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Consumer.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _departmentService.GetAll();
                return StatusCode(StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4066, ex.Message));
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _departmentService.Get(id);
                return StatusCode(StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4066, ex.Message));
            }
        }

        [HttpGet("GetEmployeesByDepartment/{departmentId}")]
        public async Task<IActionResult> GetEmployeesByDepartment(int departmentId)
        {
            try
            {
                var data = await _departmentService.GetEmployeesByDepartment(departmentId);
                return StatusCode(StatusCodes.Status200OK, data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4066, ex.Message));
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(DepartmentCreateDto data)
        {
            try
            {
                await _departmentService.Create(data);
                return StatusCode(StatusCodes.Status200OK, new Response(200, null));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4077, ex.Message));
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
}

