using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.CurrentUserEmail = user.Email;
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
        public async Task<IActionResult> Create([Bind("TransactionId,Email,Type,OldPhotoPath,NewPhotoPath,AcceptedVote,RejectedVote,VoteRequired,FullPhotoPath,FacePhotoPath,AnyPhotoPath,PendingVote,ImageName,ImageFile")] PendingPhotoRequest pendingPhotoRequest)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(pendingPhotoRequest.ImageFile.FileName);
                string extension = Path.GetExtension(pendingPhotoRequest.ImageFile.FileName);
                pendingPhotoRequest.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //Get current user email
                pendingPhotoRequest.Email = user.Email;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await pendingPhotoRequest.ImageFile.CopyToAsync(filestream);
                }
                string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=chinhlanhuvaycf7e180a308;AccountKey=ufsUzB/+lb4VQX2QDXECQO9ZRVWaxc2G6nKEQD1Bo40Px7n9Ajs5pJHWB0nmKfVFZnvaFaacsh/Trmtrci+U+w==;EndpointSuffix=core.windows.net";
                CloudStorageAccount storageacc = CloudStorageAccount.Parse(storageConnectionString);

                CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("vhds");
                await container.CreateIfNotExistsAsync();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(pendingPhotoRequest.ImageName);

                using (var filestream = System.IO.File.OpenRead(path))
                {
                    await blockBlob.UploadFromStreamAsync(filestream);
                }
                //using (var memoryStream = new MemoryStream())
                //{
                //    await pendingPhotoRequest.ImageFile.CopyToAsync(memoryStream);
                //    await blockBlob.UploadFromStreamAsync(memoryStream);
                //}
                var blobUrl = blockBlob.Uri.AbsoluteUri;
                pendingPhotoRequest.ImageName = blobUrl;
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
