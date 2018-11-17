using DemoApp.ViewModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
namespace DemoApp
{
  public partial class App : Application
  {
    static App()
    {
      Diag.UpdateLog(true, "--------------------------------------------------------------------------");
      Diag.DataBindingPresentation();
      // This code is used to test the app when using other cultures.
      //
      //System.Threading.Thread.CurrentThread.CurrentCulture =
      //    System.Threading.Thread.CurrentThread.CurrentUICulture =
      //        new System.Globalization.CultureInfo("it-IT");


      // Ensure the current culture passed into bindings is the OS culture.
      // By default, WPF uses en-US as the culture, regardless of the system settings.
      //
      FrameworkElement.LanguageProperty.OverrideMetadata(
        typeof(FrameworkElement),
        new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      MainWindow _mainWindow = new MainWindow();
      // Create the ViewModel to which 
      // the main _mainWindow binds.
      string path = "Data/customers.xml";

      MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel(path);




      #region MainWindow KeyDown
      //Delegate to handle KeyDown events-----------------------
      KeyEventHandler KeyDown = delegate (object sender, KeyEventArgs arg)
      {
        if (arg.Key == Key.F4)
        {
          _mainWindowViewModel.OnToggleButtonClicked();
        }
      };

      //Hook to capture KeyDown events
      _mainWindow.KeyDown += KeyDown;

      #endregion MainWindow KeyDown





      // When the ViewModel asks to be closed, 
      // close the _mainWindow.
      EventHandler handler = null;
      handler=delegate
      {
        try
        {
          Diag.UpdateLog("(1)\t" + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
        catch (Exception ex)
        {
          Diag.UpdateLog("(1)\t" + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);
        }

        _mainWindowViewModel.WSVMRequestClose -= handler;
        _mainWindowViewModel.MainWindowViewModelRequestClose -= handler;
        _mainWindow.KeyDown -= KeyDown;
        _mainWindow.Close();
      };

      _mainWindowViewModel.WSVMRequestClose += handler;
      _mainWindowViewModel.MainWindowViewModelRequestClose += handler;





      // Allow all controls in the _mainWindow to 
      // bind to the ViewModel by setting the 
      // DataContext, which propagates down 
      // the element tree.
      _mainWindow.DataContext = _mainWindowViewModel;

      _mainWindow.Show();
    }

    //private void KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    //  {
    //  if (e.Key == System.Windows.Input.Key.F4)
    //  {
    //    _mainWindowViewModel.OnToggleButtonClicked();
    //  }
    //  }

  }
}