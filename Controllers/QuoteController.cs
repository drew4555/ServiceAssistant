﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using serviceAssistants.Models;
using Infrastructure;


namespace serviceAssistants.Controllers
{
    public class QuoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quote
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                var foundQuotes = _context.Quotes.Where(q => q.VehicleId == id);
                return View(await foundQuotes.ToListAsync());
            }
            else
            {
                return View(await _context.Quotes.ToListAsync());
            }
        }

        // GET: Quote/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            QuoteViewModel qvm = new QuoteViewModel();
            qvm.Quote = quote;
            var services = _context.Services.Where(s => s.QuoteNumber == id).ToArray();
            qvm.Services = services;
            return View(qvm);
        }

        // GET: Quote/Create
        public IActionResult Create(int id)
        {
            Quote quote = new Quote();
            quote.VehicleId = id;
            return View(quote);
        }

        // POST: Quote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                quote.Id = 0;
                quote.TechId = 1;
                _context.Quotes.Add(quote);
                await _context.SaveChangesAsync();
                if (this.User.IsInRole("Tech"))
                {
                    var response2 = SendSimpleMessageChunk.SendPartMessage();
                }
                return RedirectToAction("Create","Service");
            }
            return View(quote);
        }

        // GET: Quote/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }

        // POST: Quote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Quote quote)
        {
            if (id != quote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                    if (this.User.IsInRole("Tech"))
                    {
                        var response = SendSimpleMessageChunk.SendPartMessage();
                    }
                    if (this.User.IsInRole("Parts"))
                    {
                        var responseTech = SendSimpleMessageChunk.SendTechMessage();
                    }
                    if (this.User.IsInRole("Tech") && quote.IsComplete == true)
                    {
                        var finalResponse = SendSimpleMessageChunk.SendFinalMessage();
                    }
                    

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.Id))
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
            return View(quote);
        }

        // GET: Quote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(int id)
        {
            return _context.Quotes.Any(e => e.Id == id);
        }
    }
}
