using Aplicacao.Services.Entities.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Services.Entities.Entities
{
    public class Amounts : Base
    {
        public long TradeId { get; set; }
        public double Value { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public bool IsPoliticallyExposed { get; set; }
        public string ClientSector { get; set; }
        public long CategoriaId { get; set; }

        [NotMapped]
        public string NameCategoria { get; set; }

    }
}
