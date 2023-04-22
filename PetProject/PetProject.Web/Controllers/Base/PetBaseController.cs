using Microsoft.AspNetCore.Mvc;

namespace PetProject.Web.Controllers.Base
{
    public class PetBaseController : Controller
    {
        public PetBaseController()
        {

        }

        protected bool CheckToken()
        {



            return true;
        }
    }
}
