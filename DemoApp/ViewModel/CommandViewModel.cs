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
      //base.ControlPanelCommandsText= displayName;
      ControlPanelCommandInvoked = command;


      try
      {
        Diag.UpdateLog(false,"(5) CommandViewModel: " + displayName + "  " + command.ToString());
      }
      catch (Exception ex)
      {
        Diag.UpdateLog(false,"(5) CommandViewModel: " + ex.Message);

      }
    }

    public ICommand ControlPanelCommandInvoked { get; private set; }
  }
}