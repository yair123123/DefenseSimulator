using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DefenseSimulator.Data;
using DefenseSimulator.Models;

namespace DefenseSimulator.Controllers
{
    public class ThreatsController : Controller
    {
        private readonly DefenseSimulatorContext _context;
        public ThreatsController(DefenseSimulatorContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var defenseSimulatorContext = _context.Threat.Include(t => t.State).Include(t => t.Weapon);
            return View(await defenseSimulatorContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threat = await _context.Threat
                .Include(t => t.State)
                .Include(t => t.Weapon)
                .FirstOrDefaultAsync(m => m.ThreatId == id);
            if (threat == null)
            {
                return NotFound();
            }

            return View(threat);
        }
        public IActionResult Create()
        {
            ViewData["State"] = new SelectList(_context.States, "Id", "Name");
            ViewData["Weapons"] = new SelectList(_context.Weapon, "WeaponId", "Type");
            ViewData["City"] = new SelectList(_context.Cities, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateId,LaunchTime,WeaponId,CityId")] Threat threat)
        {
            ModelState.Remove("city");
            ModelState.Remove("State");
            ModelState.Remove("Weapon");
            ModelState.Remove("Target");

            var weapon = _context.Weapon.Find(threat.WeaponId);
            threat.Target = weapon.Type;

            if (ModelState.IsValid)
            {
                _context.Add(threat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["State"] = new SelectList(_context.States, "Name", "Name", threat.StateId);
            ViewData["Weapon"] = new SelectList(_context.Weapon, "CounterMeasure", "CounterMeasure", threat.WeaponId);
            return View(threat);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threat = await _context.Threat.FindAsync(id);
            if (threat == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.Set<States>(), "Id", "Id", threat.StateId);
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "WeaponId", "CounterMeasure", threat.WeaponId);
            return View(threat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThreatId,StateId,LaunchTime,WeaponId,Status")] Threat threat)
        {
            if (id != threat.ThreatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreatExists(threat.ThreatId))
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
            ViewData["StateId"] = new SelectList(_context.Set<States>(), "Id", "Id", threat.StateId);
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "WeaponId", "CounterMeasure", threat.WeaponId);
            return View(threat);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threat = await _context.Threat
                .Include(t => t.State)
                .Include(t => t.Weapon)
                .FirstOrDefaultAsync(m => m.ThreatId == id);
            if (threat == null)
            {
                return NotFound();
            }

            return View(threat);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var threat = await _context.Threat.FindAsync(id);
            if (threat != null)
            {
                _context.Threat.Remove(threat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreatExists(int id)
        {
            return _context.Threat.Any(e => e.ThreatId == id);
        }
    }
}
