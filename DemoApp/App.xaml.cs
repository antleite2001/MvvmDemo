using DemoApp.ViewModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace DemoApp
{
  public partial class App : Application
  {
    static App()
    {
      Diag.UpdateLog(true, "");
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

      MainWindow window = new MainWindow();

      // Create the ViewModel to which 
      // the main window binds.
      string path = "Data/customers.xml";

      MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(path);

      // When the ViewModel asks to be closed, 
      // close the window.
      EventHandler handler = null;
      handler = delegate
      {
        try
        {
          Diag.UpdateLog(false,  "(1) "+this.GetType().FullName + "; " +System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
        catch (Exception ex)
        {
          Diag.UpdateLog(false,  "(1) "+this.GetType().FullName + "; " +System.Reflection.MethodBase.GetCurrentMethod().Name+ ";  " + ex.Message);
        }

        mainWindowViewModel.WorkSpaceViewModelRequestClose -= handler;
        mainWindowViewModel.MainWindowViewModelRequestClose -= handler;
        window.Close();
      };

      mainWindowViewModel.WorkSpaceViewModelRequestClose += handler;
      mainWindowViewModel.MainWindowViewModelRequestClose += handler;

      // Allow all controls in the window to 
      // bind to the ViewModel by setting the 
      // DataContext, which propagates down 
      // the element tree.
      window.DataContext = mainWindowViewModel;

      window.Show();
    }
  }
}