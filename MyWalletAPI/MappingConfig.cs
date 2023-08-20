using AutoMapper;
using MyWalletAPI.Models;
using MyWalletAPI.Models.Dtos;

namespace MyWalletAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
            config.CreateMap<Transaction, TransactionDto>()
            .ForMember("AuthorizedAccoutName", opt => opt.MapFrom(c => c.AuthorizedAccount.Name))
            .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(c => c.Icon.Url))
            .ForMember(dest => dest.Date,
               opt => opt.MapFrom
               (src => DateTime.Now.Subtract(src.Date).Days < 7 ? (src.Date).ToString("dddd") : src.Date.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.Amount,
                opt => opt.MapFrom
                (src => src.TransactionType == TransactionType.Credit ? src.Amount.ToString() : $"+{src.Amount}"));
                config.CreateMap<TransactionDto, Transaction>();
                config.CreateMap<Account, FullAccountInfoDto>();           
            });

            return mappingConfig;
        }
    }
}
