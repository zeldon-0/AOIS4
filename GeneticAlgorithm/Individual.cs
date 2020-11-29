using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm
{
    public class Individual
    {
        public int Index;
        public double Fitness;
        public Individual(int index, double fitness)
        {
            Index = index;
            Fitness = fitness;
        }

    }
}
