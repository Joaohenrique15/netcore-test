using AgendaEasy.Context;
using AgendaEasy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaEasy.Controllers
{
    [Area("Paciente")]
    public class PacienteProntuariosController : Controller
    {

        private readonly AppDbContext _context;

        public PacienteProntuariosController(AppDbContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            var prontuarios = _context.Prontuarios.ToList();
            return View(prontuarios);
        }

        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            Prontuario prontuario = new Prontuario();

            if (id != null)
            {
                prontuario = _context.Prontuarios.Find(id);
            }

            return View(prontuario);
        }

        [HttpPost]
        public ActionResult AddEdit(Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                if (prontuario.Id == 0)
                {
                    _context.Prontuarios.Add(prontuario);
                }
                else
                {
                    _context.Entry(prontuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(prontuario);
        }


        public ActionResult Del(int id)
        {

            var prontuario = _context.Prontuarios.Find(id);
            if (prontuario == null)
            {
                return NotFound();
            }

            _context.Prontuarios.Remove(prontuario);
            _context.SaveChanges();

            return null;
        }

        public async Task<IActionResult> Visualiza(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




    }
}
