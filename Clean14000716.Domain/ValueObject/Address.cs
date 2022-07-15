using System.Collections.Generic;

namespace Clean14000716.Domain.ValueObject.Base
{
    public class Address : ValueObject
    {
        public string City { get; set; }
        public string Street { get; set; }

        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return City;
            yield return Street;
        }
    }
}