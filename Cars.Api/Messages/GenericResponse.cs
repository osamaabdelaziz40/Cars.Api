using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Api.Messages
{
    public class GenericSuccessResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public T data { get; set; }
    }
    public class GenericResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public object data { get; set; }
    }
}
