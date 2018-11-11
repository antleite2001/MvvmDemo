﻿using System;
using System.Diagnostics;
using System.Windows.Input;

namespace DemoApp
{
  /// <summary>
  /// A command whose sole purpose is to 
  /// relay its functionality to other
  /// objects by invoking delegates. The
  /// default return value for the CanExecute
  /// method is 'true'.
  /// </summary>
  public class RelayCommand : ICommand
  {
    #region Fields

    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;

    #endregion // Fields

    #region Constructors

    /// <summary>
    /// Creates a new command that can always execute.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    public RelayCommand(Action<object> execute) : this(execute, null)
    {
      Diag.DataBindingPresentation();

      try
      {
        Diag.UpdateLog(false, "(4) "+this.GetType().FullName + "; " +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";   "+ execute.ToString());
      }
      catch (Exception ex)
      {
        Diag.UpdateLog(false, "(4) "+this.GetType().FullName + "; " +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";   " + ex.Message);

      }

    }

    /// <summary>
    /// Creates a new command.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    /// <param name="canExecute">The execution status logic.</param>
    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
      Diag.DataBindingPresentation();

      if (execute == null)
      {
        throw new ArgumentNullException("execute");
      }

      _execute = execute;
      _canExecute = canExecute;


      try
      {
        Diag.UpdateLog(false, "(5) "+this.GetType().FullName + "; " +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";   "   +
          _execute.Method.Name + "   " + 
          _execute.Method.ToString() + "  " + 
          _execute.Target.ToString());
      }
      catch (Exception ex)
      {
        Diag.UpdateLog(false, "(5) "+this.GetType().FullName + "; " +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";   " + ex.Message);
      }

    }

    #endregion // Constructors

    #region ICommand Members

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
      return _canExecute == null ? true : _canExecute(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    //[DebuggerStepThrough]
    public void Execute(object parameter)
    {
      _execute.Invoke(parameter);
    }

    #endregion // ICommand Members
  }
}