using Aplicacao.Services.Entities.Entities;
using System.Collections.Generic;

namespace Aplicacao.Services.Interfaces
{
    public interface INterfaceAmounts : INterfaceGenericApp<Amounts>
    {
        void ListAmountsCategories(List<Categories> _list, List<Clients> _listClients, List<Trade> _listTrade, List<Bank> _listBanks);
    }
}
