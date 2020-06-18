using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pada.Models;

namespace Pada.Views
{
    public class PendingPhotoRequestsController : Controller
    {
        private readonly Pada_DataContext _context;

        public PendingPhotoRequestsController(Pada_DataContext context)
        {
            _context = context;
        }

        // GET: PendingPhotoRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.PendingPhotoRequest.ToListAsync());
        }

        // GET: PendingPhotoRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendingPhotoRequest = await _context.PendingPhotoRequest
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (pendingPhotoRequest == null)
            {
                return NotFound();
            }

            return View(pendingPhotoRequest);
        }

        // GET: PendingPhotoRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PendingPhotoRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,Email,Type,OldPhotoPath,NewPhotoPath,AcceptedVote,RejectedVote,VoteRequired,FullPhotoPath,FacePhotoPath,AnyPhotoPath,PendingVote")] PendingPhotoRequest pendingPhotoRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pendingPhotoRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pendingPhotoRequest);
        }

        // GET: PendingPhotoRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendingPhotoRequest = await _context.PendingPhotoRequest.FindAsync(id);
            if (pendingPhotoRequest == null)
            {
                return NotFound();
            }
            return View(pendingPhotoRequest);
        }

        // POST: PendingPhotoRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,Email,Type,OldPhotoPath,NewPhotoPath,AcceptedVote,RejectedVote,VoteRequired,FullPhotoPath,FacePhotoPath,AnyPhotoPath,PendingVote")] PendingPhotoRequest pendingPhotoRequest)
        {
            if (id != pendingPhotoRequest.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pendingPhotoRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PendingPhotoRequestExists(pendingPhotoRequest.TransactionId))
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
            return View(pendingPhotoRequest);
        }

        // GET: PendingPhotoRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendingPhotoRequest = await _context.PendingPhotoRequest
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (pendingPhotoRequest == null)
            {
                return NotFound();
            }

            return View(pendingPhotoRequest);
        }

        // POST: PendingPhotoRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pendingPhotoRequest = await _context.PendingPhotoRequest.FindAsync(id);
            _context.PendingPhotoRequest.Remove(pendingPhotoRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PendingPhotoRequestExists(int id)
        {
            return _context.PendingPhotoRequest.Any(e => e.TransactionId == id);
        }
    }
}
