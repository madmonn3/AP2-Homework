using System.Net.Sockets;
using System.Text;

namespace FlightSimulator.Model
{
    public class FlightModel
    {
        #region Properties
        public Socket InfoSock { get; set; }
        public Socket CommandsSock { get; set; }
        #endregion

        public void Send(string s)
        {
            CommandsSock.Send(Encoding.ASCII.GetBytes(s));
        }

        public Socket ConnectAsServer(int flightInfoPort)
        {
            if (InfoSock != null)
            {
                InfoSock.Close();
            }


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
            return InfoSock;
        }
    }
}
