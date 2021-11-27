using Bank.Domain.Entities;
using Bank.Domain.Interfaces.Services;
using System;
using System.Globalization;

namespace Bank.UI.ConsoleApp.Views
{
    internal class TradeView
    {
        private readonly ITradeService _tradeService;
        private readonly ICategoryService _categoryService;

        public TradeView(ITradeService tradeService, ICategoryService categoryService)
        {
            _tradeService = tradeService;
            _categoryService = categoryService;

            Init();
        }

        private void Init()
        {
            Input();
            Output();
        }

        private void Input()
        {
            Console.WriteLine("Insert a reference date:");
            DateTime referenceDate = ReadDateTime();

            Console.WriteLine();
            Console.WriteLine("Insert the number of trades:");
            int numberOfTrades = ReadInteger();

            for (int i = 1; i <= numberOfTrades; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Insert the trade {i}:");
                _tradeService.Add(ReadTrade());
            }
        }

        private void Output()
        {
            Console.Clear();

            var allTrades = _tradeService.GetAll();

            Console.WriteLine();

            foreach (var trade in allTrades)
            {
                var category = _categoryService.GetCategory(trade);

                Console.WriteLine($"Trade {trade.ID} - {category}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key for exit.");
            Console.ReadKey();
        }

        private DateTime ReadDateTime()
        {
            var date = DateTime.MinValue;

            while (true)
            {
                var dateString = Console.ReadLine();

                if (DateTime.TryParseExact(dateString, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid date, try again.");
                    Console.WriteLine("-> Use this format date mm/dd/yyyy");
                }
            }
        }

        private int ReadInteger()
        {
            int number = 0;

            while (true)
            {
                var numberString = Console.ReadLine();

                if (int.TryParse(numberString, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid number, try again.");
                }
            }
        }

        private Trade ReadTrade()
        {

            while (true)
            {
                var tradeString = Console.ReadLine().Trim();
                var tradeSplit = tradeString.Split(' ');

                if (ValidateTrade(tradeSplit))
                {
                    Trade trade = new Trade();
                    trade.Value = double.Parse(tradeSplit[0]);
                    trade.ClientSector = tradeSplit[1];
                    trade.NextPaymentDate = DateTime.ParseExact(tradeSplit[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    return trade;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid format, try again.");
                    Console.WriteLine("-> Example: 1000 Private 12/20/1999 (Value ClientSector NextPaymentDate)");
                }
            }
        }

        private bool ValidateTrade(string[] tradeSplit)
        {
            double value = 0;
            DateTime nextPaymentDate = DateTime.MinValue;

            if (tradeSplit.Length != 3)
                return false;

            if (!double.TryParse(tradeSplit[0], out value))
                return false;

            if (!tradeSplit[1].Equals("Private") && !tradeSplit[1].Equals("Public"))
                return false;

            if (!DateTime.TryParseExact(tradeSplit[2], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nextPaymentDate))
                return false;

            return true;
        }
    }
}
