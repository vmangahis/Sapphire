﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Contracts
{
    public interface IRepositoryManager
    {
        IMonsterRepository Monster { get; }
        IHunterRepository Hunter { get; }
        void Save();
    }
}
