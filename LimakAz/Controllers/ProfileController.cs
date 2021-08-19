using AutoMapper;
using Buisness.Abstract;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ISettingContentService _settingContentService;
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager
            , IMapper mapper,ISettingContentService settingContentService)
        {
            _userManager = userManager;
            _settingContentService = settingContentService;
            _mapper = mapper;
        }

        [HttpGet("getUserInfo/{userName}")]
        public async Task<IActionResult> GetUser([FromRoute] string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound();

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                BirthDay = user.BirthDay,
                City = user.City,
                SerialNumber = user.SerialNumber,
                Gender = user.Gender,
                FinCode = user.FinCode,
                Address = user.Address
            };

            return Ok(userDto);
        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            if (string.IsNullOrEmpty(user.Id))
                return BadRequest();

            var appUser = await _userManager.FindByIdAsync(user.Id);
            if (appUser == null)
                return NotFound();

            appUser.Name = user.Name;
            appUser.Surname = user.Surname;
            appUser.UserName = user.UserName;
            appUser.Email = user.Email;
            appUser.City = user.City;
            appUser.BirthDay = user.BirthDay;
            appUser.SerialNumber = user.SerialNumber;
            appUser.FinCode = user.FinCode;
            appUser.Address = user.Address;
            appUser.Gender = user.Gender;

            await _userManager.UpdateAsync(appUser);

            return Ok(new ResponseDto { Status = "Success", Message = "User successfully updated" });
        }

        [HttpGet("getSettingContent/{languageCode}")]
        public async Task<IActionResult> GetSettingContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var setting = await _settingContentService.GetSettingContentAsync(languageCode);
            if (setting == null)
                return NotFound();

            var settingDto = _mapper.Map<SettingContentDto>(setting);

            return Ok(settingDto);
        }
    }
}
