using Cars.DomainHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DomainHelper.Interfaces
{
    public interface ICallHttpRequest
    {
        ResultVM GET(string FullPath);
    }
}
