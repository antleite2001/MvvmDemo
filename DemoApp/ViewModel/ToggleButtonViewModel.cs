using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace DemoApp.ViewModel
{
  /// <summary>
  /// This ViewModelBase subclass requests to be removed 
  /// from the UI when its CloseCommand executes.
  /// This class is abstract.
  /// </summary>
  public abstract class ToggleButtonViewModel : WorkspaceViewModel
  {
    #region Fields
    private readonly SolidColorBrush _leftColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
    private readonly SolidColorBrush _rightColor = new SolidColorBrush(Color.FromRgb(0, 255, 0));
    private readonly Thickness _leftThickness = new Thickness(10, 0, 0, 0);
    private readonly Thickness _rightThickness = new Thickness(0, 0, 10, 0);
    private readonly HorizontalAlignment _rightAlignment = HorizontalAlignment.Right;
    private readonly HorizontalAlignment _leftAlignment = HorizontalAlignment.Left;

    private HorizontalAlignment _toggleButtonPosition;
    private Thickness _toggleButtonMargins = new Thickness();
    private SolidColorBrush _toggleButtonColor = new SolidColorBrush();


     RelayCommand _toggleButtonClickedCommand;
    #endregion Fields

    #region Constructor

    protected ToggleButtonViewModel()
    {
      Diag.DataBindingPresentation();
      ToggleButtonPosition = _leftAlignment;
      ToggleButtonMargins = _leftThickness;
      ToggleButtonColor = _leftColor;
    }

    #endregion Constructor

    #region ToggleButtonClicked



    public HorizontalAlignment ToggleButtonPosition
    {
      get { return _toggleButtonPosition; }
      set
      {
        _toggleButtonPosition = value;

        base.OnPropertyChanged("ToggleButtonPosition");
      }
    }

    public SolidColorBrush ToggleButtonColor
    {
      get
      {

        if (_toggleButtonColor == null)
        {
          _toggleButtonColor = _leftColor;
        }
        return _toggleButtonColor;
      }
      set
      {
        _toggleButtonColor = value;
        base.OnPropertyChanged("ToggleButtonColor");
      }
    }


    public Thickness ToggleButtonMargins
    {
      get
      {
        if (_toggleButtonMargins == null)
        {
          _toggleButtonMargins = _leftThickness;
        }
        return _toggleButtonMargins;
      }
      set
      {
        _toggleButtonMargins = value;

        base.OnPropertyChanged("ToggleButtonMargins");
      }
    }
    /// <summary>
    /// register Command ToggleButtonClicked
    /// </summary>
    public ICommand ToggleButtonClicked
    {
      get
      {
        if (_toggleButtonClickedCommand == null)
        {
          _toggleButtonClickedCommand = new RelayCommand(param => OnToggleButtonClicked());
        }

        try
        {
          Diag.UpdateLog("(450154) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t");
        }
        catch (Exception ex)
        {
          Diag.UpdateLog("(450154) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);
        }
        return _toggleButtonClickedCommand;
      }
    }

    #endregion ToggleButtonClicked
    
    #region Request_t_Command [event]
     
    /// <summary>
    /// Raised when ToggleButtonClicked is clicked
    /// </summary>

    public void OnToggleButtonClicked()
    {
      
      try
      {
        Diag.UpdateLog("(590213) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t");
      }
      catch (Exception ex)
      {
        Diag.UpdateLog("(590213) " + GetType().FullName + ";\t" + System.Reflection.MethodBase.GetCurrentMethod().Name + ";\t" + ex.Message);
      }

      if (ToggleButtonPosition == System.Windows.HorizontalAlignment.Left)
      {
        ToggleButtonPosition = _rightAlignment;
        ToggleButtonMargins = _rightThickness;
        ToggleButtonColor = _rightColor;
      }
      else
      {
        ToggleButtonPosition = _leftAlignment;
        ToggleButtonMargins = _leftThickness;
        ToggleButtonColor = _leftColor;
      }
    }

    #endregion Request_t_Command
  }
}