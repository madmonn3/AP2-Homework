using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Commands
{
    class ClearCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<string> clearAction;

        public ClearCommand()
        {
            clearAction = ClearAction;
        } 

        public void ClearAction(string s)
        {
            s = "";
        }

        public bool CanExecute(object parameter)
        {
            // can always be executed:
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string)
                clearAction.Invoke((string)parameter);
            else
                throw new Exception("clear command didn't get string! got <<" + parameter.ToString() + ">>\n");
        }
    }
}
