using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class SearchRequest
    {
        public int Epochs { get; set; }
        public int PopulationSize { get; set; }
        public double MutationProbability { get; set; }
    }
}
