﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pada.Areas.Identity.Data;
using Pada.Models;

namespace Pada.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<PadaUser> _userManager;
        private readonly SignInManager<PadaUser> _signInManager;

        public IndexModel(
            UserManager<PadaUser> userManager,
            SignInManager<PadaUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Gender")]
            public string Gender { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(PadaUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Gender = user.Gender
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            //Get phone number of the current user using _userManager
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var datacontext = new Pada_DataContext();
            var newUpdatedUser = datacontext.UserTable
                    .Where(u => u.Email == user.Email)
                    .FirstOrDefault();
            newUpdatedUser.UserLevel = 4;
            user.UserLevel = 4;
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
                //Update phone number in Pada Data
                //Add new instance to save changes
                newUpdatedUser.ContactNo = user.PhoneNumber;
                using (var datacontext1 = new Pada_DataContext())
                {
                    datacontext1.Update<UserTable>(newUpdatedUser);
                    await datacontext1.SaveChangesAsync();
                }
            }
            if (Input.Gender != user.Gender)
            {
                user.Gender = Input.Gender;
                //Update gender in Pada_Data, using update entity framework with new record without query, using disconnected scenario
                //Add new instance to save changes
                newUpdatedUser.Gender = (user.Gender == "Male") ? 1 : (user.Gender == "Female") ? 2 : 3;
                using (var datacontext2 = new Pada_DataContext())
                {
                    datacontext2.Update<UserTable>(newUpdatedUser);
                    await datacontext2.SaveChangesAsync();
                }
            }

            using (var datacontext3 = new Pada_DataContext())
            {
                datacontext3.Update<UserTable>(newUpdatedUser);
                await datacontext3.SaveChangesAsync();
            }
            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToAction("General","PendingPhotoRequests");
        }
    }
}
