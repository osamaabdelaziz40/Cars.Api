using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Models
{
    public class PaginatedResult<T>
    {
        public List<T> Records { get; set; }
        public int Total { get; set; }
        public bool HasNext { get; set; }
    }

    public class PaginatedResultWithExport<T> : PaginatedResult<T>
    {
        [JsonIgnore]
        public byte[] PDFFile { get; set; }
    }
}
