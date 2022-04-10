using ServerExample.Common;
using ServerExample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Transactions;

namespace ServerExample.Bl
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class DataService : IGetDataService
    {
        public readonly SimpleFactory<IDataDal> _dataDalFactory;

        public DataService(SimpleFactory<IDataDal> dal_factory)
        {
            _dataDalFactory = dal_factory;
        }

        public IEnumerable<ContractDto> GetContracts()
        {
            using (var tr = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
            using (var dal = _dataDalFactory.Create())
            {
                var actualAfter = DateTime.UtcNow.AddDays(-60);

                var data = from c in dal.SelectContracts()
                           select new ContractDto() { IsActual = c.UpdateDate > actualAfter, ContractId = c.ContractId, CreateDate = c.CreationDate, UpdateDate = c.UpdateDate };

                tr.Complete();

                return data;
            }
        }
    }
}
