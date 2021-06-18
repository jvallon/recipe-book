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
            CreateMap<UserForCreationDto, User>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Recipe, RecipeWithDetailsDto>();
            CreateMap<Favorite, FavoriteDto>()
                .ForMember(d => d.RecipeTitle, o => o.MapFrom(s => s.Recipe.Title));
            CreateMap<FavoriteForCreationDto, Favorite>();
            CreateMap<Instruction, InstructionDto>();
            CreateMap<MeasurementQty, MeasurementQtyDto>();
            CreateMap<MeasurementUnit, MeasurementUnitDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<RecipeIngredient, RecipeIngredientsDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Ingredient.Name))
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.MeasurementUnit.MeasurementDescription))
                .ForMember(d => d.Qty, o => o.MapFrom(s => s.MeasurementQty.Amount))
                .ReverseMap();
            CreateMap<RecipeForCreationDto, Recipe>();
            //CreateMap<IngredientForCreationDto, Ingredient>();
            //CreateMap<MeasurementQtyForCreationDto, MeasurementQty>();
            //CreateMap<MeasurementUnitForCreationDto, MeasurementUnit>();
            //CreateMap<RecipeIngredientForCreationDto, RecipeIngredient>();
            CreateMap<InstructionForCreationDto, Instruction>();
        }
    }
}
