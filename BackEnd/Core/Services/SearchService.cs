using Core.Services.Contracts;
using Data.Context;
using Data.Models;
using GeneticAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Models;

namespace Core.Services
{
    public class SearchService : ISearchService
    {
        private ElectricityContext _context;
        public SearchService(ElectricityContext context)
        {
            _context = context;
        }
        public ElectricityUsage GetBiggestElectricityUsage(SearchRequest request)
        {
            Algorithm<ElectricityUsage> algorithm = 
                new Algorithm<ElectricityUsage>(_context.ElectricityUsages, request.Epochs,
                request.PopulationSize, request.MutationProbability);
            int index = algorithm.Search();
            ElectricityUsage usage = _context
                .ElectricityUsages
                .FirstOrDefault(u => u.Id - 1 == index);
            return usage;
        }

        public Income GetBiggestIncome(SearchRequest request)
        {
            Algorithm<Income> algorithm =
                new Algorithm<Income>(_context.Incomes, request.Epochs,
                request.PopulationSize, request.MutationProbability);
            int index = algorithm.Search();
            Income income = _context
                .Incomes
                .FirstOrDefault(u => u.CommunityAreaNumber - 1 == index);
            return income;
        }
    }
}
