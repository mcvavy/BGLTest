using AutoMapper;
using BGL.Core.Entities;
using BGL.UI.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BGL.UI.Common
{
    public static class RepoFilter
    {
        public static PersonDto MappedPerson(Owner response)
        {
            var person = Mapper.Map<PersonDto>(response);
            var repos = Mapper.Map<List<RepoDto>>(response.Repos).OrderByDescending(x => x.stargazers_count).Take(5);
            person.Repos.Clear();
            person.Repos.AddRange(repos.ToList());

            return person;
        }
    }
}