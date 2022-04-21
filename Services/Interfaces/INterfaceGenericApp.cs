using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public interface INterfaceGenericApp<T> where T : class
    {

        public List<T> ListRegisters { get; set; }
        void Load ();
        void Add(T _object);
        void Update(T _object);

        void Delete(T id);

        T GetById(int id);

       List<T> List();


    }
}
