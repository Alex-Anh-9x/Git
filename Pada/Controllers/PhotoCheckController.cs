using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pada.Areas.Identity.Data;
using Pada.Models;
using ServiceStack.Host;

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
            var updateContext = new Pada_DataContext();
            //var output = new SqlParameter();
            SqlParameter transactionid = new SqlParameter
            {
                ParameterName = "@transactionid",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            SqlParameter facephoto = new SqlParameter
            {
                ParameterName = "@facephoto",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 120
            };
            SqlParameter fullphoto = new SqlParameter
            {
                ParameterName = "@fullphoto",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 120
            };
            SqlParameter anyphoto = new SqlParameter
            {
                ParameterName = "@anyphoto",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 120
            };
            SqlParameter gainpoint = new SqlParameter
            {
                ParameterName = "@gainpoint",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            SqlParameter losepoint = new SqlParameter
            {
                ParameterName = "@losepoint",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            SqlParameter oldphoto = new SqlParameter
            {
                ParameterName = "@oldphoto",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 120
            };
            SqlParameter newphoto = new SqlParameter
            {
                ParameterName = "@newphoto",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 120
            };
            SqlParameter returntype = new SqlParameter
            {
                ParameterName = "@returntype",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            SqlParameter result = new SqlParameter
            {
                ParameterName = "@result",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            updateContext.Database.ExecuteSqlInterpolated($"EXEC [dbo].[usp_minh_photocheck_getbattle] @email={user.Email}, @password={"123456"}, @type = {1}, @transactionid = {transactionid} OUTPUT, @facephoto ={facephoto} OUTPUT, @fullphoto ={fullphoto} OUTPUT, @anyphoto={anyphoto} OUTPUT,@gainpoint={gainpoint} OUTPUT, @losepoint={losepoint} OUTPUT, @oldphoto={oldphoto} OUTPUT, @newphoto={newphoto} OUTPUT,@returntype={returntype} OUTPUT, @result={result} OUTPUT");

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
        public async Task<ActionResult> UploadedPhotoStatus()
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
        public async Task<ActionResult> Approve(int id)
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
            var updateContext = new Pada_DataContext();
            var photoCheckUserID = updateContext.PendingPhotoTransaction.Where(m => m.JudgeId == user.Email).FirstOrDefault().TransactionId;
            //var output = new SqlParameter();
            SqlParameter result = new SqlParameter
            {
                ParameterName = "@result",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            updateContext.Database.ExecuteSqlInterpolated($"EXEC [dbo].[usp_minh_photocheck_decision] @email={user.Email}, @password={"123456"}, @decision = {1}, @transid = {photoCheckUserID}, @result={result} OUTPUT"); //need to paas tranid fro pending tranction
            ViewBag.CurrentUserEmail = user.Email;
            if (result.ToString() != "2" || result.ToString() != "3")
            {
                return View(nameof(Index));
            }
            else
                throw new HttpException(404, "Item Not Found");
        }
        public async Task<ActionResult> Reject(int id)
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
            var updateContext = new Pada_DataContext();
            var photoCheckUserID = updateContext.PendingPhotoTransaction.Where(m => m.JudgeId == user.Email).FirstOrDefault().TransactionId;

            //var output = new SqlParameter();
            SqlParameter result = new SqlParameter
            {
                ParameterName = "@result",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            ViewBag.CurrentUserEmail = user.Email;
            updateContext.Database.ExecuteSqlInterpolated($"EXEC [dbo].[usp_minh_photocheck_decision] @email={user.Email}, @password={"123456"}, @decision = {1}, @transid = {photoCheckUserID}, @result={result} OUTPUT");
            if (result.ToString() != "2" || result.ToString() != "3")
            {
                return View(nameof(Index));
            }
            else
                throw new HttpException(404, "Item Not Found");
        }
    }
}
