using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightScreenVM : BaseNotify
    {
        private ICommand settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                if (settingsCommand == null)
                {
                    settingsCommand = new CommandHandler(delegate
                    {
                        SettingsWindow s = new SettingsWindow();
                        s.ShowDialog();
                    });
                }
                return settingsCommand;
            }
        }

        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }
    }
}
