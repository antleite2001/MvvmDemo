using System;
using System.Diagnostics;
using System.Windows.Input;

namespace DemoApp.ViewModel
{
  /// <summary>
  /// Represents an actionable item displayed by a View.
  /// </summary>
  public class CommandViewModel : ViewModelBase
  {
    public CommandViewModel(string displayName, ICommand command)
    {
      Diag.DataBindingPresentation();
      if (command == null)
      {
        throw new ArgumentNullException("command");
      }

      base.ViewModelBaseInstanceName = displayName;
      ControlPanelHyperlinkInvokeCommand = command;


      try
      {
        Diag.UpdateLog(false,"(6) "+this.GetType().FullName + "; " +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";   " + displayName + "  " + command.ToString());
      }
      catch (Exception ex)
      {
        Diag.UpdateLog(false,"(6) "+this.GetType().FullName + "; " +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";   " + ex.Message);

      }
    }

    public ICommand ControlPanelHyperlinkInvokeCommand { get; private set; }
  }
}