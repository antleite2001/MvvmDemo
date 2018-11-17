using System;
using System.Windows.Input;

namespace DemoApp.ViewModel
{
  public interface IWorkspaceViewModel
  {
    ICommand CloseCommand { get; }

    event EventHandler WSVMRequestClose;
  }
}