using System.ComponentModel;

namespace DemoApp.ViewModel
{
  public interface IViewModelBase
  {
    string ViewModelBaseInstanceName { get; }

    event PropertyChangedEventHandler PropertyChanged;

    void Dispose();
    void VerifyPropertyName(string propertyName);
  }
}