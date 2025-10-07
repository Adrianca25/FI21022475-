using Microsoft.AspNetCore.Mvc;
using PP2Web.Models;

namespace PP2Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: /
        [HttpGet]
        public IActionResult Index()
        {
            var model = new BinaryInputModel();
            return View(model);
        }

        // POST: /
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BinaryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                // Si hay errores de validación se mostrará la vista con mensajes
                return View(model);
            }

            // Preparar resultados
            var res = new BinaryResults
            {
                A = model.A,
                B = model.B,
                BinA8 = BinaryResults.PadTo8(model.A),
                BinB8 = BinaryResults.PadTo8(model.B)
            };

            // Realizar operaciones binarias sobre los 8 bits (según consigna)
            string a8 = res.BinA8;
            string b8 = res.BinB8;

            res.And = BinaryResults.BinaryAnd(a8, b8);
            res.Or = BinaryResults.BinaryOr(a8, b8);
            res.Xor = BinaryResults.BinaryXor(a8, b8);

            // Operaciones aritméticas (sum & mul) usando los valores como enteros (no necesariamente limitados a 8 bits)
            res.Sum = BinaryResults.BinarySum(a8, b8);
            res.Mul = BinaryResults.BinaryMul(a8, b8);

            model.Results = res;
            return View(model);
        }
    }
}

