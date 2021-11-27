using Bank.Domain.Entities;
using Bank.Domain.Interfaces.Repositories;
using Bank.Domain.Interfaces.Services;
using Bank.Domain.Services.Common;

namespace Bank.Domain.Services
{
    public class TradeService : ServiceBase<Trade, ITradeRepository>, ITradeService
    {
        public TradeService(ITradeRepository repository) : base(repository) { }
    }
}
