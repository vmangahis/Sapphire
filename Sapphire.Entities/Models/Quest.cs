﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    public class Quest
    {
        public Guid QuestId { get; set; }
        public string? QuestTitle { get; set; }
        public string? QuestDescription { get; set; }
        public SapphireUser SapphireClient { get; set; }
        public HunterClient Client { get; set; }
        public double ZennyReward { get; set; }

    }
}
