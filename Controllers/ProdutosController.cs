using Microsoft.AspNetCore.Mvc;
using CP01DOTNET_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace CP01DOTNET_MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private static List<Produto> _produtos = new List<Produto>();
        private static int _nextId = 1;

        // GET: Produtos
        public IActionResult Index()
        {
            return View(_produtos);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Preco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.Id = _nextId++;
                _produtos.Add(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _produtos.FirstOrDefault(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,Preco")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var index = _produtos.FindIndex(p => p.Id == id);
                    if (index != -1)
                    {
                       _produtos[index] = produto;
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _produtos.FirstOrDefault(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = _produtos.FirstOrDefault(m => m.Id == id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}