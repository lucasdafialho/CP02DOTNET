using Microsoft.AspNetCore.Mvc;
using CP01DOTNET_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace CP01DOTNET_MVC.Controllers
{
    public class ClientesController : Controller
    {
        private static List<Cliente> _clientes = new List<Cliente>();
        private static int _nextId = 1;

        // GET: Clientes
        public IActionResult Index()
        {
            return View(_clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Email")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = _nextId++;
                _clientes.Add(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _clientes.FirstOrDefault(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,Email")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var index = _clientes.FindIndex(c => c.Id == id);
                    if (index != -1)
                    {
                       _clientes[index] = cliente;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch
                {
                    // Log the error or handle it appropriately
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _clientes.FirstOrDefault(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = _clientes.FirstOrDefault(m => m.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}