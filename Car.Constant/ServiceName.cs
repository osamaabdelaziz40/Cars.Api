using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Constant
{
    public static class ServiceName
    {
        public const string GetUsers = "GetUsers";
    }

    public static class ServiceNameLookup
    {
        public const string ServiceName = "Lookup";

        public const string GetAllCountry = "GetAllCountry";
    }

    public static class ServiceNameCommon
    {
        public const string Add = "Add";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string GetById = "GetById";
        public const string GetAll = "GetAll";
        public const string GetAllPaged = "GetAllPaginated";
        public const string GetAllExported = "GetAllExported";
    }

}
