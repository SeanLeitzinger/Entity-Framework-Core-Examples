using Bogus;
using EFExamples.Models;
using EFExamples.Models.Entities;
using EFExamples.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Tests
{
    public static class ModelFakes
    {
        public static Faker<Company> CompanyFake { get; set; }
        public static Faker<Contractor> ContractorFake { get; set; }
        public static Faker<Employee> EmployeeFake { get; set; }
        public static Faker<Vendor> VendorFake { get; set; }

        static ModelFakes()
        {
            BuildCompanyFaker();
            BuildContractorFaker();
            BuildEmployeeFaker();
            BuildVendorFaker();
        }

        private static void BuildCompanyFaker()
        {
            CompanyFake = new Faker<Company>();
            CompanyFake.RuleFor(m => m.Name, r => r.Company.CompanyName());
        }

        public static void BuildContractorFaker()
        {
            ContractorFake = new Faker<Contractor>();
            ContractorFake.RuleFor(m => m.Name, r => new PersonName(r.Name.FirstName(), r.Name.LastName()));
            ContractorFake.RuleFor(m => m.Address, r => new Address(r.Address.StreetAddress(), r.Address.City(), r.Address.State(), r.Address.ZipCode()));
            ContractorFake.RuleFor(m => m.DateOfBirth, r => r.Person.DateOfBirth.Date);
        }


        private static void BuildEmployeeFaker()
        {
            EmployeeFake = new Faker<Employee>();
            EmployeeFake.RuleFor(m => m.Name, r => new PersonName(r.Name.FirstName(), r.Name.LastName()));
            EmployeeFake.RuleFor(m => m.Address, r => new Address(r.Address.StreetAddress(), r.Address.City(), r.Address.State(), r.Address.ZipCode()));
            EmployeeFake.RuleFor(m => m.DateOfBirth, r => r.Person.DateOfBirth.Date);
        }

        private static void BuildVendorFaker()
        {
            VendorFake = new Faker<Vendor>();
            VendorFake.RuleFor(m => m.Name, r => r.Company.CompanyName());
        }
    }
}
