using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;

namespace recipebookserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public UserController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repositoryWrapper;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {
            try
            {
                var users = repository.User.GetUsers();
                logger.LogInfo($"Returned all users from DB");

                var usersResult = mapper.Map<IEnumerable<UserDto>>(users);
                return Ok(usersResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetUsers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserById(string id)
        {
            try
            {
                var user = repository.User.GetUserById(id);

                if(user == null)
                {
                    logger.LogError($"User with id: {id} not found in DB");
                    return NotFound();
                }

                logger.LogInfo($"Returned user with id: {id} from DB");

                var userResult = mapper.Map<UserDto>(user);
                return Ok(userResult);
            }
            catch(Exception ex)
            {
                logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/recipes")]
        public IActionResult GetUserByIdWithRecipes(string id)
        {
            try
            {
                var user = repository.User.GetUserByIdWithRecipes(id);

                if(user == null)
                {
                    logger.LogError($"User with id: {id} hasn't been found in the database");
                    return NotFound();
                }
                else
                {
                    logger.LogInfo($"Returned user with details for id: {id}");
                    var userResult = mapper.Map<UserWithRecipesDto>(user);
                    return Ok(userResult);
                }
            }
            catch(Exception ex)
            {
                logger.LogError($"Something went wrong inside GetUserByIdWithDetails for id: {id}, {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/favorites")]
        public IActionResult GetUserByIdWithFavorites(string id)
        {
            try
            {
                var user = repository.User.GetUserByIdWithFavorites(id);
                
                if(user == null)
                {
                    logger.LogError($"User with id: {id} hasn't been found in the database");
                    return NotFound();
                }
                else
                {
                    logger.LogInfo($"Returned user with favorites for id: {id}");
                    var userResult = mapper.Map<UserDetailsDto>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside GetUserByIdWithFavorites for id: {id}, {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateUser([FromBody]UserForCreationDto user)
        {
            if(user == null)
            {
                logger.LogError($"{nameof(CreateUser)}: User is null");
                return BadRequest("User object is null");
            }

            if (!ModelState.IsValid)
            {
                logger.LogError($"{nameof(CreateUser)}: User object is not valid");
                return BadRequest("User object is not valid");
            }

            var userEntity = mapper.Map<User>(user);
            repository.User.CreateUser(userEntity);
            repository.Save();

            var createdUser = mapper.Map<UserDto>(userEntity);
            return CreatedAtRoute(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }
    }
}
