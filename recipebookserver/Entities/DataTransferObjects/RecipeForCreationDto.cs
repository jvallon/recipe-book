﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class RecipeForCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan PrepTime { get; set; }
        public TimeSpan CookTime { get; set; }
        public string? ImageUrl { get; set; }
        public IList<InstructionForCreationDto> Instructions { get; set; }

        public IEnumerable<RecipeIngredientsDto> RecipeIngredients { get; set; }
        //public UserDto User { get; set; }
    }
}
