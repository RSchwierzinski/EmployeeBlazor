using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeBlazor.Server.Repositories;
using EmployeeBlazor.Shared.Interfaces;
using EmployeeBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _repository.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public async void Post([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            { 
                await _repository.Insert(employee);
            }
        }

        // PUT api/<controller>
        [HttpPut]
        public async void Put([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _repository.Update(employee);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
