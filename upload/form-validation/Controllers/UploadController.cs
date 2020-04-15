using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace FormValidation.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UploadController : Controller
    {
        public IWebHostEnvironment HostingEnvironment { get; set; }

        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Save(IEnumerable<IFormFile> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var physicalPath = Path.Combine(HostingEnvironment.WebRootPath, fileName);

                    // implement validation and authentication here

                    // The files are not actually saved in this demo
                    // using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    // {
                    //    await file.CopyToAsync(fileStream);
                    // }

                    // instead mock async operation
                    await Task.Yield();
                }
            }

            // this controller always returns a success, unless an exception is thrown
            return new OkResult();
        }


        [HttpPost]
        public ActionResult Remove(string[] files)
        {
            if (files != null)
            {
                foreach (var fullName in files)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(HostingEnvironment.WebRootPath, fileName);

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        // System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // this controller always returns a success, unless an exception is thrown
            return new OkResult();
        }
    }
}
