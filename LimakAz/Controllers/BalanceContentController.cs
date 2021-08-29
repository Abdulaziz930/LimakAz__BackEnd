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
    public class BalanceContentController : ControllerBase
    {
        private readonly IBalanceContentService _balanceContentService;
        private readonly IBalanceModalContentService _balanceModalContentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public BalanceContentController(IBalanceContentService balanceContentService
            ,IBalanceModalContentService balanceModalContentService ,IMapper mapper ,UserManager<AppUser> userManager)
        {
            _balanceContentService = balanceContentService;
            _balanceModalContentService = balanceModalContentService;
            _userManager = userManager;
            _mapper = mapper;
        }

        //GET: api/Balance/getBalanceContent/az
        [HttpGet("getBalanceContent/{languageCode}")]
        public async Task<IActionResult> GetBalanceCotent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var balanceContent = await _balanceContentService.GetBalanceContentAsync(languageCode);
            if (balanceContent == null)
                return NotFound();

            var balanceContentDto = _mapper.Map<BalanceContentDto>(balanceContent);

            return Ok(balanceContentDto);
        }

        //GET: api/Balance/getBalance/test
        [HttpGet("getBalance/{userName}")]
        public async Task<IActionResult> GetBalance([FromRoute] string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound();

            var balanceDto = new BalanceDto
            {
                Balance = user.Balance
            };

            return Ok(balanceDto);
        }

        //GET: api/Balance/getBalanceModalContent/az
        [HttpGet("getBalanceModalContent/{languageCode}")]
        public async Task<IActionResult> GetBalanceModalContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var balanceModalContent = await _balanceModalContentService.GetBalanceModalContentAsync(languageCode);
            if (balanceModalContent == null)
                return NotFound();

            var balanceModalContentDto = _mapper.Map<BalanceModalContentDto>(balanceModalContent);

            return Ok(balanceModalContentDto);
        }
    }
}
