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

        [HttpPost ("upload"), DisableRequestSizeLimit]
        public ActionResult UploadFile ([FromForm] Document doc) {
            try {
                var file = Request.Form.Files[0];
                string folderName = doc.folderID.ToString();
                string webRootPath = _hostingenvironment.WebRootPath;
                string newPath = Path.Combine (webRootPath, folderName);
                var save = newPath;
                if (!Directory.Exists (newPath)) {
                    Directory.CreateDirectory (newPath);
                }
                if (file.Length > 0) {
                    string fileName = ContentDispositionHeaderValue.Parse (file.ContentDisposition).FileName.Trim ('"');
                    string fullPath = Path.Combine (newPath, fileName);
                    using (var stream = new FileStream (fullPath, FileMode.Create)) {
                        file.CopyTo (stream);
                    }
                }
                return Json ("Upload Successful.");
            } catch (System.Exception ex) {
                return Json ("Upload Failed: " + ex.Message);
            }
        }
    }
}