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
        public override bool Equals(object obj)
        {
            Individual toCompare = obj as Individual;
            if (toCompare != null)
                return this.Index == toCompare.Index;
            return false;
        }
    }
}
