using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class StoreController : BaseController
    {
        [HttpGet] public ActionResult Index(string name = "", string category = "", string sort = "", int? page = 1, int? itemsPerPage = 10 ) => View();
        [HttpGet] public ActionResult Product(int? idProduct) => View();
    }
}