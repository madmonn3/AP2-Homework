using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using FlightSimulator.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static SettingsWindowVM settingsWindowVM;
        public static SettingsWindowVM SettingsWindowVM
        {
            get
            {
                if (settingsWindowVM == null)
                {
                    settingsWindowVM = new SettingsWindowVM(ApplicationSettingsModel.Instance);
                }
                return settingsWindowVM;
            }
        }

        private static ControlScreenVM controlScreenVM;
        public static ControlScreenVM ControlScreenVM
        {
            get
            {
                if (controlScreenVM == null)
                {
                    controlScreenVM = new ControlScreenVM();
                }
                return controlScreenVM;
            }
        }

        private static FlightScreenVM flightScreenVM;
        public static FlightScreenVM FlightScreenVM
        {
            get
            {
                if (flightScreenVM == null)
                {
                    flightScreenVM = new FlightScreenVM();
                }
                return flightScreenVM;
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow myWindow = new MainWindow();
            myWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ControlScreenVM.CommandsSock.Close();
            FlightScreenVM.InfoSock.Close();
            base.OnExit(e);
        }
    }
}
