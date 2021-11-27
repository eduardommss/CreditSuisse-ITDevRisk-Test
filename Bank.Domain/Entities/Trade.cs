using Bank.Domain.Interfaces.Entities;
using System;

namespace Bank.Domain.Entities
{
    public class Trade : ITrade
    {
        public int ID { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
    }
}
