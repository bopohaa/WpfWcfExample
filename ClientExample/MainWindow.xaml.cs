using ClientExample.Common;
using ClientExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataViewModel _model;
        public MainWindow()
        {
            App.Resolver.BuildUp(this);

            InitializeComponent();

            if (_model.LoadContracts.CanExecute(null))
                _model.LoadContracts.Execute(null);
        }

        [Unity.InjectionMethod]
        public void InitializeDependencies(DataViewModel data)
        {
            _model = data;
            DataContext = data;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _model?.Dispose();
            _model = null;
        }
    }
}
