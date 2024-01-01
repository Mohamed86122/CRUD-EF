using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using WebApplication67.Data;
using WebApplication67.Models;

namespace WebApplication67.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Client> obj = _context.Clients;
           
            return View(obj);
        }
        public IActionResult Create()
        {
           
            return View(new Client());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client client = _context.Clients.SingleOrDefault(x => x.IdClient == id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client client)
        {
            
                Client cl = _context.Clients.SingleOrDefault(x => x.IdClient == client.IdClient);

                if (cl != null)
                {
                   
                    _context.Update(cl);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            

            return View(client);
        }
        public IActionResult Delete(int? id)
        {
          
            Client client = _context.Clients.Find(id);
            
            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id,Client client)
        {
            var cl =
              _context.Clients.Where(x => x.IdClient == id).SingleOrDefault();
            if (cl != null)
            {
                _context.Clients.Remove(cl);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        }
       

    }
}
