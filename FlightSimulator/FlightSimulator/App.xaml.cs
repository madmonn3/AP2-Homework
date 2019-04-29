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

        private static AutoPilotVM autoPilotVM;
        public static AutoPilotVM AutoPilotVM
        {
            get
            {
                if (autoPilotVM == null)
                {
                    autoPilotVM = new AutoPilotVM(FlightModel);
                }
                return autoPilotVM;
            }
        }

        private static ManualVM manualVM;
        public static ManualVM ManualVM
        {
            get
            {
                if (manualVM == null)
                {
                    manualVM = new ManualVM(FlightModel);
                }
                return manualVM;
            }
        }

        private static FlightScreenVM flightScreenVM;
        public static FlightScreenVM FlightScreenVM
        {
            get
            {
                if (flightScreenVM == null)
                {
                    flightScreenVM = new FlightScreenVM(FlightModel);
                }
                return flightScreenVM;
            }
        }

        private static FlightModel flightModel;
        public static FlightModel FlightModel
        {
            get
            {
                if (flightModel == null)
                {
                    flightModel = new FlightModel();
                }
                return flightModel;
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
            FlightModel.Close();
            base.OnExit(e);
        }



    }
}
