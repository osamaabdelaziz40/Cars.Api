using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Models
{
    public class ExportedCSVFile
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FileBase64 { get; set; }
    }
}
