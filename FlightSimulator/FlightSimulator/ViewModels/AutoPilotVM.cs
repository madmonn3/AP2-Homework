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
        private FlightModel model;

        AutoPilotVM(FlightModel m)
        {
            this.model = m;
        }

        #region Properties
        #region Script
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
        #endregion
        #endregion

        #region Commands
        #region OkCommand
        private ICommand okCommand;
        public ICommand OkCommand
        {
            get
            {
                if (okCommand == null)
                {
                    okCommand = new CommandHandler(delegate
                    {
                        model.Send(Script);
                        //CommandsSock.Send(Encoding.ASCII.GetBytes(Script));
                    });
                }
                return okCommand;
            }
        }
        #endregion

        #region ClearCommand
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
        #endregion
        #endregion
    }
}
