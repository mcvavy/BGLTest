using System.Threading.Tasks;
using BGL.Core.Entities;

namespace BGL.Core.Interfaces
{
    public interface IApplicationContext
    {
        void Dispose();
        Task<Owner> GetuserInfoAsync(string username);
    }
}