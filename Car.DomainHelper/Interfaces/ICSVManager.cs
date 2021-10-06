using Cars.DomainHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Interfaces
{
    public interface ICSVManager
    {
        Task<ExportedCSVFile> Export<T>(List<T> data, string reportName);
    }
}
