using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiDmS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDmS.Controllers {

    [Route("api/[controller]")]
    public class FileUploadController : Controller 
    {
        [HttpPost("upload")]
        public ActionResult Post(Document doc)
        {
            

            return Ok(doc);
        }
        

    }
}