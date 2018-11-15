using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoApp.UserControls
{
    /// <summary>
    /// Interaction logic for ToggleButton.xaml
    /// </summary>
    public partial class ToggleButton : UserControl
    {
    Thickness LeftSide = new Thickness(-39, 0, 0, 0);
    Thickness RightSide = new Thickness(0, 0, -39, 0);
        public ToggleButton()
        {
            InitializeComponent();
        }

    private void ToggleClick(object sender, RoutedEventArgs e)
    {

    }
  }
}
