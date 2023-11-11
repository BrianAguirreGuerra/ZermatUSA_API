using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            ML.Result result = BL.Productos.GetAllProductos();

            if (result.Correct)
            {
                return View(result.Objects);
            }
            else
            {
                TempData["Message"] = $"Error: {result.ErrorMessage}";
                TempData["IsError"] = true;
                return View();
            }
        }
    }
}
