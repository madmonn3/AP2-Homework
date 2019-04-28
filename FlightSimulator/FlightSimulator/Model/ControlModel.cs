using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ControlModel
    {
        void Send(Socket socket, string s)
        {
            socket.Send(Encoding.ASCII.GetBytes(s));
        }

        void Connect(int flightInfoPort)
        {


            /*
             *                         // connect as server
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
             */
        }
    }
}
