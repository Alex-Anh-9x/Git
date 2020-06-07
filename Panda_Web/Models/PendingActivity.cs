using System;
using System.Collections.Generic;

namespace Panda_Web.Models
{
    public partial class PendingActivity
    {
        public int ActivityId { get; set; }
        public string UserId { get; set; }
        public int TargetGender { get; set; }
        public int InstantRelationship { get; set; }
        public string Activities { get; set; }
        public DateTime DateCreated { get; set; }
        public int? InvitationCount { get; set; }
    }
}
