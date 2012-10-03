using System.Web.Optimization;

namespace ParkerFox.Infrastructure.Web.Bundling
{
    public sealed class LessBundleTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
}