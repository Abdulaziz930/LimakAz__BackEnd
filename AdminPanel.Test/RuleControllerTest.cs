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
                            , CreationDate = DateTime.Now , LastModificationDate = DateTime.Now , LanguageId = 1 },
            };
        }

        [Theory]
        [InlineData(1, 5)]
        public async Task Index_ActionExecutes_ReturnProductList(int? page, int takeCount)
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
    }
}
