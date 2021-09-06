using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.WeekOpdracht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger logger;

        public UserController(IUserService userService, ILogger logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                var saved = userService.Add(user);

                return Ok(saved);
            }
            catch (Exception ex)
            {
                logger.write(ex);
                return BadRequest(new
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(userService.Get(id));
            }
            catch (Exception ex)
            {
                logger.write(ex);
                return BadRequest(new
                {
                    Message = ex.Message,
                });
            }
        }

    }
}
