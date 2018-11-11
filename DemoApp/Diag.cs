using System.Diagnostics;
using System.IO;

namespace DemoApp
{

  
  public static class Diag
  {

    public static string s = "";

    [Conditional("DEBUG")]
    [DebuggerStepThrough]
    public static void DataBindingPresentation()
    {
      System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.AnimationSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.DependencyPropertySource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.DocumentsSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.FreezableSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.HwndHostSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.MarkupSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.NameScopeSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.ResourceDictionarySource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;
      System.Diagnostics.PresentationTraceSources.RoutedEventSource.Switch.Level = System.Diagnostics.SourceLevels.Verbose;


    }
     [Conditional("DEBUG")]
    [DebuggerStepThrough]
    public static void UpdateLog(bool DeleteContent, string Text)
    {

      if (DeleteContent)
      {
        File.Delete(@"log.txt");
      }
      File.AppendAllText(@"log.txt", Text + "\r\n");
    }
  }
}
