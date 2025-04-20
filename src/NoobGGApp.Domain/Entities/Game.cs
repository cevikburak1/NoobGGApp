using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Entities
{
    public sealed class Game:EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Game()
        {
            Email userEmail = new Email();
            string email = userEmail;

            Customer customer1 = new Customer("cevikburak1@hotmail.com");
            customer1.Adress.City = "Istanbul";

            Customer customer2 = new Customer("cevikburak1@hotmail.com");
            if (customer1.Adress.City == customer2.Adress.City)
            {

            }
        }
    }
}
