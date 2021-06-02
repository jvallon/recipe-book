using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;

namespace recipebookserver
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserWithRecipesDto>();
            CreateMap<User, UserDetailsDto>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Recipe, RecipeWithDetailsDto>();
            CreateMap<Favorite, FavoriteDto>().ForMember(d => d.RecipeTitle, o => o.MapFrom(s => s.Recipe.Title));
            CreateMap<FavoriteForCreationDto, Favorite>();
        }
    }
}
