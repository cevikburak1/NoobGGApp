using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Domain.ValueObjects
{
    public record struct CustomerId
    {
        public long Value { get; init; }

        public CustomerId(long value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Customer ID must be a positive number.");
            }
            Value = value;
        }
    }
}
