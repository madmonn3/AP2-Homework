using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {        
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (App.SettingsWindowVM.CancelCommand.CanExecute(e))
            {
                App.SettingsWindowVM.CancelCommand.Execute(e);
            }
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (App.SettingsWindowVM.ClickCommand.CanExecute(e))
            {
                App.SettingsWindowVM.ClickCommand.Execute(e);
            }
            this.Close();
        }
    }
}
