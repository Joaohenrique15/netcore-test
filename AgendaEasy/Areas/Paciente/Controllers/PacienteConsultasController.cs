using AgendaEasy.Context;
using AgendaEasy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaEasy.Controllers
{
    [Area("Paciente")]
    public class PacienteConsultasController : Controller
    {
        private readonly AppDbContext _context;

        public PacienteConsultasController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index(string filtro, string op)
        {
            ViewData["filtro"] = filtro;
            var consultas = _context.Consultas.AsEnumerable();
            if (!String.IsNullOrEmpty(filtro))
            {
                if (op == "med")
                    consultas = consultas.Where(est => est.Medicos.Nome.ToUpper().Contains(filtro.ToUpper()));
                else
                    consultas = consultas.Where(est => est.Prontuarios.Nome.ToUpper().Contains(filtro.ToUpper()));
            }
            var prontuarios = _context.Prontuarios.ToList();
            ViewBag.Prontuarios = prontuarios;
            var especialidades = _context.Especialidades.ToList();
            ViewBag.Especialidades = especialidades;
            var medicos = _context.Medicos.ToList();
            ViewBag.Medicos = medicos;

            return View(consultas);


        }


        [HttpGet]
        public ViewResult AddEdit(int? id)
        {
            Consulta consulta = new Consulta();

            if (id != null)
            {
                consulta = _context.Consultas.Find(id);
            }

            var prontuarios = _context.Prontuarios.ToList();
            ViewBag.Prontuarios = prontuarios;
            var especialidades = _context.Especialidades.ToList();
            ViewBag.Especialidades = especialidades;
            var medicos = _context.Medicos.Include("Especialidade").ToList();
            ViewBag.Medicos = medicos;
            return View(consulta);
        }


        [HttpPost]
        public ActionResult AddEdit(Consulta consulta)
        {

            if (ModelState.IsValid)
            {
                if (consulta.Id == 0)
                {
                    var verificaAgenda = _context.Consultas.Where(d => d.DataHora.Equals(consulta.DataHora) && d.MedicoId == consulta.MedicoId).FirstOrDefault(i => i.MedicoId == consulta.MedicoId);

                    if (verificaAgenda == null)
                    {
                        _context.Consultas.Add(consulta);
                    }
                    else
                    {
                        return RedirectToAction("AddEdit", "Consultas");
                    }
                }
                else
                {
                    _context.Entry(consulta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            var prontuarios = _context.Prontuarios.ToList();
            ViewBag.Prontuarios = prontuarios;

            var especialidades = _context.Especialidades.ToList();
            //ViewBag.Consultas = _context.Consultas.Include("Medico").Include("Especialidade").ToList();
            ViewBag.Especialidades = especialidades;
            var medicos = _context.Medicos.ToList();
            ViewBag.Medicos = medicos;
            return View(consulta);
        }


        public ActionResult DelMed(int id)
        {

            var consulta = _context.Consultas.Find(id);
            if (consulta == null)
            {
                return NotFound();
            }
            _context.Consultas.Remove(consulta);
            _context.SaveChanges();

            return null;
        }

        public async Task<IActionResult> Visualiza(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Especialidade)
                .Include(c => c.Medicos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}
