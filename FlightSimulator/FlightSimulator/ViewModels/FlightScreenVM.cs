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
                        // connect as server
                        // must move to MODEL!!!
                        Socket client, listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
                        EndPoint endPoint = new IPEndPoint(IPAddress.Any, App.SettingsWindowVM.FlightInfoPort);
                        listener.Bind(endPoint);
                        listener.Listen(5);
                        client = listener.Accept();
                        System.Windows.Forms.MessageBox.Show("Connected to client: " + client.RemoteEndPoint);
                        this.InfoSock = client;

                        Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
                        server.Connect(App.SettingsWindowVM.FlightServerIP, App.SettingsWindowVM.FlightCommandPort);
                        App.ControlScreenVM.CommandsSock = server;
                        System.Windows.Forms.MessageBox.Show("Connected to server: " + server.RemoteEndPoint);
                    });
                }
                return conncetCommand;
            }
        }
        #endregion
        #endregion


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
