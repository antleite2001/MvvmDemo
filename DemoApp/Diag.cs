using System.IO;

namespace DemoApp
{
  public static class Diag
  {

    public static void DataBindingPresentation()
    {
      System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
    }

    public static void UpdateLog(bool DeleteContent, string Text)
    {
      
      if (DeleteContent)
      {
        File.Delete(@"log.txt");
      }
      File.AppendAllText(@"log.txt", Text  +"\r\n");
    }
  }
}
