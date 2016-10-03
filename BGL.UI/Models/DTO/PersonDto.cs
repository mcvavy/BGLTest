using System.Collections.Generic;

namespace BGL.UI.Models.DTO
{
    public class PersonDto
    {
        public string login { get; set; }
        public string avatar_url { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public List<RepoDto> Repos { get; set; } = new List<RepoDto>();
    }
}