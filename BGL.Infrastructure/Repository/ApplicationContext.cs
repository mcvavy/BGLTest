using System.Net.Http;
using BGL.Core.Interfaces;

namespace BGL.Infrastructure.Repository
{
    public class ApplicationContext : GitHttpClient, IApplicationContext
    {
        public ApplicationContext(HttpClient client) : base(client)
        {
        }
    }
}
