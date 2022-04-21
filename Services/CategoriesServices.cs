using Aplicacao.Services.Entities.Entities;
using Aplicacao.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Services
{
    public class CategoriesServices : WriteLines, INterfaceCategories
    {
        public List<Categories> ListRegisters { get; set; }

        public void Add(Categories _object)
        {
            this.TextMenssage = "after add categorie.";
            ListRegisters.Add(_object);
        }

        public void Delete(Categories id)
        {
            this.TextMenssage = "after delete categorie.";
            ListRegisters.Remove(id);
        }

        public Categories GetById(int id)
        {
            return ListRegisters.Find(x => x.Id == id);
        }

        public List<Categories> List()
        {
            Console.WriteLine("  Load my categories. "+ this.TextMenssage);
            WriteLine();
            foreach (Categories item in ListRegisters.OrderBy(x => x.Id))
            {
                Console.WriteLine("  " + String.Format(" {0} {1}", item.Id, item.NameCategories));
            }
            WriteLine();
            return ListRegisters;
        }

        public void Load()
        {            
            ListRegisters = new List<Categories>();
            this.Add(new Categories() { Id = 1, NameCategories = "EXPIRED" });
            this.Add(new Categories() { Id = 2, NameCategories = "HIGHRISK" });
            this.Add(new Categories() { Id = 3, NameCategories = "MEDIUMRISK" });
            this.Add(new Categories() { Id = 4, NameCategories = "PEP" });
            this.TextMenssage = string.Empty;
        }

        public void Update(Categories Objeto)
        {
            this.TextMenssage = "after Edit categories.";
            ListRegisters.Find(x => x.Id == Objeto.Id).NameCategories= Objeto.NameCategories;
         }
    }
}
