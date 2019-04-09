using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using IOFile = System.IO.File;

namespace TelerikBlazor.Server.Controllers
{
    public class SourceController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly HtmlEncoder _htmlEncoder;

        public SourceController(IHostingEnvironment hostingEnvironment, HtmlEncoder htmlEncoder)
        {
            _hostingEnvironment = hostingEnvironment;
            _htmlEncoder = htmlEncoder;
        }

        public ActionResult Index(string path)
        {
            var mappedPath = _hostingEnvironment.ContentRootPath.Replace("Server", "Client") + path.Replace("/", "\\");

            if (!IOFile.Exists(mappedPath))
            {
                return NotFound();
            }

            var source = IOFile.ReadAllText(mappedPath);
            return Content("<pre class='prettyprint'>" + _htmlEncoder.Encode(source) + "</pre>", "text/plain");
        }
    }
}
