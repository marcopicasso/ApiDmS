using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDmS.Controllers {

    [Route ("api/[controller]")]
    public class FileUploadController : Controller {
        private IHostingEnvironment _hostingenvironment;
        private ApplicationDbContext _context;

        public FileUploadController (IHostingEnvironment hostingenvironment, ApplicationDbContext context) {
           
            _hostingenvironment = hostingenvironment;
            _context = context;
        }

        [HttpPost ("upload"), DisableRequestSizeLimit]
        public ActionResult UploadFile ([FromForm] Document doc) {
            try {
                var file = Request.Form.Files[0];
                int folderId = doc.folderID;

                var folderPath =    (from f in _context.Folders
                                    where f.folderID == folderId 
                                    select f).Select(f => f.path).Single().ToString();

                if (file.Length > 0) {
                    string fileName = ContentDispositionHeaderValue.Parse (file.ContentDisposition).FileName.Trim ('"');
                    //string fullPath = Path.Combine (newPath, fileName);
                    using (var stream = new FileStream (folderPath, FileMode.Create)) {
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