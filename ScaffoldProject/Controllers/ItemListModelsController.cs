using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScaffoldProject.Data;
using ScaffoldProject.Models;

namespace ScaffoldProject.Controllers
{
    public class ItemListModelsController : Controller
    {
        private readonly ScaffoldProjectContext _context;

        public ItemListModelsController(ScaffoldProjectContext context)
        {
            _context = context;
        }

        // GET: ItemListModels
        public async Task<IActionResult> Index()
        {
              return _context.ItemListModel != null ? 
                          View(await _context.ItemListModel.ToListAsync()) :
                          Problem("Entity set 'ScaffoldProjectContext.ItemListModel'  is null.");
        }

        // GET: ItemListModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemListModel == null)
            {
                return NotFound();
            }

            var itemListModel = await _context.ItemListModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemListModel == null)
            {
                return NotFound();
            }

            return View(itemListModel);
        }

        // GET: ItemListModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemListModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Category,Price")] ItemListModel itemListModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemListModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemListModel);
        }

        // GET: ItemListModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemListModel == null)
            {
                return NotFound();
            }

            var itemListModel = await _context.ItemListModel.FindAsync(id);
            if (itemListModel == null)
            {
                return NotFound();
            }
            return View(itemListModel);
        }

        // POST: ItemListModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Category,Price")] ItemListModel itemListModel)
        {
            if (id != itemListModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemListModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemListModelExists(itemListModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(itemListModel);
        }

        // GET: ItemListModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemListModel == null)
            {
                return NotFound();
            }

            var itemListModel = await _context.ItemListModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemListModel == null)
            {
                return NotFound();
            }

            return View(itemListModel);
        }

        // POST: ItemListModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemListModel == null)
            {
                return Problem("Entity set 'ScaffoldProjectContext.ItemListModel'  is null.");
            }
            var itemListModel = await _context.ItemListModel.FindAsync(id);
            if (itemListModel != null)
            {
                _context.ItemListModel.Remove(itemListModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemListModelExists(int id)
        {
          return (_context.ItemListModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
