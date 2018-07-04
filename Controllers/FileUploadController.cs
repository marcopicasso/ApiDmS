using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiDmS.DAL.IRepository;
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
        private readonly IDocumentRepository _IDocumentRepository;

        public FileUploadController (IHostingEnvironment hostingenvironment, 
                                    ApplicationDbContext context, 
                                    IDocumentRepository IDocumentRepository) {

            _hostingenvironment  = hostingenvironment;
            _context             = context;
            _IDocumentRepository = IDocumentRepository;
        }
        

        [HttpPost ("upload"), DisableRequestSizeLimit]
        public  async Task<ActionResult>  UploadFile ([FromForm] Document doc) {
            try {
                var file = Request.Form.Files[0];
                int folderId = doc.folderID;
                string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                using (var _context = new ApplicationDbContext ()) {
                    var folder = _context.Folders.Single (f => f.folderID == folderId);
                    var folderPath = folder.path;

                    if (file.Length > 0) {
                        string fileName = ContentDispositionHeaderValue.Parse (file.ContentDisposition).FileName.Trim ('"');
                        using (var stream = new FileStream (folderPath, FileMode.Create)) {
                            await file.CopyToAsync (stream);
                        }

                   
                    }
                }
                return Json("Upload Successful.");

            } catch (System.Exception ex) {

                return Json("Upload Failed: " + ex.Message);
            }
        }
    }
}