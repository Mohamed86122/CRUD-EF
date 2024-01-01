using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication67.Data;
using WebApplication67.Models;

namespace WebApplication67.Controllers
{
    public class CommandeController : Controller
    {


        private readonly AppDbContext _context;

        public CommandeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Commandes.Include(c => c.Client).ToList());
            
        }
        public IActionResult Create()
        {
            ViewBag.Clients = new SelectList(_context.Clients, "ClientId", "Nom");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Commande commande)
        {
            if (ModelState.IsValid)
            {
                _context.Commandes.Add(commande);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clients = new SelectList(_context.Clients, "ClientId", "Nom", commande.ClientId);
            return View(commande);
        }


    }
}
