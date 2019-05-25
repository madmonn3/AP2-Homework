using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exercise3.Controllers
{
    public class DisplayController : ApiController
    {
        // GET display
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET display/127.0.0.1/5400
        //// GET display/flight1/4
        //public string Get([FromBody]string value, int id)
        //{
        //    IPAddress ip;
        //    if (IPAddress.TryParse(value, out ip))
        //        return "value - momentary location, " + ip + ", " + id;
        //    else
        //        return "value - displaying from file, " + value + ", " + id;
        //}

        // GET display/5
        public string Get(int id)
        {
            return "value";
        }

        // POST display
        public void Post([FromBody]string value)
        {
        }

        // PUT display/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
