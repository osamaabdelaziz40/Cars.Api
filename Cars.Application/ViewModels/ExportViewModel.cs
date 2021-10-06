using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.ViewModels
{
    public class ExportViewModel
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FileBase64 { get; set; }
    }
}
