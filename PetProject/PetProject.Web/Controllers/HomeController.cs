using Microsoft.AspNetCore.Mvc;

namespace PetProject.Web.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("index/{id}")]
        public IResult Index(int id)
        {
            return Results.Text($"everythings good! {id}!");
        }
    }
}
