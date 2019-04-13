using EFExamples.Data;
using EFExamples.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFExamples.Tests
{
    [TestClass]
    public class DataGenerator
    {
        private static EFExamplesDbContext dbContext;
        private readonly List<string> departmentNames = new List<string>
        {
            "HR",
            "Accounting",
            "Legal",
            "IT",
            "Customer Service",
            "Sales"
        };
        private readonly int numberOfCompanies = 3;
        private readonly int numberOfContractorsPerDepartment = 5;
        private readonly int numberOfContractorsPerVendor = 10;
        private readonly int numberOfEmployeesPerDepartment = 25;
        private readonly int numberOfVendorsPerCompany = 3;
        private readonly Random random = new Random();
        private readonly List<int> documentTypeIds = new List<int> { 1, 2, 3 };

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            dbContext = new EFExamplesDbContext();
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            dbContext.Dispose();
        }


        [TestMethod]
        public void AddFileTypes()
        {
            var documentTypes = new List<DocumentType>
            {
                new DocumentType
                {
                    Name = "Invoice"
                },
                new DocumentType
                {
                    Name = "References"
                },
                new DocumentType
                {
                    Name = "Form I9"
                }
            };

            dbContext.DocumentType.AddRange(documentTypes);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void AddDocumentsToExistingEmployees()
        {
            var employees = dbContext.Employee.Include(m => m.EmployeeDocuments).ToList();

            foreach (var employee in employees)
            {
                employee.EmployeeDocuments.Add(new EmployeeDocument
                {
                    FileDescription = new FileDescription
                    {
                        ContentType = ".PDF",
                        FileName = "Test File",
                        Description = "File description",
                        DocumentTypeId = documentTypeIds.ElementAt(random.Next(documentTypeIds.Count))
                    }
                });
            }

            dbContext.SaveChanges();
        }

        [TestMethod]
        public void GenerateData()
        {
            var companies = new List<Company>();
            var vendors = new List<Vendor>();

            for (var i = 0; i < numberOfCompanies; i++)
            {
                var companyFake = ModelFakes.CompanyFake.Generate();
                dbContext.Company.Add(companyFake);
                companies.Add(companyFake);
            }

            dbContext.SaveChanges();

            foreach (var company in companies)
            {
                for (var i = 0; i < numberOfVendorsPerCompany; i++)
                {
                    var vendor = ModelFakes.VendorFake.Generate();
                    vendor.Contractors = new List<Contractor>();

                    for (var c = 0; c < numberOfContractorsPerVendor; c++)
                    {
                        var contractor = ModelFakes.ContractorFake.Generate();
                        vendor.Contractors.Add(contractor);
                    }

                    dbContext.Vendor.Add(vendor);
                    vendors.Add(vendor);
                }

                dbContext.SaveChanges();

                foreach (var departmentName in departmentNames)
                {
                    var department = new Department
                    {
                        Name = departmentName,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        CompanyId = company.Id,
                        Employees = new List<Employee>(),
                        DepartmentContractors = new List<DepartmentContractor>()
                    };

                    for (var i = 0; i < numberOfEmployeesPerDepartment; i++)
                    {
                        var employee = ModelFakes.EmployeeFake.Generate();
                        employee.CompanyId = company.Id;
                        employee.EmployeeDocuments = new List<EmployeeDocument>
                        {
                            new EmployeeDocument
                            {
                                FileDescription = new FileDescription
                                {
                                    ContentType = ".PDF",
                                    FileName = "Test File",
                                    Description = "File description",
                                    DocumentTypeId = documentTypeIds.ElementAt(random.Next(documentTypeIds.Count))
                                }
                            }
                        };
                        department.Employees.Add(employee);
                    }

                    var vendor = vendors[random.Next(vendors.Count)];

                    for (var v = 0; v < numberOfContractorsPerDepartment; v++)
                    {
                        var contractor = vendor.Contractors.ElementAt(random.Next(vendor.Contractors.Count));

                        if (!department.DepartmentContractors.Any(m => m.ContractorId == contractor.Id))
                            department.DepartmentContractors.Add(new DepartmentContractor
                            {
                                ContractorId = contractor.Id
                            });
                        else
                            v--;
                    }

                    dbContext.Department.Add(department);
                }

                dbContext.SaveChanges();
            }
        }
    }
}
