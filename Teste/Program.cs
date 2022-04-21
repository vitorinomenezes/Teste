using Aplicacao.Services;
using Aplicacao.Services.Entities.Entities;
using Aplicacao.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var _serviceProvider = new ServiceCollection()
              .AddSingleton<INterfaceTradeApp, TradeServices>()
              .AddSingleton<INterfaceCategories, CategoriesServices>()
              .AddSingleton<INterfaceBanks, BankServices>()
              .AddSingleton<INterfaceClients, ClientsServices>()
              .AddSingleton<INterfaceAmounts, AmountsServices>()
              .BuildServiceProvider();
            Console.WriteLine(" ");

            var _serviceCategories = _serviceProvider.GetService<INterfaceCategories>();
            var _serviceBank = _serviceProvider.GetService<INterfaceBanks>();
            var _serviceClients = _serviceProvider.GetService<INterfaceClients>();
            var _serviceTrade = _serviceProvider.GetService<INterfaceTradeApp>();
            var _serviceAmounts = _serviceProvider.GetService<INterfaceAmounts>();

            //Categories
            _serviceCategories.ListRegisters = new List<Categories>();
            _serviceCategories.Load();
            _serviceCategories.List();
            Console.WriteLine(" ");

            //Banks
            _serviceBank.Load();
            _serviceBank.List();

            //Clients
            _serviceClients.Load();
            _serviceClients.ListBanksClients(_serviceBank.ListRegisters);

            //Trade
            _serviceTrade.Load();
            _serviceTrade.ListTradeClients(_serviceClients.ListRegisters, _serviceBank.ListRegisters);

            //Amounts
            _serviceAmounts.Load();
            _serviceAmounts.ListAmountsCategories(_serviceCategories.ListRegisters);

            Console.WriteLine(" ");
            Console.WriteLine(" Question 2  ");
            Console.WriteLine("  I add the propertie IsPoliticallyExposed in my amount object, add conditional"
                       + " if IsPoliticallyExposed is true in my insert,   and validate the boolean this propertie.");
        }
    }
}
