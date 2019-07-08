using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace serviceAssistants.Controllers
{
    public class RepairHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepairHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RepairHistories
        public async Task<IActionResult> Index(int?id)
        {
            if (id != null)
            {
                var foundVehicles = _context.RepairHistories.Where(c => c.VehicleId == id);
                return View(await foundVehicles.ToListAsync());
            }
            else
            {
                return View(await _context.Vehicles.ToListAsync());
            }
        }

        // GET: RepairHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairHistory = await _context.RepairHistories
                .Include(r => r.Employee)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairHistory == null)
            {
                return NotFound();
            }

            return View(repairHistory);
        }

        // GET: RepairHistories/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id");
            return View();
        }

        // POST: RepairHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,Cost,RepairOrder,EmployeeId,VehicleId")] RepairHistory repairHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", repairHistory.EmployeeId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", repairHistory.VehicleId);
            return View(repairHistory);
        }

        // GET: RepairHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairHistory = await _context.RepairHistories.FindAsync(id);
            if (repairHistory == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", repairHistory.EmployeeId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", repairHistory.VehicleId);
            return View(repairHistory);
        }

        // POST: RepairHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,Cost,RepairOrder,EmployeeId,VehicleId")] RepairHistory repairHistory)
        {
            if (id != repairHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairHistoryExists(repairHistory.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", repairHistory.EmployeeId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", repairHistory.VehicleId);
            return View(repairHistory);
        }

        // GET: RepairHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairHistory = await _context.RepairHistories
                .Include(r => r.Employee)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairHistory == null)
            {
                return NotFound();
            }

            return View(repairHistory);
        }

        // POST: RepairHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repairHistory = await _context.RepairHistories.FindAsync(id);
            _context.RepairHistories.Remove(repairHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairHistoryExists(int id)
        {
            return _context.RepairHistories.Any(e => e.Id == id);
        }
    }
}
