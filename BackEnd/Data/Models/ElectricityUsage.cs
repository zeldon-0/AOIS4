using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class ElectricityUsage
    {
        public string Area { get; set; }
        public double? Usage { get; set; }
        public double? Id { get; set; }
    }
}
