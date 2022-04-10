﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientExample.Common
{
    public abstract class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}
