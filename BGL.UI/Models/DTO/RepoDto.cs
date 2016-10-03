namespace BGL.UI.Models.DTO
{
    public class RepoDto
    {
        public PersonDto Person { get; set; } = new PersonDto();
        public string html_url { get; set; }
        public string description { get; set; }

        public string created_at { get; set; }
        public string updated_at { get; set; }

        public int stargazers_count { get; set; }

        public string language { get; set; }

        public int forks { get; set; }
    }
}