using Aplicacao.Services.Entities.Entities;
using System.Collections.Generic;

namespace Aplicacao.Services.Interfaces
{
    public interface INterfaceClients : INterfaceGenericApp<Clients>
    {
        List<Clients> ListBanksClients(List<Bank> _listBanks);
    }
}
