using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerce.Responses
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
