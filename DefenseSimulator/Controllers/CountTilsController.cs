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
    public class CountTilsController : Controller
    {
        private readonly DefenseSimulatorContext _context;

        public CountTilsController(DefenseSimulatorContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create()
        {
            var countTil = await _context.CountTil
                .FirstOrDefaultAsync();
            return View(countTil);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ElectronicJamming,AntiAirSystem,InterceptorMissile")] CountTil countTil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countTil);
                await _context.SaveChangesAsync();
                return RedirectToAction( "Index", "Threats");
            }
            return View(countTil);
        }
    }
}
