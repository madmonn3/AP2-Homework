using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FlightSimulator.Model
{
    public delegate void Updater(double lon, double lat);
    public class FlightModel
    {
        #region Properties
        public Socket InfoSock { get; set; }
        public Socket CommandsSock { get; set; }

        public event Updater UpdateListeners;

        public double Lon { get; set; }

        public double Lat { get; set; }

        public bool Stop { set; get; }

        #endregion

        public void Send(string s)
        {
            s = s + "\r\n\r\n";
            CommandsSock?.Send(Encoding.ASCII.GetBytes(s));
        }

        public void Close()
        {
            this.CommandsSock?.Close();
            this.InfoSock?.Close();
        }

        public Socket ConnectAsServer(int flightInfoPort)
        {
            InfoSock?.Close();
            try
            {
                Socket client, listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, flightInfoPort);
                listener.Bind(endPoint);
                listener.Listen(5);

                client = listener.Accept();
                //System.Windows.Forms.MessageBox.Show("Connected to client: " + client.RemoteEndPoint);
                InfoSock = client;
                Thread t = new Thread(UpdateParameters);
                t.Start();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Connecting as server failed");
            }
            return InfoSock;
        }

        public Socket ConnectAsClient(string flightServerIP, int flightCommandPort)
        {
            try
            {
                Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
                server.Connect(flightServerIP, flightCommandPort);
                CommandsSock = server;
                //System.Windows.Forms.MessageBox.Show("Connected to server: " + server.RemoteEndPoint);
                Stop = false;
                
            } catch(Exception e)
            {
                //System.Windows.Forms.MessageBox.Show("Connecting as client failed");
            }
            return CommandsSock;
        }

        private void UpdateParameters()
        {
            while (!Stop)
            {
                Byte[] buffer = new Byte[16384];
                InfoSock.Receive(buffer);
                String received = Encoding.Default.GetString(buffer);
                String[] values = received.Split(',');
                if (values.Length >= 2)
                {
                    Lon = Double.Parse(values[0]);
                    Lat = Double.Parse(values[1]);
                    UpdateListeners?.Invoke(Lon, Lat);
                }
                Thread.Sleep(100);
            }
        }
    }
}
