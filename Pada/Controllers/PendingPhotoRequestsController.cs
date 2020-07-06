using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Pada.Areas.Identity.Data;
using Pada.Models;

namespace Pada.Views
{
    //Add authorization request to ensure only logged in user can access this page
    [Authorize]
    public class PendingPhotoRequestsController : Controller
    {
        private readonly Pada_DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        // For validating user and get user info.
        private readonly UserManager<PadaUser> _userManager;
        private readonly SignInManager<PadaUser> _signInManager;

        public PendingPhotoRequestsController(Pada_DataContext context, IWebHostEnvironment hostEnvironment, UserManager<PadaUser> userManager,
            SignInManager<PadaUser> signInManager)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: PendingPhotoRequests
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (user.UserLevel < 4)
            {
                return NotFound($"User with this ID '{_userManager.GetUserId(User)}' can not see the content of this page.");
            }
            ViewBag.CurrentUserEmail = user.Email;
            return View(await _context.PendingPhotoRequest.ToListAsync());
        }

        // GET: PendingPhotoRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (id == null)
            {
                return NotFound();
            }
            if (user.UserLevel < 4)
            {
                return NotFound($"User with this ID '{_userManager.GetUserId(User)}' can not see the content of this page.");
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
        public async Task<IActionResult> Create([Bind("TransactionId,Email,Type,OldPhotoPath,NewPhotoPath,AcceptedVote,RejectedVote,VoteRequired,FullPhotoPath,FacePhotoPath,AnyPhotoPath,PendingVote,ImageName,ImageFile")] PendingPhotoRequest pendingPhotoRequest, IFormFile fullImageFile, IFormFile faceImageFile, IFormFile anyImageFile)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.UserLevel < 4)
            {
                return NotFound($"User with this ID '{_userManager.GetUserId(User)}' can not see the content of this page.");
            }
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }
                string fullImageLink = await pendingPhotoRequest.UploadPhoto(fullImageFile, _hostEnvironment);
                string faceImageLink = await pendingPhotoRequest.UploadPhoto(faceImageFile, _hostEnvironment);
                string anyImageLink = await pendingPhotoRequest.UploadPhoto(anyImageFile, _hostEnvironment);
                var updateContext = new Pada_DataContext();
                var output = new SqlParameter();
                output.ParameterName = "@result";
                output.SqlDbType = SqlDbType.Int;
                output.Direction = ParameterDirection.Output;
                updateContext.Database.ExecuteSqlInterpolated($"EXEC [dbo].[usp_minh_photorequest_createnewphoto] @email={user.Email},@password={"123456"},@fullphoto={fullImageLink},@facephoto ={faceImageLink},@anyphoto={anyImageLink}, @result = {output} OUT");

                return RedirectToAction("Index", "PhotoCheck", new { area = "" });
            }
            return View(pendingPhotoRequest);
        }


        // GET: PendingPhotoRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.UserLevel < 4)
            {
                return NotFound($"User with this ID '{_userManager.GetUserId(User)}' can not see the content of this page.");
            }
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
            var user = await _userManager.GetUserAsync(User);
            if (user.UserLevel < 4)
            {
                return NotFound($"User with this ID '{_userManager.GetUserId(User)}' can not see the content of this page.");
            }
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
            var user = await _userManager.GetUserAsync(User);
            if (user.UserLevel < 4)
            {
                return NotFound($"User with this ID '{_userManager.GetUserId(User)}' can not see the content of this page.");
            }
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
            var user = await _userManager.GetUserAsync(User);
            if (user.UserLevel < 4)
            {
                return NotFound($"User with this ID '{_userManager.GetUserId(User)}' can not see the content of this page.");
            }
            var pendingPhotoRequest = await _context.PendingPhotoRequest.FindAsync(id);
            _context.PendingPhotoRequest.Remove(pendingPhotoRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PendingPhotoRequestExists(int id)
        {
            return _context.PendingPhotoRequest.Any(e => e.TransactionId == id);
        }
        public IActionResult General()
        {
            return View();
        }
    }
}
