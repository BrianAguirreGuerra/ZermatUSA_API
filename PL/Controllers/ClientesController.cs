using Microsoft.AspNetCore.Mvc;
using DL; 

namespace PL.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(DL.Cliente cliente)
        {
            ML.Result result = BL.Clientes.AddCliente(cliente);

            if (result.Correct)
            {
                TempData["Message"] = "Cliente registrado exitosamente";
                return RedirectToAction("Registro");
            }
            else
            {
                TempData["Message"] = $"{result.ErrorMessage}";
                TempData["IsError"] = true; 
                return View("Registro", cliente);
            }
        }

        public IActionResult FormLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            ML.Result result = BL.Clientes.GetByEmail(email);

            if (result.Correct)
            {

                DL.Cliente cliente = result.Object as DL.Cliente;


                if (cliente != null && cliente.Pass == password)
                {
                    return RedirectToAction("Index", "Producto");
                }
                else
                {
                    TempData["Message"] = "La contraseña introducida es incorrecta.";
                    TempData["IsError"] = true;
                }
            }
            else
            {
                TempData["Message"] = $"{result.ErrorMessage}";
                TempData["IsError"] = true;
            }

            return RedirectToAction("FormLogin");
        }
    }
}

