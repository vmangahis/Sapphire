﻿using Sapphire.Shared.DTO.SapphireUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Contracts
{
    public interface ISapphireUserService
    {
        Task PurgeUserAsync(SapphireUserForPurgeDTO saphPurgeDto);
    }
}
