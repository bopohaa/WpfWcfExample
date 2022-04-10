using ClientExample.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientExample.Bl
{
    public class DataService : IDataService
    {
        private readonly ClientContainer<ServerSample.IGetDataService> _getDataService;

        public DataService(ClientContainer<ServerSample.IGetDataService> get_data_sevice)
        {
            _getDataService = get_data_sevice;
        }

        public async Task<IEnumerable<ServerSample.ContractDto>> GetDocumentsAsync()
        {
            var client = _getDataService.GetClient();
            var result = await Task.Factory.FromAsync(
                (cb, s) => client.BeginGetContracts(cb, s),
                r => client.EndGetContracts(r), null).ConfigureAwait(false);

            return result;
        }

        public void Dispose()
        {
            _getDataService.Dispose();
        }
    }
}
