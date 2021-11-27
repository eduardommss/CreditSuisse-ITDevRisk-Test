using Bank.Domain.Entities;
using Bank.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Bank.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private static readonly Dictionary<string, Func<Trade, bool>> CategoryCollection
            = new Dictionary<string, Func<Trade, bool>>
        {
            { "EXPIRED", trade => (DateTime.Now.Date - trade.NextPaymentDate.Date).TotalDays > 30 },
            { "HIGHRISK", trade => trade.Value > 1000000 && trade.ClientSector.Equals("Private") },
            { "MEDIUMRISK", trade => trade.Value > 1000000 && trade.ClientSector.Equals("Public") }
        };

        public string GetCategory(Trade trade)
        {
            foreach (var category in CategoryCollection)
            {
                if (category.Value(trade))
                    return category.Key;
            }

            return "CATEGORY NOT FOUND!!!";
        }
    }
}
