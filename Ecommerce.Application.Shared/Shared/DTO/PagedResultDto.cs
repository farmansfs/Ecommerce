﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Shared
{
    public class PagedResultDto<T>
    {
        public PagedResultDto(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        public PagedResultDto()
        {

        }
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
