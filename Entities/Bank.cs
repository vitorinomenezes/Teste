using System.Collections.Generic;

namespace Aplicacao.Services.Entities.Entities
{
    public class Bank : Base
    {      
        public string NameBank { get; set; }
        public List<Trade> ListTrade { get; set; }
    }
}
