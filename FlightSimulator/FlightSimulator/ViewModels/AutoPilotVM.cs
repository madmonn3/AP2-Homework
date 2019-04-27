using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotVM : BaseNotify
    {
        private string script;
        public string Script
        {
            get
            {
                return script;
            }

            set
            {
                script = value;
                this.NotifyPropertyChanged("Script");
            }
        }

        private ICommand okCommand;

        public ICommand OkCommand {
            get
            {
                if (okCommand != null)
                {
                    okCommand = new CommandHandler(delegate
                    {
                        throw new NotImplementedException();
                    });
                }
                return okCommand;
            }
        }

        private ICommand clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new CommandHandler(delegate
                    {
                        this.Script = String.Empty;
                    });
                }
                return clearCommand;
            }
        }
    }
}
