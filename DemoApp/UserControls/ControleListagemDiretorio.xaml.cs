using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DemoApp.UserControls
{
  /// <summary>
  /// Interaction logic for ControleListagemDiretorio.xaml
  /// </summary>
  public partial class ControleListagemDiretorio : UserControl, INotifyPropertyChanged
  {
    private string diretorio;




    private string[] itensDiretorio;
    private string itemSelecionado;
    private void NotificarPropriedadeAlterada(string propriedade)
    {
      PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
    }
    private void btnListar_Click(object sender, RoutedEventArgs e)
    {
      if (!string.IsNullOrEmpty(diretorio))
      {
        ItensDiretorio = Directory.GetFiles(diretorio);
      }
    }

    #region Public
    public string Diretorio
    {
      get => diretorio;
      set
      {
        if (diretorio != value)
        {
          diretorio = value;
          NotificarPropriedadeAlterada(nameof(Diretorio));
        }
      }
    }
    public string[] ItensDiretorio
    {
      get => itensDiretorio;
      set
      {
        if (itensDiretorio != value)
        {
          itensDiretorio = value;
          NotificarPropriedadeAlterada(nameof(ItensDiretorio));
        }
      }
    }
    public string ItemSelecionado
    {
      get => itemSelecionado;
      set
      {
        if (itemSelecionado != value)
        {
          itemSelecionado = value;
          NotificarPropriedadeAlterada(nameof(itemSelecionado));
        }
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public ControleListagemDiretorio()
    {
      InitializeComponent();
      DataContext = this;
    }
    #endregion Public

  }

  //Read more: http://www.linhadecodigo.com.br/artigo/3708/criando-user-controls-em-wpf.aspx#ixzz5WcKKSR75

}
