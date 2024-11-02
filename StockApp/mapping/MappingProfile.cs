using AutoMapper;
using StockApp.Models;

namespace StockApp.mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<FinnHubResponseDTO, StockViewModel>().ReverseMap();
        }
    }
}
