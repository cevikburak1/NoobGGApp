using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.ValueObjects
{
    public sealed record  Adress
    {
        public Adress(string street,string city,string country,string zipCode,string state,string apartment)
        {
            Street = street;
            City = city;
            Country = country;
            ZipCode = zipCode;
            State = state;
            Aparment = apartment;
        }
        public string State { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Aparment { get; set; }
    }
}
