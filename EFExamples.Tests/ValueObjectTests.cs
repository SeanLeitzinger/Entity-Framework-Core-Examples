using EFExamples.Data;
using EFExamples.Models.Entities;
using EFExamples.Models.ValueTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFExamples.Tests
{
    [TestClass]
    public class ValueObjectTests
    {
        private static EFExamplesDbContext dbContext;

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
        public void GetOwnedValueObjectsForEmployees()
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
        public void GetOwnedValueObjectsForContractors()
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

        [TestMethod]
        public void AddNewContractor()
        {
            var contractor = ModelFakes.ContractorFake.Generate();
            var vendor = dbContext.Vendor.FirstOrDefault();
            contractor.VendorId = vendor.Id;
            dbContext.Contractor.Add(contractor);
            dbContext.SaveChanges();

            Assert.AreNotEqual(0, contractor.Id);
        }

        [TestMethod]
        public void UpdateContractorAddress()
        {
            var contractor = dbContext.Contractor.FirstOrDefault();
            contractor.Address = ModelFakes.ContractorFake.Generate().Address;
            dbContext.Contractor.Update(contractor);
            dbContext.SaveChanges();
            dbContext.DetachAllEntities();

            var updatedContractor = dbContext.Contractor.FirstOrDefault(m => m.Id == contractor.Id);
            var areEqual = contractor.Address == updatedContractor.Address;
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void CheckValueObjectEquality()
        {
            var address1 = ModelFakes.ContractorFake.Generate().Address;
            var address2 = ModelFakes.ContractorFake.Generate().Address;

            Assert.IsFalse(address1 == address2);

            var address3 = new Address(address1.StreetAddress, address1.City, address1.State, address1.ZipCode);

            Assert.IsTrue(address1 == address3);
        }
    }
}
