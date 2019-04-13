using EFExamples.Models.Entities;
using EFExamples.Models.ValueTypes;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EFExamples.Data.Commands
{
    public static class EmployeeCommand
    {
        public static async Task UpdateEmployee(this DbSet<Employee> employeeDbSet, Employee employee)
        {
            var existingEmployee = await employeeDbSet.FirstOrDefaultAsync(m => m.Id == employee.Id);
            existingEmployee.Name = new PersonName(employee.Name.FirstName, employee.Name.LastName);
            existingEmployee.Address = new Address(employee.Address.StreetAddress, employee.Address.City, employee.Address.State, employee.Address.ZipCode);
            existingEmployee.DateOfBirth = employee.DateOfBirth;
        }
    }
}
