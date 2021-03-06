using Aplicacao.Services.Entities.Entities;
using Aplicacao.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Services
{
    public class BankServices : WriteLines, INterfaceBanks
    {
        public List<Bank> ListRegisters { get; set; }

        public void Add(Bank _object)
        {
            ListRegisters.Add(_object);
        }

        public void Delete(Bank id)
        {
            ListRegisters.Remove(id);
        }

        public Bank GetById(int id)
        {
            return ListRegisters.Find(x => x.Id == id);
        }

        public List<Bank> List()
        {
            Console.WriteLine("  Load the Banks. ");
            WriteLine();
            foreach (Bank item in ListRegisters.OrderBy(x => x.Id))
            {
                Console.WriteLine("  " + String.Format(" {0} {1}", item.Id, item.NameBank));
            }
            WriteLine();
            return ListRegisters;
        }

        public void Load()
        {
            ListRegisters = new List<Bank>();
            this.Add(new Bank() { Id = 1, NameBank = "CREDIT SUISSE" });           
            this.TextMenssage = string.Empty;
        }

        public void Update(Bank _object)
        {
            ListRegisters.Find(x => x.Id == _object.Id).NameBank = _object.NameBank;
        }
    }
}
