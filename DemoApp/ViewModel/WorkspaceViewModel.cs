using System;
using System.Windows.Input;

namespace DemoApp.ViewModel
{
  /// <summary>
  /// This ViewModelBase subclass requests to be removed 
  /// from the UI when its CloseCommand executes.
  /// This class is abstract.
  /// </summary>
  public abstract class WorkspaceViewModel : ViewModelBase
  {
    #region Fields

    private RelayCommand _closeCommand;

    #endregion // Fields

    #region Constructor

    protected WorkspaceViewModel()
    {
      Diag.DataBindingPresentation();

    }

    #endregion // Constructor

    #region CloseCommand

    /// <summary>
    /// Returns the command that, when invoked, attempts
    /// to remove this workspace from the user interface.
    /// </summary>
    public ICommand CloseCommand
    {
      get
      {
        if (_closeCommand == null)
        {
          //Register CloseCommand in a RelayCommand
          _closeCommand = new RelayCommand(param => OnWorkSpaceViewModelRequestClose());
        }

        try
        {
          Diag.UpdateLog( "(15) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t");
        }
        catch (Exception ex)
        {
          Diag.UpdateLog( "(15) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);
        }
        return _closeCommand;
      }
    }

    #endregion // CloseCommand

    #region RequestClose [event]

    /// <summary>
    /// Raised when this workspace should be removed from the UI.
    /// </summary>
    public event EventHandler WorkSpaceViewModelRequestClose;

    private void OnWorkSpaceViewModelRequestClose()
    {
      try
      {
        Diag.UpdateLog( "(17) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t");
      }
      catch (Exception ex)
      {
        Diag.UpdateLog( "(17) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);
      }
      WorkSpaceViewModelRequestClose?.Invoke(this, EventArgs.Empty);
    }

    #endregion // RequestClose [event]
  }
}