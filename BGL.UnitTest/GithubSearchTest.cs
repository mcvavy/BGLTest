﻿using BGL.Core.Entities;
using BGL.Infrastructure.Repository;
using BGL.UI.Common;
using NUnit.Framework;
using Shouldly;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BGL.UnitTest
{
    [TestFixture]
    public class GithubSearchTest
    {
        private ApplicationContext _context;
        [SetUp]
        public void SetUp()
        {

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

            model.ShouldNotBeSameAs(response);
        }

    }
}
