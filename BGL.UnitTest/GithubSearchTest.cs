using BGL.Core.Entities;
using BGL.Infrastructure.Repository;
using BGL.UI.Common;
using BGL.UI.Models.DTO;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BGL.UnitTest
{
    [TestFixture]
    public class GithubSearchTest
    {
        private MockRepository _factory;
        private ApplicationContext _context;
        private Mock<PersonDto> _persondto;
        [SetUp]
        public void SetUp()
        {
            _factory = new MockRepository(MockBehavior.Default);
            _persondto = _factory.Create<PersonDto>();
            _persondto.Setup(x => x.Repos).Returns(new List<RepoDto>
            {
                new RepoDto()
                {
                    html_url = "www.myurl.com",
                    description = "Testing things",
                    created_at = DateTime.Now.AddDays(-300).ToShortDateString(),
                    updated_at = DateTime.Now.AddDays(-12).ToShortDateString(),
                    stargazers_count = 255,
                    language = "C#",
                    forks = 7890
                },

                new RepoDto()
                {
                    html_url = "www.myurl.com",
                    description = "Testing things",
                    created_at = DateTime.Now.AddDays(-300).ToShortDateString(),
                    updated_at = DateTime.Now.AddDays(-12).ToShortDateString(),
                    stargazers_count = 347,
                    language = "JavaScript",
                    forks = 786
                },

                new RepoDto()
                {
                    html_url = "www.myurl.com",
                    description = "Testing things",
                    created_at = DateTime.Now.AddDays(-300).ToShortDateString(),
                    updated_at = DateTime.Now.AddDays(-12).ToShortDateString(),
                    stargazers_count = 99,
                    language = "Python",
                    forks = 45
                },

                new RepoDto()
                {
                    html_url = "www.myurl.com",
                    description = "Testing things",
                    created_at = DateTime.Now.AddDays(-300).ToShortDateString(),
                    updated_at = DateTime.Now.AddDays(-12).ToShortDateString(),
                    stargazers_count = 3,
                    language = "TypeScript",
                    forks = 13
                },

                new RepoDto()
                {
                    html_url = "www.myurl.com",
                    description = "Testing things",
                    created_at = DateTime.Now.AddDays(-300).ToShortDateString(),
                    updated_at = DateTime.Now.AddDays(-12).ToShortDateString(),
                    stargazers_count = 457,
                    language = "C#",
                    forks = 100978
                },

                 new RepoDto()
                {
                    html_url = "www.myurl.com",
                    description = "Testing things",
                    created_at = DateTime.Now.AddDays(-300).ToShortDateString(),
                    updated_at = DateTime.Now.AddDays(-12).ToShortDateString(),
                    stargazers_count = 457,
                    language = "C#",
                    forks = 100978
                }
            });

            _context = new ApplicationContext(new HttpClient());
            MapperConfig.RegisterMapping();



        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task RequestShouldReturnValuewithExisitingUsername()
        {
            var response = await _context.GetuserInfoAsync("robconery");

            response.ShouldNotBeNull();
        }


        [Test]
        [TestCase("OdeToCode")]
        [TestCase("robconery")]
        [TestCase("mosh-hamedani")]
        [TestCase("mcvavy")]
        [TestCase("julielerman")]
        public async Task RequestShouldReturnValuewithAllExisitingUsername(string username)
        {
            var response = await _context.GetuserInfoAsync("robconery");

            response.ShouldNotBeNull();
        }


        [Test]
        public async Task RequestShouldReturnNullValuewithNonExistingUsername()
        {
            var response = await _context.GetuserInfoAsync("whateverusernamexxgoeshere");

            response.ShouldBeNull();
        }

        [Test]
        public async Task RequestShouldReturnValueOfTypePersonDtoWithValidUsername()
        {
            var response = await _context.GetuserInfoAsync("robconery");

            response.ShouldBeOfType<Owner>();
        }


        [Test]
        public async Task RequestShouldReturnNoMorethanFiveRepos()
        {
            var response = await _context.GetuserInfoAsync("robconery");
            var model = RepoFilter.MappedPerson(response);

            model.Repos.Count().ShouldBeLessThanOrEqualTo(5);
        }

        [Test]
        public async Task EnteringEmptyStringShouldReturnNull()
        {
            var response = await _context.GetuserInfoAsync("");
            response.ShouldBeNull();
        }

        [Test]
        public async Task ReturnedPropertyShouldNotContainWhatUserDoesntNeedToSee()
        {
            var response = await _context.GetuserInfoAsync("robconery");
            var model = RepoFilter.MappedPerson(response);

            model.ShouldBeEquivalentTo(response, x => x.IncludingAllDeclaredProperties());
        }





    }
}
