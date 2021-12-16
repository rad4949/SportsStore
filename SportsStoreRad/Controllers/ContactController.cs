using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportsStoreRad.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
