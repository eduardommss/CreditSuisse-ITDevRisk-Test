using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Interfaces.Entities
{
    internal interface ITrade
    {
        public int ID { get; }
        public double Value { get;  }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }
    }
}
