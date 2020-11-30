using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Services.Contracts;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SearchController : ControllerBase
    {
        private ISearchService _searchService;

        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger, 
            ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }
        [HttpPost]
        public IActionResult SearchForElectricityUsage(SearchRequest request)
        {
            ElectricityUsage usage =
                _searchService.GetBiggestElectricityUsage(request);
            return Ok(usage);
        }
        [HttpPost]
        public IActionResult SearchForIncome(SearchRequest request)
        {
            Income income =
                _searchService.GetBiggestIncome(request);
            return Ok(income);
        }

    }
}
