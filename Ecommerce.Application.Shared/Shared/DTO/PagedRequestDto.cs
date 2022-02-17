using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Shared
{
    public class PagedRequestDto
    {
        public PagedRequestDto()
        {
            SkipCount = 0;
            MaxResult = 10;
        }
        public int SkipCount { get; set; }
        public int MaxResult { get; set; }
    }
}
