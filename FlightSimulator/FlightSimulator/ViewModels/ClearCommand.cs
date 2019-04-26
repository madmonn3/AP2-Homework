using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class ClearCommand : INotifyPropertyChanged, ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        private string s;

        public string AutoPilotScript
        {
            get
            {
                return s;
            }

            set
            {
                if (value == "K")
                    System.Windows.Forms.MessageBox.Show("K!!!");
                s = value;
            }
        }

        public ClearCommand()
        {
            AutoPilotScript = "hello";
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void NotifyPropertyChanged(string propName)
        {
            System.Windows.Forms.MessageBox.Show("CHACONNTECTEDNGED!");
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
