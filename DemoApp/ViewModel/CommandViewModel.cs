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
      if (command == null)
      {
        throw new ArgumentNullException("command");
      }

      base.xDisplayName = displayName;

      Command = command;
      try
      { Debug.WriteLine("(5) CommandViewModel: " + displayName + "  " + command.ToString()); }
      catch (Exception ex)
      {
        Debug.WriteLine("(5) CommandViewModel: " + ex.Message);

      }
    }

    public ICommand Command { get; private set; }
  }
}