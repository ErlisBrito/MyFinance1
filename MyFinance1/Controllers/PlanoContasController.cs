using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance1.Models;

namespace MyFinance1.Controllers
{
    public class PlanoContasController : Controller
    {
        IHttpContextAccessor HttpContextAccessor;

        
        public PlanoContasController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            PlanoContasModel objPlanoContas = new PlanoContasModel(HttpContextAccessor);
            ViewBag.ListaPlanoContas = objPlanoContas.ListaPlanoContas();
            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoContas(PlanoContasModel formulario)
        {
            if (ModelState.IsValid)
            {
                formulario.HttpContextAccessor = HttpContextAccessor;
                formulario.Insert();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoContas(int? id)
        {
            if (id != null)
            {
                PlanoContasModel objPlanoContas = new PlanoContasModel(HttpContextAccessor);
                ViewBag.Registro = objPlanoContas.CarregarRegistro(id);
            }
            return View();
        }

        public IActionResult ExcluirPlanoContas(int id)
        {
            PlanoContasModel objConta = new PlanoContasModel(HttpContextAccessor);
            objConta.Excluir(id);
            return RedirectToAction("Index");


        }

    }
}
