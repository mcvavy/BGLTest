using BGL.Infrastructure;
using BGL.UI.Common;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BGL.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationContext _context;

        public HomeController(IApplicationContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetPersonDetails(string username)
        {


            var response = await _context.GetuserInfoAsync(username);

            var person = RepoFilter.MappedPerson(response);

            return PartialView("_Persondetails", person);
        }
    }
}