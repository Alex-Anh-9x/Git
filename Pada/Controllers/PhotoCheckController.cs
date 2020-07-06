using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pada.Areas.Identity.Data;
using Pada.Models;

namespace Pada.Controllers
{
    public class PhotoCheckController : Controller
    {
        private readonly Pada_DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        // For validating user and get user info.
        private readonly UserManager<PadaUser> _userManager;
        private readonly SignInManager<PadaUser> _signInManager;

        public PhotoCheckController(Pada_DataContext context, IWebHostEnvironment hostEnvironment, UserManager<PadaUser> userManager,
            SignInManager<PadaUser> signInManager)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: PhotoCheck
        public async Task<IActionResult> NewPhotoCheck()
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

        // GET: PhotoCheck/Details/5
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

        private bool PendingPhotoRequestExists(int id)
        {
            return _context.PendingPhotoRequest.Any(e => e.TransactionId == id);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
