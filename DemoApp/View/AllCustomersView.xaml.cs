namespace DemoApp.View
{
  public partial class AllCustomersView : System.Windows.Controls.UserControl
  {
    public AllCustomersView()
    {
      InitializeComponent();
      System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Critical;
    }
  }
}