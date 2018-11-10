namespace DemoApp.View
{
  public partial class CustomerView : System.Windows.Controls.UserControl
  {
    public CustomerView()
    {
      InitializeComponent();
      System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Critical;
    }
  }
}