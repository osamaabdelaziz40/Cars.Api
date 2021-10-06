using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Attributes
{
    public class ExportProperty
    {
        public PropertyInfo PropertyInfo { get; set; }

        public ExportAttribute ExportAttribute { get; set; }
    }
}
