using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.Entities
{
    public sealed class Customer:EntityBase<long>
    {
        public Customer(Email email)
        {
             Email = email;
        }

        public FullName FullName { get; set; }
        public Email Email { get; set; }
        public Adress Adress { get; set; }
    }
}
