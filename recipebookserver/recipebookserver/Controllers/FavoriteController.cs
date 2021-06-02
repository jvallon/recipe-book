using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using AutoMapper;
using Entities.DataTransferObjects;

namespace recipebookserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : Controller
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public FavoriteController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repositoryWrapper;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "FavoriteById")]
        public IActionResult GetFavoriteById(int id)
        {
            try
            {
                var favorite = repository.Favorite.FindByCondition(fav => fav.Id == id).FirstOrDefault();
                if (favorite == null)
                {
                    logger.LogError($"Favorite with id: {id} not found in database");
                    return NotFound();
                }

                var favoriteResult = mapper.Map<FavoriteDto>(favorite);
                return Ok(favoriteResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetFavoriteById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateFavorite([FromBody]FavoriteForCreationDto favorite)
        {
            try
            {
                if(favorite == null)
                {
                    logger.LogError("Favorite object sent is null");
                    return BadRequest("Favorite object is null");
                }

                if (!ModelState.IsValid)
                {
                    logger.LogError("Invalid favorite object sent from client");
                    return BadRequest("Invalid model object");
                }

                var favoriteEntity = mapper.Map<Favorite>(favorite);
                repository.Favorite.CreateFavorite(favoriteEntity);
                repository.Save();

                var createdFavorite = mapper.Map<FavoriteDto>(favoriteEntity);

                return CreatedAtRoute("FavoriteById", new { id = createdFavorite.Id }, createdFavorite);
            }
            catch(Exception ex)
            {
                logger.LogError($"Something went wrong inside CreateFavorite action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFavorite(int id)
        {
            try
            {
                var favorite = repository.Favorite.FindByCondition(f => f.Id == id).FirstOrDefault();
                if(favorite == null)
                {
                    logger.LogError($"Favorite with id: {id} not found in db");
                    return NotFound();
                }

                repository.Favorite.Delete(favorite);
                repository.Save();
                logger.LogInfo($"Deleted favorite with id: {id}");

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside DeleteFavorite action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
