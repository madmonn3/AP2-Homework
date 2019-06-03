using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Ex3.Models
{
    public class DisplayModel
    {
        private static DisplayModel instance = null;
        public static DisplayModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DisplayModel();
                }
                return instance;
            }
        }

        public string SCENARIO_FILE
        {
            get
            {
                return "~/App_Data/Flights/{0}.xml";
            }
        }

        private DisplayModel() { }

        public TcpClient Connect(IPAddress ip, int port)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(new IPEndPoint(ip, port));
            } catch (Exception)
            {
                client = null;
            }
            return client;
        }

        private double GetFromServer(TcpClient client, string message)
        {
            Byte[] data = new Byte[1024];
            data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream netStream = client.GetStream();
            netStream.Write(data, 0, data.Length);            
            StreamReader stream = new StreamReader(netStream);
            string val = stream.ReadLine().Split(new string[] { "'" }, StringSplitOptions.None)[1];
            double value = Double.NaN;
            if (Double.TryParse(val, out value))
                return value;
            else
                return Double.NaN;
        }

        public double[] GetMomentaryInformation(TcpClient client)
        {
            double[] values = new double[4];
            try
            {
                values[0] = GetFromServer(client, "get /position/latitude-deg" + Environment.NewLine);
                values[1] = GetFromServer(client, "get /position/longitude-deg" + Environment.NewLine);
                values[2] = GetFromServer(client, "get /controls/engines/current-engine/throttle" + Environment.NewLine);
                values[3] = GetFromServer(client, "get /controls/flight/rudder" + Environment.NewLine);
            }
            catch (Exception)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = Double.NaN;
            }
            if (values[0] == Double.NaN || values[1] == Double.NaN)
                return null;
            else
                return values;
        }
    }
}