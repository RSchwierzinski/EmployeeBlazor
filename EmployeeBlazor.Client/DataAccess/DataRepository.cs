using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeBlazor.Shared.Interfaces;
using EmployeeBlazor.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazor.Client.DataAccess
{
    public class DataRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;
        public DataRepository(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync("/api/employee/" + id);
        }

        public async Task<Employee> Get(int id)
        {
            return await _httpClient.GetJsonAsync<Employee>("/api/employee/" + id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _httpClient.GetJsonAsync<IEnumerable<Employee>>("/api/employee");
        }

        public async Task Insert(Employee employee)
        {
            await _httpClient.SendJsonAsync(HttpMethod.Post, "/api/employee", employee);
        }

        public async Task Update(Employee employee)
        {
            await _httpClient.SendJsonAsync(HttpMethod.Put, "/api/employee", employee);
        }
    }
}
