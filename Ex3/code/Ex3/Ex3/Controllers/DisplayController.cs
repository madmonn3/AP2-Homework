using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using Ex3.Models;
using Newtonsoft.Json.Linq;

namespace Ex3.Controllers
{
    public class DisplayController : Controller
    {
        private bool IsIPAddress(string ip)
        {
            string[] vals = ip.Split('.');
            if (vals.Length != 4)
                return false;
            int result;
            for (int i = 0; i < vals.Length; i++)
                if (!Int32.TryParse(vals[i], out result))
                    return false;
            IPAddress ipaddr;
            return IPAddress.TryParse(ip, out ipaddr);
        }

        [Route("display/{ip}/{port}")]
        [Route("display/{ip}/{port}/{rate}")]
        public ActionResult ConnectAndGetLocation(string ip, int port, int rate = 0)
        {
            if (IsIPAddress(ip))
            {
                IPAddress ipaddr = IPAddress.Parse(ip);
                TcpClient client = DisplayModel.Instance.Connect(ipaddr, port);
                double[] values = DisplayModel.Instance.GetMomentaryInformation(client);
                if (values != null)
                {
                    ViewBag.lat = values[0];
                    ViewBag.lon = values[1];
                }
                if (rate == 0)
                {
                    return View("MomentaryLocation");
                }
                else if (rate > 0)
                {
                    ViewBag.ip = ip;
                    ViewBag.port = port;
                    ViewBag.rate = rate;
                    return View("DisplayRoute");
                }
                else
                {
                    return null;
                }
            }
            else
            {
                string fileName = ip;
                int readingRate = port;
                ViewBag.rate = readingRate;
                ViewBag.fileName = fileName;
                return View("LoadFromFile");
            }
        }

        [Route("save/{ip}/{port}/{rate}/{limit}/{filename}")]
        public ActionResult ConnectAndSave(string ip, int port, int rate, int limit, string filename)
        {
            if (IsIPAddress(ip))
            {
                IPAddress ipaddr = IPAddress.Parse(ip);
                TcpClient client = DisplayModel.Instance.Connect(ipaddr, port);
                double[] values = DisplayModel.Instance.GetMomentaryInformation(client);
                if (values != null)
                {
                    ViewBag.lat = values[0];
                    ViewBag.lon = values[1];
                }
                ViewBag.ip = ip;
                ViewBag.port = port;
                ViewBag.rate = rate;
                ViewBag.limit = limit;
                ViewBag.filename = filename;
                return View("SaveRoute");
            }
            else
                return null;
        }

        [Route("display/GetFlightInfo")]
        public string GetFlightInfo(string ip, int port)
        {
            IPAddress ipaddr = IPAddress.Parse(ip);
            TcpClient client = DisplayModel.Instance.Connect(ipaddr, port);
            double[] info = DisplayModel.Instance.GetMomentaryInformation(client);
            return InfoToXml(info);
        }

        [Route("display/SaveXml")]
        [HttpPost]
        public bool SaveXml(string xml, string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(String.Format(DisplayModel.Instance.SCENARIO_FILE, fileName));
            if (System.IO.File.Exists(path))
            {
                string allLines = System.IO.File.ReadAllText(path);
                
                if (allLines == String.Empty)
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
                    file.WriteLine(xml);
                    file.Flush();
                    file.Close();
                }
                else
                {
                    System.IO.File.Delete(path);
                    string newXml;
                    var xml1Descendants = XDocument.Parse(allLines).Descendants("Locations");
                    var xml2Descendants = XDocument.Parse(xml).Descendants("Locations");
                    var combinedUnique = xml1Descendants.Descendants("Location").Concat(xml2Descendants.Descendants("Location"));
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(new XElement("Locations", combinedUnique.ToArray()).CreateReader());
                    using (var stringWriter = new StringWriter())
                    using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                    {
                        xmlDocument.WriteTo(xmlTextWriter);
                        xmlTextWriter.Flush();
                        newXml = stringWriter.GetStringBuilder().ToString();
                    }
                    System.IO.File.AppendAllText(path, newXml);
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }

        [Route("display/GetXml")]
        [HttpPost]
        public string GetXml(string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(String.Format(DisplayModel.Instance.SCENARIO_FILE, fileName));
            if (System.IO.File.Exists(path))
            {
                return System.IO.File.ReadAllText(path);
            }
            else
            {
                return null;
            }
        }

        private string InfoToXml(double[] info)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(sb, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Locations");
            writer.WriteStartElement("Location");
            writer.WriteAttributeString("latitude", info[0].ToString());
            writer.WriteAttributeString("longitude", info[1].ToString());
            writer.WriteAttributeString("throttle", info[2].ToString());
            writer.WriteAttributeString("rudder", info[3].ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return sb.ToString();
        }
    }
}