﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proiectdaw.Entities;
using Proiectdaw.Entities.DTOs;
using Proiectdaw.Models.Constants;
using Proiectdaw.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        public readonly IUserService _userService;

        public AccountController(
            UserManager<User> userManager,
            IUserService userService)
        { _userManager = userManager;
            _userService = userService;
        }

        [HttpPost("register")]
       
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if(exists != null)
            {
                return BadRequest("User already registerd!");
            }

            var result = await _userService.RegisterUserAsync(dto);

            if(result)
            {
                return Ok(result);
            }
           

            return BadRequest();

        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);

            if(token ==null)
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }
    }
}
