﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string msg) : base(msg) { }
    }
}
