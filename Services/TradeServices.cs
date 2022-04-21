using Aplicacao.Services.Entities.Entities;
using Aplicacao.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Services
{
    public class TradeServices : WriteLines, INterfaceTradeApp
    {
        public List<Trade> ListRegisters { get; set; }

        public void Add(Trade _object)
        {
            this.TextMenssage = "after add Trade.";
            ListRegisters.Add(_object);
        }

        public void Delete(Trade id)
        {
            this.TextMenssage = "after delete trade.";
            ListRegisters.Remove(id);
        }

        public Trade GetById(int id)
        {
            return ListRegisters.Find(x => x.Id == id);
        }

        public List<Trade> List()
        {
            Console.WriteLine("  ");
            Console.WriteLine("  Load the clients of bank. " + this.TextMenssage);
            WriteLine();

            foreach (Trade item in ListRegisters.OrderBy(x => x.Id))
            {
                Console.WriteLine("  " + String.Format(" {0} {1}", item.Id, item.NameTrade));
            }
            WriteLine();
            return ListRegisters;
        }

        public void ListTradeClients(List<Clients> _listClients, List<Bank> _listBanks)
        {
            Console.WriteLine("  ");
            Console.WriteLine("  Load the trade x banks x clients . " + this.TextMenssage);
            WriteLine();
            var clientsXBanks = (from clients in _listClients
                                 join banks in _listBanks
                                 on clients.BankId equals banks.Id
                                 join traders in ListRegisters
                                 on clients.Id equals traders.ClientId
                                 select new
                                 {
                                     Id = traders.Id,
                                     NameTrade = traders.NameTrade,
                                     NameBank=banks.NameBank,
                                     NameClient = clients.NameClient
                                 }).ToList();
            foreach (var item in clientsXBanks.OrderBy(x => x.Id))
            {
                Console.WriteLine("  " + String.Format(" {0} - {1} - {2} - {3}", item.Id, item.NameTrade,item.NameBank, item.NameClient));
            }
            WriteLine();
        }

        public void Load()
        {
            ListRegisters = new List<Trade>();
            this.Add(new Trade() { Id = 1, NameTrade = "PLAN DEAL FLOW", ClientId=1});
            this.TextMenssage = string.Empty;
        }

        public void Update(Trade _object)
        {
            this.TextMenssage = "after Edit client.";
            ListRegisters.Find(x => x.Id == _object.Id).NameTrade = _object.NameTrade;
        }
    }
}
