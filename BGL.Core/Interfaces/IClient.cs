using System.Threading.Tasks;
using BGL.Core.Entities;

namespace BGL.Core.Interfaces
{
    public interface IClient<out T> where T : new()
    {
        void Dispose();
        Task<Owner> GetuserInfoAsync(string username);
    }
}