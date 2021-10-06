using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Attributes
{
    public class PagingQueryWithExport : PagingQuery
    {
        public bool IsExport { get; set; }
    }
}
