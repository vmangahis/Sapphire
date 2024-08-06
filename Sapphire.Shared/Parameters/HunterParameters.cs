using Sapphire.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.Parameters
{
    public class HunterParameters : RequestParameters
    {
        public uint MaxRank { get; set; } = int.MaxValue;
        public uint MinRank { get; set; }
        public bool ValidRankParameters => MaxRank > MinRank;

    }
}
