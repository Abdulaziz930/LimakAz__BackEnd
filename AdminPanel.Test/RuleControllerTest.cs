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
                new Language { Id = 1, Name = "Russian", Code = "RU", IsDeleted = false },
                new Language { Id = 1, Name = "English", Code = "EN", IsDeleted = false }
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
    }
}
