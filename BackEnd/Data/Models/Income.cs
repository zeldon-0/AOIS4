using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Income : IEntity
    {
        public int CommunityAreaNumber { get; set; }
        public string CommunityAreaName { get; set; }
        public double PerCapitaIncome { get; set; }
        public double Value { get => PerCapitaIncome; }
        public int Identifier { get => CommunityAreaNumber; }
    }
}
