using BGL.Core.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace BGL.Infrastructure
{
    public interface IApplicationContext
    {
        void Dispose();
        Task<Owner> GetuserInfoAsync(string username);
    }

    public class ApplicationContext : GitHttpClient, IApplicationContext
    {
        public ApplicationContext(HttpClient client) : base(client)
        {
        }
    }
}
