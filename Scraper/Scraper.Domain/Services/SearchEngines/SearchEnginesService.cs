using AutoMapper;
using Scraper.Domain.DTOs;
using Scraper.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scraper.Domain.Services.SearchEngines
{
    public class SearchEnginesService : ISearchEnginesService
    {
        private readonly ISearchEngineRepository repository;
        private readonly IMapper mapper;

        public SearchEnginesService(ISearchEngineRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
              
        public async Task<IEnumerable<SearchEngineBaseDTO>> GetSearchEnginesBaseInfo()
        {
            var result = new List<SearchEngineBaseDTO>();
            var list = (await repository.GetAllAsync()).ToList();
            list.ForEach(se => result.Add(mapper.Map<SearchEngineBaseDTO>(se)));
            return result;
        }
    }
}
