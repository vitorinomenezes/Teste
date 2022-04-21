
using Aplicacao.Services.Entities.Entities;
using System.Collections.Generic;

namespace Aplicacao.Services.Interfaces
{
    public interface INterfaceTradeApp : INterfaceGenericApp<Trade>
    {
        public void ListTradeClients(List<Clients> _listClients, List<Bank> _listBanks);
    }
}
