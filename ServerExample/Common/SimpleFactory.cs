using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerExample.Common
{
    public class SimpleFactory<T>
    {
        private readonly Func<T> _factory;
        public SimpleFactory(Func<T> factory) => _factory = factory;

        public T Create() => _factory();
    }
}
