using AutoMapper;
using ProjektDotNet.Dtos;
using ProjektDotNet.Models;

namespace ProjektDotNet.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Player, PlayerDto>();
            Mapper.CreateMap<Trainer, TrainerDto>();
            Mapper.CreateMap<Result, ResultDto>();

            Mapper.CreateMap<SportType, SportTypeDto>();
            Mapper.CreateMap<Competition, CompetitionDto>();


            // Dto to Domain
            

       
            Mapper.CreateMap<PlayerDto, Player>()
               .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<TrainerDto, Trainer>()
               .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<ResultDto, Result>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}