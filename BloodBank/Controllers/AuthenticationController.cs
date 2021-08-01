using BloodBank.Dto;
using BloodBank.Models.Model.Authentication;
using BloodBank.Models.Model.Authentication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signInMangaer;
        private readonly ITokenService _tokenService;

        public AuthenticationController(UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser> signInMangaer,
            ITokenService tokenService)
        {
            _usermanager = usermanager;
            _signInMangaer = signInMangaer;
            _tokenService = tokenService;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register([FromBody]RegisterModel register)
        {
            var userExist =await _usermanager.FindByEmailAsync(register.Email);

            if(userExist != null)           
                return StatusCode(StatusCodes.Status500InternalServerError);
            
            ApplicationUser user = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.UserName,
                Email = register.Email,                
                PhoneNumber = register.PhoneNumber
            };

            var result =await _usermanager.CreateAsync(user, register.Password);
            //assining to users Role as default

           

            var results =    await _usermanager.AddToRoleAsync(user, UserRole.User);

            if (!result.Succeeded && !results.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);      

            return new AuthenticationResponse
            {
                UserName = user.UserName,
                Message = "Register Successfull",
                Token = _tokenService.CreateToken(user)
            }; 
         }

        //registering a user for admin to assign roles
        [Authorize(Roles =UserRole.Admin)]
        [HttpPost]
        [Route("admin-reg")]
        public async Task<ActionResult<AuthenticationResponse>> RegisterUserWithRole(AdminRegisterDto register)
        {
            if(register != null && register.Role != null)
            {
                var EmailExist = await _usermanager.FindByEmailAsync(register.Email);

                if (EmailExist != null) return StatusCode(409);

                var user = new ApplicationUser
                {
                    UserName = register.UserName,
                    Email = register.Email,
                    PhoneNumber = register.PhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                //add to user
                var result = await _usermanager.CreateAsync(user, register.Password);
                bool roleAdd = false ;
                //adding user to role
                if(register.Role == UserRole.Admin)
                {
                    await _usermanager.AddToRoleAsync(user, UserRole.Admin);
                    roleAdd = true;
                }
                if(register.Role == UserRole.User)
                {
                    await _usermanager.AddToRoleAsync(user, UserRole.User);
                    roleAdd = true;
                }

                if (!result.Succeeded && roleAdd == false) return StatusCode(500);

                return new AuthenticationResponse
                {
                    Message = "user Created successfully with " + register.Role + "role",
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }

            return StatusCode(500);
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] LoginModel login)
        {
            var user = await _usermanager.FindByEmailAsync(login.Email);
            if (user == null) return Unauthorized();

            var result = await _signInMangaer.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded) return Unauthorized();

            return new AuthenticationResponse
            {
                UserName = user.UserName,
                Message = "Login successFul",            

                Token = _tokenService.CreateToken(user)

            };


        }
    }
}
