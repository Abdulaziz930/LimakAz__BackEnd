using AutoMapper;
using Buisness.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorContentController : ControllerBase
    {
        private readonly ICalculatorInformationContentService _calculatorInformationContentService;
        private readonly ICurrencyContentService _currencyContentService;
        private readonly ICalculatorContentService _calculatorContentService;
        private readonly IMapper _mapper;

        public CalculatorContentController(ICalculatorInformationContentService calculatorInformationContentService
            ,ICurrencyContentService currencyContentService,ICalculatorContentService calculatorContentService,IMapper mapper)
        {
            _calculatorInformationContentService = calculatorInformationContentService;
            _currencyContentService = currencyContentService;
            _calculatorContentService = calculatorContentService;
            _mapper = mapper;
        }

        //GET: api/CalculatorContent/getCalculatorInformationContent/az
        [HttpGet("getCalculatorInformationContent/{languageCode}")]
        public async Task<IActionResult> GetCalculatorInformationContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var contents = await _calculatorInformationContentService.GetAllCalculatorIntormationContentsAsync(languageCode);
            if (contents == null)
                return NotFound();

            var contentsDto = _mapper.Map<List<CalculatorInformationContentDto>>(contents);

            return Ok(contentsDto);
        }

        //GET: api/CalculatorContent/getCurrency
        [HttpGet("getCurrency")]
        public async Task<IActionResult> GetCurrency()
        {
            var currency = await _currencyContentService.GetAllCurrencyContentsAsync();
            if (currency == null)
                return NotFound();

            var currencyDto = _mapper.Map<List<CurrencyContentDto>>(currency);

            return Ok(currencyDto);
        }

        //GET: api/CalculatorContent/getCalculatorContent/az
        [HttpGet("getCalculatorContent/{languageCode}")]
        public async Task<IActionResult> GetCalculatorContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var calculatorContent = await _calculatorContentService.GetCalculatorContentAsync(languageCode);
            if (calculatorContent == null)
                return NotFound();

            var calculatorContentDto = _mapper.Map<CalculatorContentDto>(calculatorContent);

            return Ok(calculatorContentDto);
        }
    }
}
