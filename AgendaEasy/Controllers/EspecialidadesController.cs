using AgendaEasy.Context;
using AgendaEasy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaEasy.Controllers
{
   
    public class EspecialidadesController : Controller
    {

        private readonly AppDbContext _context;

        public EspecialidadesController(AppDbContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            var especialidades = _context.Especialidades.ToList();

           
                return View(especialidades);
        }

        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            Especialidade especialidade = new Especialidade();

            if (id != null)
            {
                especialidade = _context.Especialidades.Find(id);
            }

            return View(especialidade);
        }

        [HttpPost]
        public ActionResult AddEdit(Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                if (especialidade.Id == 0)
                {
                    _context.Especialidades.Add(especialidade);
                }
                else
                {
                    _context.Entry(especialidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(especialidade);
        }


        public async Task<IActionResult> Visualiza(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidade = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidade == null)
            {
                return NotFound();
            }

            return View(especialidade);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




    }
}
