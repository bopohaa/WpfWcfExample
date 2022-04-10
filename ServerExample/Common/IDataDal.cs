using ServerExample.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerExample.Common
{
    public interface IDataDal : IDisposable
    {
        IEnumerable<Contract> SelectContracts();
    }
}
