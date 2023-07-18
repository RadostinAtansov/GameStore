namespace GameStore.Data
{
    using AutoMapper;
    using GameStore.Data.Models;
    using GameStore.Models.GameViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddGameViewModel, Game>();
        }
    }
}