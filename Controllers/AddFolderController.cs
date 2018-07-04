using System;
using System.IO;
using System.Threading.Tasks;
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
        public async Task<ActionResult> post ([FromForm] Folder folder) {

            //get the name of the new folder from the form
            string folderName = folder.name.ToString ();
            //get the path of the wwwroot
            string webRootPath = _hostingenvironment.WebRootPath;
            //create the path
            string newPath = Path.Combine (webRootPath, folderName);

            using (var _context = new ApplicationDbContext ()) {
                //check if folder exist and create it if not
                if (!Directory.Exists (newPath)) {
                    Directory.CreateDirectory (newPath);
                }
                //create new folder  
                Folder fol = new Folder {
                    name = folderName,
                    path = newPath
                };

                //add in database
                await _context.Folders.AddAsync (fol);

                try {
                   await _context.SaveChangesAsync ();
                } catch (Exception e) {
                    
                    Console.WriteLine (e);

                }
            }

            return Ok ("Path created");
        }

    }
}