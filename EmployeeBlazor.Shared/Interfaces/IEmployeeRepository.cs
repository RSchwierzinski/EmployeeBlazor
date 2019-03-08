using EmployeeBlazor.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeBlazor.Shared.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task Insert(Employee employee);
        Task Update(Employee employee);
        Task Delete(int id);
    }
}
