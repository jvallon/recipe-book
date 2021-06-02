using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Repository;
using LoggerService;
using Entities.DataTransferObjects;
using AutoMapper;

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

    }
}
