using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBlazor.Shared.Interfaces;
using EmployeeBlazor.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;

namespace EmployeeBlazor.Client.Pages
{
    public class EmployeeDataBase : ComponentBase
    {
        [Inject]
        protected IEmployeeRepository DataRepository { get; set; }
        
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Parameter]
        public int Id { get; protected set; } = 0;

        [Parameter]
        public string Action { get; protected set; }

        protected string Title { get; set; }
        protected List<Employee> employeeList;
        protected Employee currentEmployee;

        protected override async Task OnParametersSetAsync()
        {
            if (Action == "fetch")
            {
                await FetchEmployees();
                StateHasChanged();
            }
            else if (Action == "create")
            {
                Title = "Mitarbeiter hinzufügen";
                currentEmployee = new Employee();
            }
            else if (Id != 0)
            {
                if (Action == "edit")
                {
                    Title = "Mitarbeiter editieren";
                }
                else if (Action == "delete")
                {
                    Title = "Mitarbeiter löschen";
                }

                currentEmployee = await DataRepository.Get(Id);
            }
        }

        protected async Task FetchEmployees()
        {
            Title = "Mitarbeiter";
            var employees = await DataRepository.GetAll();
            employeeList = employees.ToList();
        }

        protected async Task UpsertEmployee()
        {
            if (currentEmployee.Id != 0)
            {
                await DataRepository.Update(currentEmployee);
            }
            else
            {
                await DataRepository.Insert(currentEmployee);
            }

            UriHelper.NavigateTo("/employee/fetch");
        }

        protected async Task DeleteEmployee()
        {
            await DataRepository.Delete(Id);
            UriHelper.NavigateTo("/employee/fetch");
        }

        protected void Cancel()
        {
            Title = "Mitarbeiter";
            UriHelper.NavigateTo("/employee/fetch");
        }
    }
}