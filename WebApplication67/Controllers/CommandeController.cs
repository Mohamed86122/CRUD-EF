using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication67.Data;
using WebApplication67.Models;

public class CommandeController : Controller
{
    private readonly AppDbContext _context;

    public CommandeController(AppDbContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {

        return View(_context.Commandes.Include(c => c.Client).ToList());
    }

    public IActionResult Create()
    {
        ViewBag.Clients = new SelectList(_context.Clients, "IdClient", "NomComplet");
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Commande commande)
    {
        try
        {
            _context.Commandes.Add(commande);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (DbUpdateException ex)
        {
            // Log the exception or handle it based on your application's needs.
            // Example: Check if it's a unique constraint violation.
            if (IsUniqueConstraintViolation(ex))
            {
                ModelState.AddModelError("Libelle", "A command with the same Libelle already exists.");
            }
            else
            {
                // Handle other exceptions.
                ModelState.AddModelError("", "An error occurred while saving the command.");
            }

            // Re-populate ViewBag.Clients and return the view with errors.
            ViewBag.Clients = new SelectList(_context.Clients, "IdClient", "NomComplet", commande.ClientId);
            return View(commande);
        }
    }

    private bool IsUniqueConstraintViolation(DbUpdateException ex)
    {
        throw new NotImplementedException();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var commande = _context.Commandes.Find(id);

        if (commande == null)
        {
            return NotFound();
        }

        ViewBag.Clients = new SelectList(_context.Clients, "IdClient", "NomComplet", commande.ClientId);
        return View(commande);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Commande commande)
    {
        if (id != commande.IdCommande)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Entry(commande).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(commande.IdCommande))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }

        ViewBag.Clients = new SelectList(_context.Clients, "IdClient", "NomComplet", commande.ClientId);
        return View(commande);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var commande = _context.Commandes.Include(c => c.Client).FirstOrDefault(c => c.IdCommande == id);

        if (commande == null)
        {
            return NotFound();
        }

        return View(commande);
    }

    [HttpPost, ActionName("Delete")]
 
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var commande = _context.Commandes.Find(id);

        if (commande == null)
        {
            return NotFound();
        }

        _context.Commandes.Remove(commande);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }


    private bool CommandeExists(int id)
    {
        return _context.Commandes.Any(c => c.IdCommande == id);
    }
}
