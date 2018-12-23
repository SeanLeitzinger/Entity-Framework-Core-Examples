using EFExamples.Data;
using EFExamples.Models;
using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EFExamples.Tests
{
    [TestClass]
    public class DataGenerator
    {
        private static EFExamplesDbContext dbContext;
        private int numberOfCompanies = 3;
        private List<string> departmentNames = new List<string>
        {
            "HR",
            "Accounting",
            "Legal",
            "IT",
            "Customer Service",
            "Sales"
        };
        private int numberOfEmployeesPerDepartment = 25;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {            
            dbContext = new EFExamplesDbContext();
        }

        [TestMethod]
        public void GenerateData()
        {
            var companies = new List<Company>();

            for(var i = 0; i < numberOfCompanies; i++)
            {
                var companyFake = ModelFakes.CompanyFake.Generate();
                dbContext.Company.Add(companyFake);
                companies.Add(companyFake);
            }

            dbContext.SaveChanges();

            foreach(var company in companies)
            {
                foreach(var departmentName in departmentNames)
                {
                    var department = new Department
                    {
                        Name = departmentName,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        CompanyId = company.Id,
                        Employees = new List<Employee>()
                    };

                    for(var i = 0; i < numberOfEmployeesPerDepartment; i++)
                    {
                        var employee = ModelFakes.EmployeeFake.Generate();
                        employee.CompanyId = company.Id;
                        department.Employees.Add(employee);
                    }

                    dbContext.Department.Add(department);
                }

                dbContext.SaveChanges();
            }
        }
    }
}
