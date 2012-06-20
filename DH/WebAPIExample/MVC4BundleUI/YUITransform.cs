using System.IO;
using System.Web.Optimization;
using Yahoo.Yui.Compressor;

namespace Bundler.Utilities
{

 public class YUITransform : IBundleTransform
 {
  
  readonly string _contentType = string.Empty;

  public YUITransform(contentType contentType)
  {
   if (contentType == contentType.css)
   {
    this._contentType = "text/css";
   }
   else
   {
    this._contentType = "text/javascript";
   }
  }

  public void Process(BundleContext context, BundleResponse bundle)  
  { 
   bundle.ContentType = this._contentType;

   string content = string.Empty;

   
   foreach (FileInfo file in bundle.Files)  
   { 

    using (StreamReader fileReader = new StreamReader(file.FullName)) {
     content +=   fileReader.ReadToEnd();
     fileReader.Close();  
    }

   }

   bundle.Content = Compress(content);
  }

  string Compress(string content) {
  
   if (_contentType == "text/javascript")
   {
     return JavaScriptCompressor.Compress(content);
   }
   else
   {
    return CssCompressor.Compress(content,CssCompressionType.StockYuiCompressor);
   }
  }
 }
}