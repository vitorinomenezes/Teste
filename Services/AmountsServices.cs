
using Aplicacao.Services.Entities.Entities;
using Aplicacao.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Services
{
    public class AmountsServices : WriteLines, INterfaceAmounts
    {
        public List<Amounts> ListRegisters { get; set ; }

        public void Add(Amounts _object)
        {
            _object.CategoriaId = (_object.IsPoliticallyExposed)?4: _object.NextPaymentDate.Date < DateTime.Now.Date ?1:_object.Value> 10000 && _object.ClientSector == "Private" ? 2:3;
           this.TextMenssage = "after add amount.";
            ListRegisters.Add(_object);
        }

        public void Delete(Amounts id)
        {
            this.TextMenssage = "after delete trade.";
            ListRegisters.Remove(id);
        }

        public Amounts GetById(int id)
        {
            return ListRegisters.Find(x => x.Id == id);
        }

        public List<Amounts> List()
        {
            Console.WriteLine("  ");
            Console.WriteLine("  Load the amounts of trade. " + this.TextMenssage);
            WriteLine();

            foreach (Amounts item in ListRegisters.OrderBy(x => x.Id))
            {
                Console.WriteLine("  " + String.Format(" {0} {1} {2} {3} {4} {5}", item.Id, item.Value, item.ClientSector
                    , item.NextPaymentDate, item.NameCategoria, item.CategoriaId));
            }
            WriteLine();
            return ListRegisters;
        }

        public void ListAmountsCategories(List<Categories> _list, List<Clients> _listClients
                                            , List<Trade> _listTrade, List<Bank> _listBanks)
        {
            Console.WriteLine("  ");
            Console.WriteLine("  Load the amounts of trade. " + this.TextMenssage);
            WriteLine();

            var _lists = (from amounts in ListRegisters
                          join categories in _list
                          on amounts.CategoriaId equals categories.Id
                          join trads in _listTrade
                          on amounts.TradeId equals trads.Id
                          join clients in _listClients
                          on trads.ClientId equals clients.Id
                          join banks in _listBanks
                          on clients.BankId equals banks.Id
                          select new
                          {
                              Id = amounts.Id,
                              Value = amounts.Value,
                              ClientSector = amounts.ClientSector,
                              NextPaymentDate = amounts.NextPaymentDate,
                              NameCategoria = categories.NameCategories,
                              NameClient = clients.NameClient,
                              NameBank = banks.NameBank,
                              NameTrade = trads.NameTrade
                          }).ToList();

            foreach (var item in _lists.OrderBy(x => x.Id))
            {
                Console.WriteLine("  " + String.Format(" {0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}", item.Id, item.Value  
                    , item.ClientSector
                    , item.NextPaymentDate, item.NameCategoria, item.NameClient,item.NameTrade, item.NameBank));
            }
            WriteLine();
        }

        public void Load()
        {
            ListRegisters = new List<Amounts>();
            this.Add(new Amounts() { Id = 1, Value = 2000000, ClientSector = "Private", NextPaymentDate = new DateTime(2025, 12, 29), IsPoliticallyExposed=false, TradeId=1 });
            this.Add(new Amounts() { Id = 2, Value = 400000, ClientSector = "Public", NextPaymentDate = new DateTime(2020, 07, 01), IsPoliticallyExposed = false, TradeId = 1 });
            this.Add(new Amounts() { Id = 3, Value = 500000, ClientSector = "Public", NextPaymentDate = new DateTime(2024, 02, 01), IsPoliticallyExposed = false, TradeId = 1 });
            this.Add(new Amounts() { Id = 4, Value = 3000000, ClientSector = "Public", NextPaymentDate = new DateTime(2023, 10, 26), IsPoliticallyExposed = false, TradeId = 1 });
            this.Add(new Amounts() { Id = 5, Value = 1000000, ClientSector = "Public", NextPaymentDate = new DateTime(2023, 10, 26), IsPoliticallyExposed = true, TradeId = 1 });
            this.TextMenssage = string.Empty;
        }

        public void Update(Amounts _object)
        {
            this.TextMenssage = "after Edit amounts.";
         //   ListRegisters.Find(x => x.Id == _object.Id).NameClient = _object.NameClient;
        }
    }
}
