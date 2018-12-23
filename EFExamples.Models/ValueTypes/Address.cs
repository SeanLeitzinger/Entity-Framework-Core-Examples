using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Models.ValueTypes
{
    public class Address : ValueObject
    {
        public string StreetAddress { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }

        private Address()
        {

        }

        public Address(string streetAddres, string city, string state, string zipCode)
        {
            StreetAddress = streetAddres;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StreetAddress;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}
