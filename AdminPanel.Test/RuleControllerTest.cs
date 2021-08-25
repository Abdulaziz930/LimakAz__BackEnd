using AdminPanel.Controllers;
using Buisness.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdminPanel.Test
{
    public class RuleControllerTest
    {
        private readonly Mock<IRuleService> _mockRuleService;
        private readonly Mock<ILanguageService> _mockLanguageService;
        private readonly RuleController _ruleController;
        private readonly List<Language> _languages;
        private readonly List<Rule> _rules;

        public RuleControllerTest()
        {
            _mockRuleService = new Mock<IRuleService>();
            _mockLanguageService = new Mock<ILanguageService>();
            _ruleController = new RuleController(_mockRuleService.Object, _mockLanguageService.Object);
            _languages = new List<Language>()
            {
                new Language { Id = 1, Name = "Azerbaijani", Code = "AZ", IsDeleted = false },
                new Language { Id = 2, Name = "Russian", Code = "RU", IsDeleted = false },
                new Language { Id = 3, Name = "English", Code = "EN", IsDeleted = false }
            };
            _rules = new List<Rule>()
            {
                new Rule { Id = 1, Title = "İstifadəçi  qaydaları", Content = "lorem 1 az", IsDeleted = false
                            , CreationDate = DateTime.Now , LastModificationDate = DateTime.Now , LanguageId = 1 },
                new Rule { Id = 2, Title = "Правила пользователя", Content = "lorem 1 ru", IsDeleted = false
                            , CreationDate = DateTime.Now , LastModificationDate = DateTime.Now , LanguageId = 2 },
                new Rule { Id = 3, Title = "User rules", Content = "lorem 1 en", IsDeleted = false
                            , CreationDate = DateTime.Now , LastModificationDate = DateTime.Now , LanguageId = 3 },
            };
        }

        [Theory]
        [InlineData(1, 5)]
        public async Task Index_ActionExecutes_ReturnRuleList(int? page, int takeCount)
        {
            int skipCount = (page.Value - 1) * 5;

            _mockRuleService.Setup(service => service.GetAllRulesAsync()).ReturnsAsync(_rules);
            _mockRuleService.Setup(service => service.GetAllRulesAsync(skipCount, takeCount)).ReturnsAsync(_rules);

            var result = await _ruleController.Index(page.Value);

            var viewResult = Assert.IsType<ViewResult>(result);

            var rules = Assert.IsAssignableFrom<IEnumerable<Rule>>(viewResult.Model);
        }

        [Theory]
        [InlineData(0, 5)]
        public async Task Index_PageLessThanZero_ReturnNotFound(int? page, int takeCount)
        {
            int skipCount = (page.Value - 1) * 5;

            _mockRuleService.Setup(service => service.GetAllRulesAsync()).ReturnsAsync(_rules);
            _mockRuleService.Setup(service => service.GetAllRulesAsync(skipCount, takeCount)).ReturnsAsync(_rules);

            var result = await _ruleController.Index(page.Value);

            var error = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, error.StatusCode);
        }

        [Fact]
        public async Task Detail_IdIsNull_ReturnNotFound()
        {
            var result = await _ruleController.Detail(null);

            var error = Assert.IsType<BadRequestResult>(result);

            Assert.Equal<int>(400, error.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async Task Detail_IdIsInvalid_ReturnNotFound(int? id)
        {
            Rule rule = null;

            _mockRuleService.Setup(service => service.GetRuleWithLanguageAsync(id.Value)).ReturnsAsync(rule);

            var result = await _ruleController.Detail(id.Value);

            var error = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, error.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async Task Detail_ValidId_ReturnRule(int? id)
        {
            var rule = _rules.FirstOrDefault(x => x.Id == id.Value);

            _mockRuleService.Setup(service => service.GetRuleWithLanguageAsync(id.Value)).ReturnsAsync(rule);

            var result = await _ruleController.Detail(id);

            var viewResult = Assert.IsType<ViewResult>(result);

            var resultRule = Assert.IsAssignableFrom<Rule>(viewResult.Model);

            Assert.Equal(rule.Id, resultRule.Id);
        }

        [Theory]
        [InlineData(1)]
        public async Task CreatePOST_InValidModelState_ReturnView(int? languageId)
        {
            _ruleController.ModelState.AddModelError("Title", "Title is required");

            var result = await _ruleController.Create(_rules.First(), languageId);

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsType<Rule>(viewResult.Model);
        }

        [Fact]
        public async Task CreatePOST_ValidModelState_RedirectToIndexAction()
        {
            _mockLanguageService.Setup(service => service.GetAllLanguagesAsync(null)).ReturnsAsync(_languages);

            var result = await _ruleController.Create(_rules.First(), 1);

            var redirect = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirect.ActionName);
        }

        [Fact]
        public async Task CreatePOST_ValidModelState_CreateMethodExecutute()
        {
            Rule newRule = null;

            _mockLanguageService.Setup(service => service.GetAllLanguagesAsync(null)).ReturnsAsync(_languages);
            _mockRuleService.Setup(service => service.AddAsync(It.IsAny<Rule>())).Callback<Rule>(x => x = newRule);

            var result = await _ruleController.Create(_rules.First(), 1);

            _mockRuleService.Verify(service => service.AddAsync(It.IsAny<Rule>()), Times.Once);
        }

        [Theory]
        [InlineData(4)]
        public async Task CreatePOST_InvalidLanguageId_ReturnBadRequest(int? languageId)
        {
            _mockLanguageService.Setup(service => service.GetAllLanguagesAsync(null)).ReturnsAsync(_languages);

            var result = await _ruleController.Create(_rules.First(), languageId.Value);

            var error = Assert.IsType<BadRequestResult>(result);

            Assert.Equal(400, error.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdatePOST_IdIsNotEqualRule_ReturnBadRequest(int? id)
        {
            var result = await _ruleController.Update(2, _rules.First(x => x.Id == id.Value), 1);

            var error = Assert.IsType<BadRequestResult>(result);

            Assert.Equal(400, error.StatusCode);
        }

        [Fact]
        public async Task UpdatePOST_IdIsNull_ReturnBadRequest()
        {
            var result = await _ruleController.Update(null, _rules.First(), 1);

            var error = Assert.IsType<BadRequestResult>(result);

            Assert.Equal(400, error.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdatePOST_InValidModelState_ReturnView(int? id)
        {
            _ruleController.ModelState.AddModelError("Title", "");

            _mockLanguageService.Setup(service => service.GetAllLanguagesAsync(null)).ReturnsAsync(_languages);
            _mockRuleService.Setup(service => service.GetRuleWithLanguageAsync(1)).ReturnsAsync(_rules.First());

            var result = await _ruleController.Update(id, _rules.First(x => x.Id == id), 1);

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsType<Rule>(viewResult.Model);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdatePOST_ValidModelState_ReturnRedirectToIndexAction(int? id)
        {
            _mockLanguageService.Setup(service => service.GetAllLanguagesAsync(null)).ReturnsAsync(_languages);
            _mockRuleService.Setup(service => service.GetRuleWithLanguageAsync(1)).ReturnsAsync(_rules.First());

            var result = await _ruleController.Update(id.Value, _rules.First(x => x.Id == id), 1);

            var redirect = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirect.ActionName);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdatePOST_ValidModelState_UpdateMethodExecute(int? id)
        {
            var rule = _rules.First(x => x.Id == id.Value);

            _mockLanguageService.Setup(service => service.GetAllLanguagesAsync(null)).ReturnsAsync(_languages);
            _mockRuleService.Setup(service => service.GetRuleWithLanguageAsync(1)).ReturnsAsync(_rules.First());
            _mockRuleService.Setup(service => service.UpdateAsync(rule));

            await _ruleController.Update(id, rule, 1);

            _mockRuleService.Verify(service => service.UpdateAsync(It.IsAny<Rule>()), Times.Once);
        }

        [Fact]
        public async Task UpdatePOST_LanguageIdIsNull_ReturnView()
        {
            _mockLanguageService.Setup(service => service.GetAllLanguagesAsync(null)).ReturnsAsync(_languages);
            _mockRuleService.Setup(service => service.GetRuleWithLanguageAsync(1)).ReturnsAsync(_rules.First());

            var result = await _ruleController.Update(1, _rules.First(), null);

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsType<Rule>(viewResult.Model);
        }

        [Theory]
        [InlineData(4)]
        public async Task UpdatePOST_InvalidLanguageId_ReturnBadRequest(int? languageId)
        {
            _mockLanguageService.Setup(service => service.GetAllLanguagesAsync(null)).ReturnsAsync(_languages);
            _mockRuleService.Setup(service => service.GetRuleWithLanguageAsync(1)).ReturnsAsync(_rules.First());

            var result = await _ruleController.Update(1,_rules.First(), languageId.Value);

            var error = Assert.IsType<BadRequestResult>(result);

            Assert.Equal(400, error.StatusCode);
        }
    }
}
