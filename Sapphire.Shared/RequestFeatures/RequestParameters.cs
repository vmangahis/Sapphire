﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int MaxPageSize = 10;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 5;
        public string? OrderBy { get; set; }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = value > MaxPageSize ? MaxPageSize : value;
            }
        }
        public string? Field { get; set; }
    }
}
