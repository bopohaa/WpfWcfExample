using ServerExample.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace ServerExample.Dal
{
    partial class DatabaseContext : IDataDal
    {
        public IEnumerable<Contract> SelectContracts()
        {
            var query = from c in Contracts select c;
            return query.ToArray();
        }
    }
}
