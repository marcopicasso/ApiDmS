using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiDmS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDmS.Controllers {

    [Route ("api/[controller]")]
    public class FileUploadController : Controller {
        private IHostingEnvironment _hostingenvironment;

        public FileUploadController (IHostingEnvironment hostingenvironment) {
            _hostingenvironment = hostingenvironment;
        }

        [HttpPost ("upload")]
        public IActionResult Post (Document doc) {

            string este = Path.GetExtension (doc.FileToUpload.FileName);
            
            var newFileName = string.Empty;

            var fileName = string.Empty;

            var files = HttpContext.Request.Form.Files;
            foreach (var file in files) {
                
                if (file.Length > 0) {
                    
                    //Getting FileName
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    //Getting file Extension
                    var FileExt = Path.GetExtension(fileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString (Guid.NewGuid ());

                    // concating  FileName + FileExtension
                    newFileName = myUniqueFileName + FileExt;

                    // Combines two strings into a path.
                    fileName = Path.Combine (_hostingenvironment.WebRootPath, "upload") + $@"\{newFileName}";

                    //Store path of folder in database
                    //PathDB = "demoImages/" + newFileName;

                    using (FileStream fs = System.IO.File.Create (fileName)) {
                        file.CopyTo(fs);
                        fs.Flush ();
                    }
                }
            }

            return Ok();
        }

    }
}