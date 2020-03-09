using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaEasy.Areas.Controllers
{
    [Area("Paciente")]
    [Authorize]
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
