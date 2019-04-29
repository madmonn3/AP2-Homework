using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualVM : BaseNotify
    {
        private FlightModel model;

        ManualVM(FlightModel m)
        {
            this.model = m;
        }

        #region Properties 
        #region Throttle
        private double throttle;

        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                this.NotifyPropertyChanged("Throttle");
            }
        }
        #endregion

        #region Rudder
        private double rudder;

        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                this.NotifyPropertyChanged("Rudder");
            }
        }
        #endregion
        #endregion
    }
}
