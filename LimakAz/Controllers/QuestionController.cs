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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IQuestionContentService _questionContentService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService,IQuestionContentService questionContentService,IMapper mapper)
        {
            _questionService = questionService;
            _questionContentService = questionContentService;
            _mapper = mapper;
        }

        //GET: api/Question/getQuestions/az
        [HttpGet("getQuestions/{languageCode}")]
        public async Task<IActionResult> GetQuestion([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var questions = await _questionService.GetAllQuestionsAsync(languageCode);
            if (questions == null)
                return NotFound();

            var questionsDto = _mapper.Map<List<QuestionDto>>(questions);

            return Ok(questionsDto);
        }

        //GET: api/Question/getQuestionContent/az
        [HttpGet("getQuestionContent/{languageCode}")]
        public async Task<IActionResult> GetQuestionContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var questionContent = await _questionContentService.GeQuestionContentAsync(languageCode);
            if (questionContent == null)
                return NotFound();

            var questionContentDto = _mapper.Map<QuestionContentDto>(questionContent);

            return Ok(questionContentDto);
        }
    }
}
