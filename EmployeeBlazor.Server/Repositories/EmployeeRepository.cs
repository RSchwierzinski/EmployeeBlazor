using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using EmployeeBlazor.Shared.Interfaces;
using EmployeeBlazor.Shared.Models;
using Microsoft.Extensions.Configuration;

namespace EmployeeBlazor.Server.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _config;

        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public  async Task Insert(Employee employee)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                await conn.InsertAsync<Employee>(employee);
            }
        }

        public async Task Delete(int id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                await conn.DeleteAsync<Employee>(new Employee {Id = id });
            }
        }

        public async Task<Employee> Get(int id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.GetAsync<Employee>(id);
                return result;
            }
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.GetAllAsync<Employee>();
                return result;
            }
        }

        public async Task Update(Employee employee)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                await conn.UpdateAsync<Employee>(employee);
            }
        }
    }
}
