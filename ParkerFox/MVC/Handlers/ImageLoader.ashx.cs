using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVC.Handlers
{
    public class ImageLoader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            using (FileStream fileData = File.Open(context.Server.MapPath("~/App_Data/pic.jpg"), FileMode.Open))
            {
                byte[] imageData = new byte[fileData.Length];
                fileData.Read(imageData, 0, imageData.Length);
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(imageData);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}