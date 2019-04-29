using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class ControlScreenVM : BaseNotify
    {
        //#region Properties
        //#region Script
        //private string script;
        //public string Script
        //{
        //    get
        //    {
        //        return script;
        //    }

        //    set
        //    {
        //        script = value;
        //        this.NotifyPropertyChanged("Script");
        //    }
        //}
        //#endregion

        //#region Throttle
        //private double throttle;

        //public double Throttle
        //{
        //    get
        //    {
        //        return throttle;
        //    }
        //    set
        //    {
        //        throttle = value;
        //        this.NotifyPropertyChanged("Throttle");
        //    }
        //}
        //#endregion

        //#region Rudder
        //private double rudder;

        //public double Rudder
        //{
        //    get
        //    {
        //        return rudder;
        //    }
        //    set
        //    {
        //        rudder = value;
        //        this.NotifyPropertyChanged("Rudder");
        //    }
        //}
        //#endregion

        //public Socket CommandsSock { get; set; }
        //#endregion

        //#region Commands
        //#region OkCommand
        //private ICommand okCommand;
        //public ICommand OkCommand {
        //    get
        //    {
        //        if (okCommand == null)
        //        {
        //            okCommand = new CommandHandler(delegate
        //            {
        //                CommandsSock.Send(Encoding.ASCII.GetBytes(Script));
        //            });
        //        }
        //        return okCommand;
        //    }
        //}
        //#endregion

        //#region ClearCommand
        //private ICommand clearCommand;
        //public ICommand ClearCommand
        //{
        //    get
        //    {
        //        if (clearCommand == null)
        //        {
        //            clearCommand = new CommandHandler(delegate
        //            {
        //                this.Script = String.Empty;
        //            });
        //        }
        //        return clearCommand;
        //    }
        //}
        //#endregion
        //#endregion
    }
}
