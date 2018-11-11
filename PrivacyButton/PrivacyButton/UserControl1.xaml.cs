using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrivacyButton
{
  /// <summary>
  /// Interaction logic for UserControl1.xaml
  /// </summary>
  public partial class UserControl1 : UserControl
  {
    /// <summary>
    /// 
    /// </summary>
    public UserControl1()
    {
      InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    public static readonly DependencyProperty CommandOneProperty =
    DependencyProperty.Register(
    "CommandOne",
    typeof(ICommand),
    typeof(UserControl1),
    new PropertyMetadata(null)
    );
    /// <summary>
    /// 
    /// </summary>
    public ICommand CommandOne
    {
      get => (ICommand)GetValue(CommandOneProperty);

      set => SetValue(CommandOneProperty, value);
    }


  }
}
