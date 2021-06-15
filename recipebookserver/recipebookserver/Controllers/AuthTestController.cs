using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Contracts;
using AutoMapper;

namespace recipebookserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : Controller
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repository;
        private IMapper mapper;

        public AuthTestController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repositoryWrapper;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(new { Message = "Hello from a public endpoint. No auth required." });
        }

        [HttpGet("private")]
        [Authorize]
        public IActionResult Private()
        {
            var currentUser = HttpContext.User.Identity.Name;
            var user = repository.User.GetUserByAuthId(currentUser);

            if(user == null)
            {
                return NotFound("User not found");
            }

            return Ok(repository.Favorite.GetFavoritesByUserId(user.UserId).ToList());

            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated to see this."
            });
        }
    }
}