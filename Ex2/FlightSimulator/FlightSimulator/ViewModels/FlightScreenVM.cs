using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightScreenVM : BaseNotify
    {

        private FlightModel model;

        public FlightScreenVM(FlightModel m)
        {
            this.model = m;
            model.UpdateListeners += UpdateParams;
        }

        public Socket InfoSock { get; set; }
        #region Commands
        #region SettingsCommand
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
        #endregion

        #region ConnectCommand
        private ICommand conncetCommand;
        public ICommand ConnectCommand
        {
            get
            {
                if (conncetCommand == null)
                {
                    conncetCommand = new CommandHandler(delegate
                    {
                        model.ConnectAsServer(App.SettingsWindowVM.FlightInfoPort);
                        model.ConnectAsClient(App.SettingsWindowVM.FlightServerIP, App.SettingsWindowVM.FlightCommandPort);
                    });
                }
                return conncetCommand;
            }
        }
        #endregion
        #endregion

        private double lon;
        public double Lon
        {
            get
            {
                return model.Lon;
            }

            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
        public double Lat
        {
            get
            {
                return model.Lat;
            }

            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        private void UpdateParams(double lon, double lat)
        {
            Lon = lon;
            Lat = lat;
        }
    }
}
