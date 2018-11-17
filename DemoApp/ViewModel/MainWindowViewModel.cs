using DemoApp.DataAccess;
using DemoApp.Model;
using DemoApp.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace DemoApp.ViewModel
{
  /// <summary>
  /// The ViewModel for the application's main window.
  /// </summary>
  public class MainWindowViewModel : ToggleButtonViewModel
  {
    #region Fields

    private ReadOnlyCollection<CommandViewModel> _commands;
    private readonly CustomerRepository _customerRepository;
    private ObservableCollection<WorkspaceViewModel> _workspaces;

    #endregion // Fields

    #region Constructor

    public MainWindowViewModel(string customerDataFile)
    {

      Diag.DataBindingPresentation();


      base.ViewModelBaseInstanceName = Strings.MainWindowViewModel_DisplayName;
      Diag.UpdateLog("(451289)\tMainWindowViewModel()\tbase.ViewModelBaseInstanceName\t" + 
        base.ViewModelBaseInstanceName);

      _customerRepository = new CustomerRepository(customerDataFile);
       

      try
      {
        Diag.UpdateLog("(8)\t" + GetType().FullName + ";\t" + 
          System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" +
          base.ViewModelBaseInstanceName + ";\t" +
          _customerRepository.ToString());
      }
      catch (Exception ex)
      {
        Diag.UpdateLog("(8)\t" + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);

      }
    }

    #endregion // Constructor








    #region Commands

    /// <summary>
    /// Returns a read-only list of commands 
    /// that the UI can display and execute.
    /// </summary>
    public ReadOnlyCollection<CommandViewModel> CreateROCControlPanelCommands
    {
      get
      {
        if (_commands == null)
        {
          List<CommandViewModel> cmds = CreateControlPanelCommands();
          _commands = new ReadOnlyCollection<CommandViewModel>(cmds);
        }

        try
        {
          Diag.UpdateLog("(11) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + _commands.Count.ToString());
          foreach (CommandViewModel c in _commands)
          {
            Diag.UpdateLog("\t" + c.ViewModelBaseInstanceName);
          }

        }
        catch (Exception ex)
        {
          Diag.UpdateLog("(11) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);
        }
        return _commands;
      }
    }

    private List<CommandViewModel> CreateControlPanelCommands()
    {
      List<CommandViewModel> m = new List<CommandViewModel>
            {
                new CommandViewModel(
                    Strings.MainWindowViewModel_Command_ViewAllCustomers,
                    new RelayCommand(param => ShowAllCustomers())),

                new CommandViewModel(
                    Strings.MainWindowViewModel_Command_CreateNewCustomer,
                    new RelayCommand(param => CreateNewCustomer())),

                new CommandViewModel(
                    Strings.MainWindowViewModel_Command_ExitButton,
                     new RelayCommand(param => OnMainWindowViewModelRequestClose()))
            };


      try
      {
        Diag.UpdateLog("(12) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t");
        foreach (CommandViewModel c in m)
        {
          Diag.UpdateLog("\t" + c.ViewModelBaseInstanceName);
        }
      }
      catch (Exception ex)
      {
        Diag.UpdateLog("(12) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);

      }



      return m;
    }

    #endregion // Commands


    #region RequestClose [event]



    /// <summary>
    /// Raised when this workspace should be removed from the UI.
    /// </summary>
    public event EventHandler MainWindowViewModelRequestClose;

    private void OnMainWindowViewModelRequestClose()
    {
      try
      {
        Diag.UpdateLog("(13) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name);
      }
      catch (Exception ex)
      {
        Diag.UpdateLog("(13) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);
      }
      if (MainWindowViewModelRequestClose != null)
      {
        MainWindowViewModelRequestClose.Invoke(this, EventArgs.Empty);
      }

    }

    #endregion   RequestClose [event]






    #region Workspaces

    /// <summary>
    /// Returns the collection of available workspaces to display.
    /// A 'workspace' is a ViewModel that can request to be closed.
    /// </summary>
    public ObservableCollection<WorkspaceViewModel> Workspaces
    {
      get
      {
        if (_workspaces == null)
        {
          _workspaces = new ObservableCollection<WorkspaceViewModel>();
          _workspaces.CollectionChanged += OnWorkspacesChanged;
        }
        return _workspaces;
      }
    }

    private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.NewItems != null && e.NewItems.Count != 0)
      {
        foreach (WorkspaceViewModel workspace in e.NewItems)
        {
          workspace.WSVMRequestClose += OnWorkspaceRequestClose;
        }
      }

      if (e.OldItems != null && e.OldItems.Count != 0)
      {
        foreach (WorkspaceViewModel workspace in e.OldItems)
        {
          workspace.WSVMRequestClose -= OnWorkspaceRequestClose;
        }
      }
    }

    private void OnWorkspaceRequestClose(object sender, EventArgs e)
    {
      WorkspaceViewModel workspace = sender as WorkspaceViewModel;
      workspace.Dispose();
      Workspaces.Remove(workspace);
    }

    #endregion Workspaces

    #region Private Helpers

    private void CreateNewCustomer()
    {
      Customer newCustomer = Customer.CreateNewCustomer();
      CustomerViewModel workspace = new CustomerViewModel(newCustomer, _customerRepository);
      Workspaces.Add(workspace);
      SetActiveWorkspace(workspace);
    }



    private void ShowAllCustomers()
    {
      AllCustomersViewModel workspace =
          Workspaces.FirstOrDefault(vm => vm is AllCustomersViewModel)
          as AllCustomersViewModel;

      if (workspace == null)
      {
        workspace = new AllCustomersViewModel(_customerRepository);
        Workspaces.Add(workspace);
      }

      SetActiveWorkspace(workspace);
    }

    private void SetActiveWorkspace(WorkspaceViewModel workspace)
    {
      Debug.Assert(Workspaces.Contains(workspace));

      ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);
      if (collectionView != null)
      {
        collectionView.MoveCurrentTo(workspace);
      }
    }

    #endregion Private Helpers
  }
}