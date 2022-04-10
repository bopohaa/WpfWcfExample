using ClientExample.Common;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientExample.ViewModels
{
    public class DataViewModel : ViewModelBase, IDisposable
    {
        private readonly IDataService _dataService;

        private readonly ObservableCollectionEx<ServerSample.ContractDto> _contracts;
        public ObservableCollectionEx<ServerSample.ContractDto> Contracts => _contracts;

        private readonly ICommand _loadContracts;
        public ICommand LoadContracts => _loadContracts;

        private bool _loadContractsComplete;
        public bool LoadContractsComplete
        {
            get => _loadContractsComplete;
            set
            {
                if (_loadContractsComplete != value)
                {
                    _loadContractsComplete = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _loadContractsFailed;
        public bool LoadContractFailed
        {
            get => _loadContractsFailed;
            set
            {
                if (_loadContractsFailed != value)
                {
                    _loadContractsFailed = value;
                    OnPropertyChanged();
                }
            }
        }

        public DataViewModel(IDataService data_service)
        {
            _dataService = data_service;

            _contracts = new ObservableCollectionEx<ServerSample.ContractDto>();
            _loadContracts = new RelayAsyncCommand(OnLoadContracts);
        }

        private async Task OnLoadContracts()
        {
            LoadContractsComplete = false;
            LoadContractFailed = false;

            try
            {
                var data = await _dataService.GetDocumentsAsync();

                _contracts.ClearAndAdd(data);
            }
            catch
            {
                LoadContractFailed = true;
            }

            LoadContractsComplete = true;
        }

        public void Dispose()
        {
            _dataService.Dispose();
        }
    }
}
