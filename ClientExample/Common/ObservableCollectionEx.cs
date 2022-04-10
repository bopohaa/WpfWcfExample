using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace ClientExample.Common
{
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        public void AddRange(IEnumerable<T> items)
        {
            this.CheckReentrancy();
            foreach (var item in items)
                this.Items.Add(item);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        public void ClearAndAdd(IEnumerable<T> items)
        {
            this.CheckReentrancy();
            this.Items.Clear();
            foreach (var item in items)
                this.Items.Add(item);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

        }
    }
}
