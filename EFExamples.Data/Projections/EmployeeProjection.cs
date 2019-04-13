using EFExamples.Models.Entities;
using System;
using System.Linq.Expressions;

namespace EFExamples.Data.Projections
{
    public static class EmployeeProjection
    {
        public static Expression<Func<Employee, dynamic>> EmployeeWithoutDocuments
        {
            get
            {
                return m => new
                {
                    m.Name,
                    m.Company,
                    m.Address,
                    m.EmployeeId,
                    m.Id,
                    m.DepartmentId,
                    m.Department,
                    m.CompanyId
                };
            }
        }
    }
}
