using System;
using System.Collections.Generic;
using System.Text;

namespace EFExamples.Models.ValueTypes
{
    public class PersonName : ValueObject
    {
        public string FirstName { get; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string LastName { get; }

        private PersonName()
        {

        }

        public PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
