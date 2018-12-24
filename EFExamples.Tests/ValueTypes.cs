using EFExamples.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFExamples.Tests
{
    [TestClass]
    public class ValueTypes
    {
        private static EFExamplesDbContext dbContext;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            dbContext = new EFExamplesDbContext();
        }

        [TestMethod]
        public void GetOwnedValueTypesForEmployees()
        {
            var employees = dbContext.Employee.Take(10).ToList();

            foreach(var employee in employees)
            {
                Assert.IsNotNull(employee.Address.City);
                Assert.IsNotNull(employee.Address.State);
                Assert.IsNotNull(employee.Address.StreetAddress);
                Assert.IsNotNull(employee.Address.ZipCode);
                Assert.IsNotNull(employee.Name.FirstName);
                Assert.IsNotNull(employee.Name.LastName);
                Assert.IsNotNull(employee.Name.FullName);
            }
        }

        [TestMethod]
        public void GetOwnedValueTypesForContractors()
        {
            var contractors = dbContext.Contractor.Take(10).ToList();

            foreach (var contractor in contractors)
            {
                Assert.IsNotNull(contractor.Address.City);
                Assert.IsNotNull(contractor.Address.State);
                Assert.IsNotNull(contractor.Address.StreetAddress);
                Assert.IsNotNull(contractor.Address.ZipCode);
                Assert.IsNotNull(contractor.Name.FirstName);
                Assert.IsNotNull(contractor.Name.LastName);
                Assert.IsNotNull(contractor.Name.FullName);
            }
        }
    }
}
