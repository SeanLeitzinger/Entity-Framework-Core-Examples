using EFExamples.Data;
using EFExamples.Data.Projections;
using EFExamples.Data.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace EFExamples.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        public static EFExamplesDbContext dbContext;

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
        public async Task GetEmployeeById()
        {
            var employee = await dbContext.Employee.GetEmployeeByIdAsync(EmployeeProjection.EmployeeWithoutDocuments, 300);

            Assert.AreEqual(300, employee.Id);
        }
    }
}
