using DapperAPI.Model;
using DapperAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _empObj;
        public EmployeeController(IEmployeeRepo empObj)
        {
            _empObj = empObj;
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails()
        {
            var response = await _empObj.GetDetails();
            if (response != null)
            {
                return Ok(response);
            }
            else {
                return NotFound();
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateData([FromBody] Employee employee )
        {
            return Ok(await _empObj.Create(employee));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]Employee employee, int id)
        {
            var response = await _empObj.Update(employee, id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _empObj.Delete(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("byId")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _empObj.Delete(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("byEmpCode")]
        public async Task<IActionResult> GetByEmpCode(string empcode)
        {
            var response = await _empObj.GetDetailsbyCode(empcode);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
