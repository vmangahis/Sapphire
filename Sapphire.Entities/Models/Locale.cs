﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    [Table("T_locale")]
    public class Locale
    {
        public Guid Id { get; set; }
        public string LocaleName { get; set; } = "dummy";
    }
}