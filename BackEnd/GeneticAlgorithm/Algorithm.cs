using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GeneticAlgorithm
{
    
    public class Algorithm <T> where T: class, IEntity
    {
        public static double[] Input;/*{92.58450930592814,
            10.550795593555456,
            85.43994109399614,
            25.142792344625477,
            16.388178158732213,
            67.82669046326852,
            9.328494504712753,
            63.72315420942528,
            67.64605751617162,
            18.665539388854775,
            46.058496947427514,
            0.6277160721960087,
            35.454027278094564,
            46.82707565223196,
            48.891231999216245,
            22.34559362863451,
            36.45383777863059,
            43.63514969294665,
            9.039258774853899,
            49.70029799719355,
            84.77313131316245,
            72.34177145750344,
            75.45858955730618,
            9.058792939902654,
            72.9487126101501,
            4.70148902605357,
            98.29896842050319,
            9.793300651848922,
            5.579759555673115,
            84.28543865880252,
            2.0722147552632797,
            2.983620158854695,
            60.495375590629585,
            5.017758861658051,
            49.020656826449866,
            76.16888050742861,
            25.722726399881175,
            64.88142412383175,
            47.74265137861606,
            17.32841363052298,
            33.22057576534365,
            39.31521602874399,
            34.992562762923804,
            86.79695180002457,
            70.23382939874838,
            51.131724543465175,
            82.7341461008108,
            97.69732723836663,
            81.67528681535055,
            63.627666264599036
   };*/
        private List<Individual> Population;
        private int Epochs;
        private int PopulationSize;
        private int Boundary;
        private double MutationProbability;
        private DbSet<T> _dbSet;
        public Algorithm(DbSet<T> dbSet, int epochs, 
            int populationSize, double mutationProbability)
        {
            _dbSet = dbSet;
            Boundary = _dbSet.Count();
            Epochs = epochs;
            PopulationSize = populationSize;
            MutationProbability = mutationProbability;
            Population = new List<Individual>();
            GenerateInput();
        }

        public int Search()
        {
            Populate();
            Population = SortPopulation(Population);
            for (int i = 0; i < Epochs; i++)
            {

                Console.WriteLine($"Epoch: {i}");
                Console.WriteLine($"Best index: {Population[0].Index} Fitness: {Population[0].Fitness}");
                ProduceOffspring(Population);
                Population = SortPopulation(Population);
               
            }
            Console.WriteLine($"Actual maximum: {_dbSet.ToList().OrderByDescending(i => i.Value).First()}");
            return Population[0].Index;
        }
        private void Populate()
        {
            Random random = new Random();

            for (int i = 0; i < PopulationSize; i++)
            {
                int newVal = random.Next(Boundary);
                while (Population.Any(i => i.Index == newVal))
                {
                    newVal = random.Next(Boundary);
                }
                double fitness = CalculateFitness(newVal);
                Population.Add(new Individual
                    (
                    newVal, 
                    fitness
                    )
                );

            }
        }

        private List<Individual> SortPopulation(List<Individual> generation)
        {
            var sortedGeneration = generation
                .GroupBy(i => i.Index)
                .Select(g => g.First())
                .OrderByDescending(i => i.Fitness)
                .Take(PopulationSize)
                .ToList();
            return sortedGeneration;
        }
        private void ProduceOffspring(List<Individual> currentGeneration)
        {
            List<Individual> offspring = new List<Individual>();
            Random random = new Random();
            int maximumBitOffset = 1;
            while (Math.Pow(2, maximumBitOffset) < Input.Length)
            {
                maximumBitOffset++;
            }


            while (offspring.Count < PopulationSize)
            {
                /*int parent1a = random.Next(PopulationSize);
                int parent1b = random.Next(PopulationSize);
                int parent2a = random.Next(PopulationSize);
                int parent2b = random.Next(PopulationSize);
                int parent1 = Math.Min(parent1a, parent1b);
                int parent2 = Math.Min(parent2a, parent2b);
                */
                int parent1 = random.Next(PopulationSize);
                int parent2 = random.Next(PopulationSize);
                int mask = (~0 << random.Next(maximumBitOffset - 1));
                int child = currentGeneration[parent1].Index & mask |
                currentGeneration[parent2].Index & ~mask;
                if (random.NextDouble() > MutationProbability)
                    child ^= 1 << random.Next(maximumBitOffset - 1);
                offspring.Add(new Individual(child, CalculateFitness(child)));
            }
            Population = Population.Concat(offspring).ToList();
        }
        private double CalculateFitness(int index)
        {
            if (index >=0 && index < Input.Length)
            {
                //return Input[index];
                return _dbSet
                    .ToList()
                    .FirstOrDefault(u => u.Identifier - 1 == index)
                    .Value;
            }
            return 0;
        }

        private void GenerateInput()
        {
            List<double> inputs = new List<double>();
            Random random = new Random();
            for (int i = 0; i < Boundary; i++)
            {
                inputs.Add(random.NextDouble() * 100);
            }
            Input = inputs.ToArray();
        }
    }
}
