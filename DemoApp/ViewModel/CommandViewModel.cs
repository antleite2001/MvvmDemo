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
      Diag.UpdateLog("(789056\tCommandViewModel( )\tbase.ViewModelBaseInstanceName \t" + base.ViewModelBaseInstanceName);

      ControlPanelHyperlinkInvokeCommand = command;


      try
      {
        Diag.UpdateLog("(6)\t"+this.GetType().FullName + ";\t" +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";\t" + displayName + ";\t" + command.ToString());
      }
      catch (Exception ex)
      {
        Diag.UpdateLog("(6)\t"+this.GetType().FullName + ";\t" +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";\t" + ex.Message);

      }
    }

    public ICommand ControlPanelHyperlinkInvokeCommand { get; private set; }
  }
}