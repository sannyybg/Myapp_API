using DbProvider;
using DbProvider.VirtualDTO;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tt1ap;

namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    //[Authorize]
    [Route("api/v{version:ApiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private ILogger<CompanyController> _logger;
        private ISingletonService<Employee> _service;

        public CompanyController(ISingletonService<Employee> service, ILogger<CompanyController> logger)
        {
            _service = service;
            _logger = logger;

        }

        

        [MapToApiVersion("1.0")]
        [HttpGet]
        //public IActionResult GetAll()
        //{
        //    var ss = _service.GetAll();
        //    if (ss == null)
        //    {
        //        return Ok(new List<Employee>());
        //    }
        //    else
        //    {
        //        return Ok(ss);
        //    }
        //}


        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ss = await _service.GetAllAsync();
            
            if (ss == null)
            {
                return Ok(new List<Employee>());
            }
            else
            {
                return Ok(ss);
            }
        }



        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var ss = await _service.GetAsync(id);
            return Ok(ss);
        }


        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteAsync(id);
            return Ok($"Deleted {id}");
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, EmployeeModel emp)
        {
            Employee empl = emp.Adapt<Employee>();
            empl.Id = id;

            await _service.UpdateAsync(empl);
            return Ok($"Update Succesfully");
        }


        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeModel emp)
        {
            _logger.LogInformation($"Log with Nlog, for Add Method, Time: {DateTime.Now}");

            Employee empl = emp.Adapt<Employee>();
            await _service.CreateAsync(empl);

            return Ok("New Item Added");
        }




        //[MapToApiVersion("2.0")]
        //[HttpGet]
        //public IActionResult GetAll2()
        //{

        //    throw new Exception("Custom Ex");
        //    return Ok();
        //}

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetAll2()
        {
            var ss = _service.GetAllAsync();
            if (ss == null)
            {
                return Ok(new List<Employee>());
            }
            else
            {
                return Ok(ss);
            }
        }

        
        [MapToApiVersion("2.0")]
        //[HttpGet("{id}")]
        [HttpGet("{testid}")]
        public IActionResult Get2(int id, int testid)
        {
            var ss = _service.GetAsync(id);
            return Ok(ss);
        }

        
        [MapToApiVersion("2.0")]
        //[HttpDelete("{id}")]
        [HttpDelete("{testid}")]
        public IActionResult Delete2(int id, int testId)
        {
            _service.DeleteAsync(id);
            return Ok($"Deleted {id}");
        }

        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public IActionResult Update2(int id, string name, int age)
        {
            var emp = new Employee
            {
                Id = id,
                Name = name,
                Age = age
            };
            _service.UpdateAsync(emp);
            return Ok($"Update Succesfully");
        }

        //[MapToApiVersion("2.0")]
        //[HttpPost]
        //public IActionResult Add2(string name, int age)
        //{
        //    var emp = new Employee
        //    {
        //        Name = name,
        //        Age = age
        //    };
        //    _service.Add(emp);
        //    return Ok($"New Item Added");
        //}

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<IActionResult> Add2(EmployeeModel emp)
        {
            _logger.LogInformation($"Log with Nlog, for Add Method, Time: {DateTime.Now}");

            Employee empl = emp.Adapt<Employee>();
            await _service.CreateAsync(empl);

            return Ok();
        }
    }

}
