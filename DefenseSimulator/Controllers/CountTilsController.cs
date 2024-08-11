using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DefenseSimulator.Data;
using DefenseSimulator.Models;
using Azure;
using System.Data;

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
                try
                {
                    if (!_context.CountTil.Any())
                    {
                        _context.Add(countTil);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Threats");
                    }
                    var countTil1 = await _context.CountTil.FirstOrDefaultAsync();
                    countTil1.InterceptorMissile = countTil.InterceptorMissile;
                    countTil1.ElectronicJamming = countTil.ElectronicJamming;
                    countTil1.AntiAirSystem = countTil.AntiAirSystem;
                    _context.Update(countTil1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountTilExists(countTil.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Threats");

                //_context.Add(countTil);
                //await _context.SaveChangesAsync();
                //return RedirectToAction( "Index", "Threats");
            }
            return View(countTil);
        }
        private bool CountTilExists(int id)
        {
            return _context.CountTil.Any(e => e.Id == id);
        }
    }
}
