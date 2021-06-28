using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance1.Controllers
{
    public class PlanoContasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
