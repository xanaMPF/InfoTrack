using AutoMapper;
using Scraper.Domain.DTOs;
using Scraper.Infrastructure.Models;

namespace Scraper.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchEngine, SearchEngineBaseDTO>();

            CreateMap<SearchHistory, SearchResultDTO>()
                .ForMember(dest => dest.SearchEngineId, opt => opt.MapFrom(x => x.SearchEngineId))
                .ForMember(dest => dest.SearchEngineName, opt => opt.MapFrom(x => x.SearchEngine.Name))                    
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SearchEngineId, opt => opt.MapFrom(x => x.SearchEngineId))
                .ForMember(dest => dest.Keywords, opt => opt.Ignore())
                .ForMember(dest => dest.SearchEngine, opt => opt.Ignore())
                .ForMember(dest => dest.Result, opt => opt.MapFrom(x => string.Join(", ", x.Ranks)));

            CreateMap<SearchHistory, SearchRequestDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SearchEngine, opt => opt.Ignore());
        }
    }
}
