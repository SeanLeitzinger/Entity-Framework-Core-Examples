using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFExamples.Data.Queries
{
    public static class EmployeeQuery
    {
        public static async Task<dynamic> GetEmployeeByIdAsync(this DbSet<Employee> employeeDbSet, Expression<Func<Employee, dynamic>> projection, int employeeId)
        {
            return await employeeDbSet.Where(m => m.Id == employeeId).Select(projection).FirstOrDefaultAsync();
        }
    }
}
