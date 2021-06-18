using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Repository;
using LoggerService;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace recipebookserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public RecipeController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repositoryWrapper;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetRecipes()
        {
            try
            {
                var recipes = repository.Recipe.GetRecipes();
                logger.LogInfo($"Retrieved recipes from DB");

                var recipesResult = mapper.Map<IEnumerable<RecipeDto>>(recipes);
                return Ok(recipesResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetRecipes action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipeById(int id)
        {
            try
            {
                var recipe = repository.Recipe.GetRecipeById(id);

                if(recipe == null)
                {
                    logger.LogError($"Recipe with id: {id} not found in DB.");
                    return NotFound();
                }

                logger.LogInfo($"Retrieved recipes from DB");
                var recipeResult = mapper.Map<RecipeDto>(recipe);
                return Ok(recipeResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetRecipes action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/details")]
        public IActionResult GetRecipeDetailsById(int id)
        {
            try
            {
                var recipe = repository.Recipe.GetRecipeDetailsById(id);

                if (recipe == null)
                {
                    logger.LogError($"Recipe with id: {id} not found in DB.");
                    return NotFound();
                }

                logger.LogInfo($"Retrieved recipes from DB");
                var recipeResult = mapper.Map<RecipeWithDetailsDto>(recipe);
                return Ok(recipeResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetRecipes action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult CreateRecipe([FromBody]RecipeForCreationDto recipe)
        {
            try
            {
                if(recipe == null)
                {
                    logger.LogError("Recipe object sent is null");
                    return BadRequest("Recipe object is null");
                }

                if (!ModelState.IsValid)
                {
                    logger.LogError("Recipe object sent is invalid");
                    return BadRequest("Recipe object is invalid");
                }

                var currentUser = HttpContext.User.Identity.Name;
                var user = repository.User.GetUserByAuthId(currentUser);
                //if(user == null)
                //{
                //    logger.LogError("User not found in DB");
                //    return BadRequest("Unknown user");
                //}

                var recipeEntity = mapper.Map<Recipe>(recipe);
                recipeEntity.UserId = "1";
                foreach(var ri in recipeEntity.RecipeIngredients)
                {
                    var ingr = repository.Ingredients.GetIngredientByName(ri.Ingredient.Name);
                    if (ingr != null)
                    {
                        ri.IngredientId = ingr.IngredientId;
                        ri.Ingredient = null;
                        logger.LogWarn($"Warning: Ingredient {ingr.Name} already exists");
                    }

                    var msrUnit = repository.MeasurementUnit.GetMeasurementUnitByDesc(ri.MeasurementUnit.MeasurementDescription);
                    if (msrUnit != null)
                    {
                        ri.MeasurementUnitsId = msrUnit.Id;
                        ri.MeasurementUnit = null;
                    }

                    var msrQty = repository.MeasurementQty.GetMeasurementQtyByAmount(ri.MeasurementQty.Amount);
                    if (msrQty != null)
                    {
                        ri.MeasurementQtyId = msrQty.Id;
                        ri.MeasurementQty = null;
                    }
                }
                repository.Recipe.CreateRecipe(recipeEntity);
                repository.Save();

                var createdRecipe = mapper.Map<RecipeDto>(recipeEntity);
                return CreatedAtAction(nameof(GetRecipeDetailsById), new { id = createdRecipe.RecipeId }, createdRecipe);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside CreateRecipe action: {ex.Message}\n{ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
