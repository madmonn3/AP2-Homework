using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class ManualVM : BaseNotify
    {
        private FlightModel model;

        public ManualVM(FlightModel m)
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
                this.model.Send("set controls/engines/current-engine/throttle " + (double)throttle / 100);
                this.NotifyPropertyChanged("Throttle");
            }
        }

        private double aileron;
        public double Aileron
        {
            get
            {
                return aileron;
            }

            set
            {
                aileron = value;
                this.model.Send("set controls/flight/aileron " + (double)aileron / 124);
                NotifyPropertyChanged("Aileron");
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
                this.model.Send("set controls/flight/rudder " + (double)rudder / 100);
                this.NotifyPropertyChanged("Rudder");
            }
        }
        #endregion

        private double elevator;
        public double Elevator
        {
            get
            {
                return elevator;
            }

            set
            {
                {
                    elevator = value;
                    this.model.Send("set controls/flight/elevator " + (double)elevator / 124);
                    NotifyPropertyChanged("Elevator");
                }
            }
        }
        #endregion
    }
}
