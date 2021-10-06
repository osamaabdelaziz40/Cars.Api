using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    public class ExportAttribute : Attribute
    {
        public string ExportName { get; set; }
        public string Format { get; set; }
        public int Order { get; set; }
    }
}
