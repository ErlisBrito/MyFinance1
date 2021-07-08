using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinance1.Models;

namespace MyFinance1.Controllers
{
    public class TransacaoController : Controller
    {

        IHttpContextAccessor HttpContextAccessor;


        public TransacaoController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            TransacaoModel objTransacao = new TransacaoModel(HttpContextAccessor);
            ViewBag.ListaTransacao = objTransacao.ListaTransacao();
            return View();
        }

        

        public IActionResult Extrato()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }

}
