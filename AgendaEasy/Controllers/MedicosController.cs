using AgendaEasy.Context;
using AgendaEasy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaEasy.Controllers
{

    public class MedicosController : Controller
    {
        private readonly AppDbContext _context;

        public MedicosController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var medicos = _context.Medicos.ToList();
            var especialidades = _context.Especialidades.ToList();
            ViewBag.Especialidades = especialidades;

            return View(medicos);
        }

        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            Medico medico = new Medico();

            if (id != null)
            {
                medico = _context.Medicos.Find(id);
            }

            var especialidades = _context.Especialidades.ToList();
            ViewBag.Especialidades = especialidades;
            return View(medico);
        }


        [HttpPost]
        public ActionResult AddEdit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                if (medico.Id == 0)
                {
                    _context.Medicos.Add(medico);
                }
                else
                {
                    _context.Entry(medico).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            var especialidades = _context.Medicos.Include("Especialidade").ToList();
            ViewBag.Especialidades = especialidades;
            return View(medico);
        }

        public async Task<IActionResult> Visualiza(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(c => c.Especialidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }
}
