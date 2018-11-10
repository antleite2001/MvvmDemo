using System.Diagnostics;
 

namespace DemoApp
{
  public partial class MainWindow : System.Windows.Window
  {
    public MainWindow()
    {
      InitializeComponent();
      System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Critical;

    }


     

  }
}