using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace EmployeeCRUD
{
    public class EmployeesOperations : IDisposable
    {
        EmployeesModel context;

        public EmployeesOperations()
        {
            context = new EmployeesModel();
        }

        public async Task<object> GetEmployees(object input)
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<object> AddEmployee(object emp)
        {
            var empAsDictionary = (IDictionary<string, object>)emp;
            var employeeToAdd = new Employee() { 
                Name = (string)empAsDictionary["Name"],
                City = (string)empAsDictionary["City"],
                Occupation = (string)empAsDictionary["Occupation"],
                Salary = (int)empAsDictionary["Salary"]
            };

            var addedEmployee = context.Employees.Add(employeeToAdd);

            await context.SaveChangesAsync();

            return addedEmployee;
        }

        public async Task<object> EditEmployee(object input)
        {
            var empAsDictionary = (IDictionary<string, object>)input;
            var id = (int)empAsDictionary["Id"];

            var employeeEntry = context.Employees.SingleOrDefault(e => e.Id == id);

            employeeEntry.Name = (string)empAsDictionary["Name"];
            employeeEntry.Occupation = (string)empAsDictionary["Occupation"];
            employeeEntry.Salary = (int)empAsDictionary["Salary"];
            employeeEntry.City = (string)empAsDictionary["City"];

            context.Entry(employeeEntry).State = System.Data.Entity.EntityState.Modified;
            
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
