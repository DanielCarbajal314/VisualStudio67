using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Shop.Presentation.SecureWebApi.Controllers
{
    public class ArchivosController : ApiController
    {
        [HttpPost]
        public async Task Cargar()
        {
            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer = await file.ReadAsByteArrayAsync();
                File.WriteAllBytes(root+"/"+filename, buffer);
            }
        }
    }
}
