using Ecommerce.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class BaseController:ControllerBase
    {
        public OkObjectResult Ok<T>([ActionResultObjectValue] T value)
        {
            var result = new SuccessResponse<T>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = HttpStatusCode.OK.ToString()
            };
            return base.Ok(result);
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return this.Ok(value);
        }
    }
}
