using System.IO;
using ApiDmS.Models;
using ApiDmS.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ApiDmS.Controllers {
    [Route ("api/[controller]")]
    public class AddFolderController : Controller {
        private IHostingEnvironment _hostingenvironment;
        

        public AddFolderController (IHostingEnvironment hostingenvironment) {
            _hostingenvironment = hostingenvironment;
           
        }
        [HttpPost ("addfolder")]
        public ActionResult post ([FromForm]Folder folder) {

            string folderName = folder.name.ToString ();
            string webRootPath = _hostingenvironment.WebRootPath;
            string newPath = Path.Combine (webRootPath, folderName);

            if (!Directory.Exists (newPath)) {
                    Directory.CreateDirectory (newPath);
                }

            return Ok("created");
        }

    }
}