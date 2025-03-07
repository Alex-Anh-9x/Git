﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Pada.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the PadaUser class
    public class PadaUser : IdentityUser
    {
        [PersonalData]
        public string Gender { get; set; }
        [PersonalData]
        public int UserLevel { get; set; }
    }
}
