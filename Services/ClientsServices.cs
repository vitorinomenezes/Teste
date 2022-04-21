using Aplicacao.Services.Entities.Entities;
using Aplicacao.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Services
{
    public class ClientsServices : WriteLines, INterfaceClients
    {
        public List<Clients> ListRegisters { get; set; }

        public void Add(Clients _object)
        {
            ListRegisters.Add(_object);
        }

        public void Delete(Clients id)
        {
            ListRegisters.Remove(id);
        }

        public Clients GetById(int id)
        {
            return ListRegisters.Find(x => x.Id == id);
        }

        public List<Clients> List()
        {
            Console.WriteLine("  ");
            Console.WriteLine("  Load the Clients. ");
            WriteLine();
            
            foreach (Clients item in ListRegisters.OrderBy(x => x.Id))
            {
                Console.WriteLine("  " + String.Format(" {0} {1}", item.Id, item.NameClient));
            }
            WriteLine();
            return ListRegisters;
        }

        public List<Clients> ListBanksClients(List<Bank> _listBanks)
        {
            Console.WriteLine("  ");
            Console.WriteLine("  Load the Clients x Bank. " + this.TextMenssage);
            WriteLine();
            var clientsXBanks = (from clients in ListRegisters
                               join banks in _listBanks
                               on clients.BankId equals banks.Id
                               select new
                               {
                                   Id = clients.Id,
                                   NameClient = clients.NameClient,
                                   NameBank = banks.NameBank
                               }).ToList();
            foreach (var item in clientsXBanks.OrderBy(x => x.Id))
            {
                Console.WriteLine("  " + String.Format(" {0} - {1} - {2}", item.Id, item.NameBank, item.NameClient));
            }
            WriteLine();
            return ListRegisters;
        }

        public void Load()
        {
            ListRegisters = new List<Clients>();
            this.Add(new Clients() { Id = 1, NameClient = "VITORINO NETO", BankId=1 });
            this.TextMenssage = string.Empty;
        }

        public void Update(Clients _object)
        {
            ListRegisters.Find(x => x.Id == _object.Id).NameClient = _object.NameClient;
        }
    }
}
