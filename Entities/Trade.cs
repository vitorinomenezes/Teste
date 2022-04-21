using System;


namespace Aplicacao.Services.Entities.Entities
{
    public class Trade : Base
    {
        public long ClientId { get; set; }
        public string NameTrade { get; set; }
        public DateTime ReferenceDate { get; set; }

    }
}
