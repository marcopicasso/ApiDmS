using System.IO;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ApiDmS.Controllers {
    [Route ("api/[controller]")]
    public class AddFolderController : Controller {
        private IHostingEnvironment _hostingenvironment;
        private ApplicationDbContext _context;

        public AddFolderController (IHostingEnvironment hostingenvironment, ApplicationDbContext context) {
            
            _hostingenvironment = hostingenvironment;
            _context = context;
           
        }

        [HttpPost ("newfolder")]
        public ActionResult post ([FromForm]Folder folder) {

            //get the name of the new folder from the form
            string folderName = folder.name.ToString ();
            //get the path of the wwwroot
            string webRootPath = _hostingenvironment.WebRootPath;
            //create the path
            string newPath = Path.Combine (webRootPath, folderName);

            //check if folder exist and create it if not
            if (!Directory.Exists (newPath)) {
                    Directory.CreateDirectory (newPath);
                }

            return Ok(newPath);
        }

    }
}