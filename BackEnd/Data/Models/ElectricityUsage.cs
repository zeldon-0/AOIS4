using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class ElectricityUsage : IEntity
    {
        public string Area { get; set; }
        public double? Usage { get; set; }
        public double? Id { get; set; }
        public double Value { get => (double) Usage; }
        public int Identifier { get => (int)Id; }

    }
}
