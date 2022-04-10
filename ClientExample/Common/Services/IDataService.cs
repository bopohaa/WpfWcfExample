using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientExample.Common
{
    public interface IDataService : IDisposable
    {
        Task<IEnumerable<ServerSample.ContractDto>> GetDocumentsAsync();
    }
}
