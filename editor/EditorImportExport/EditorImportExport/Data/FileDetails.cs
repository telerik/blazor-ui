using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditorImportExport.Data
{
    public class FileDetails
    {
        public string Name { get; set; } = string.Empty;

        public byte[] Data { get; set; }
    }
}
