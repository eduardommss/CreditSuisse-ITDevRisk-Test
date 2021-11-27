using Bank.Domain.Entities;
using Bank.Domain.Helpers;
using Bank.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Bank.Infraestructure.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private DataTable dtTrades;

        public TradeRepository()
        {
            dtTrades = new DataTable();
            dtTrades.Columns.Add(new DataColumn("ID", typeof(long))
            {
                Unique = true,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            });
            dtTrades.Columns.Add(new DataColumn("Value", typeof(double)));
            dtTrades.Columns.Add(new DataColumn("ClientSector", typeof(string)));
            dtTrades.Columns.Add(new DataColumn("NextPaymentDate", typeof(DateTime)));
        }

        public void Add(Trade entity)
        {
            var newRow = dtTrades.NewRow();
            newRow["Value"] = entity.Value;
            newRow["ClientSector"] = entity.ClientSector;
            newRow["NextPaymentDate"] = entity.NextPaymentDate;

            dtTrades.Rows.Add(newRow);
        }

        public void Remove(Trade entity)
        {
            var row = dtTrades.Select($"ID = {entity.ID}");

            if (row is null)
                throw new Exception("Trade is not found");

            row[0].Delete();
        }
        public IEnumerable<Trade> Find(Expression<Func<Trade, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Trade GetById(int id)
        {
            var row = dtTrades.Select($"ID = {id}");

            if (row is null)
                throw new Exception("Trade is not found");

            return row[0].ToObject<Trade>();
        }

        public void Update(Trade entity)
        {
            var row = dtTrades.Select($"ID = {entity.ID}");

            if (row is null)
                throw new Exception("Trade is not found");

            row[0]["Value"] = entity.Value;
            row[0]["ClientSector"] = entity.ClientSector;
            row[0]["NextPaymentDate"] = entity.NextPaymentDate;
        }

        public IEnumerable<Trade> GetAll()
        {
            var rows = dtTrades.Select();

            foreach (var row in rows)
            {
                yield return row.ToObject<Trade>();
            }
        }
    }
}
