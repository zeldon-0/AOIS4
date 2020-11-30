using Core.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Contracts
{
    public interface ISearchService
    {
        ElectricityUsage GetBiggestElectricityUsage(SearchRequest request);
        Income GetBiggestIncome(SearchRequest request);
    }
}
