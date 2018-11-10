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
      System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Critical;
      if (command == null)
      {
        throw new ArgumentNullException("command");
      }

      base.DisplayName = displayName;
      base.ControlPanelCommandsText= displayName;
      ControlPanelCommandInvoked = command;


      try
      {
        Debug.WriteLine("(5) CommandViewModel: " + displayName + "  " + command.ToString());
      }
      catch (Exception ex)
      {
        Debug.WriteLine("(5) CommandViewModel: " + ex.Message);

      }
    }

    public ICommand ControlPanelCommandInvoked { get; private set; }
  }
}