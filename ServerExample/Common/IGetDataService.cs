using ServerExample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ServerExample.Common
{
    [ServiceContract]
    public interface IGetDataService
    {
        [OperationContract]
        IEnumerable<ContractDto> GetContracts();
    }
}
