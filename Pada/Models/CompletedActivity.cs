using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class CompletedActivity
    {
        public int ActivityId { get; set; }
        public string UserId { get; set; }
        public int TargetGender { get; set; }
        public int InstantRelationship { get; set; }
        public string Activities { get; set; }
        public int Status { get; set; }
        public string PartnerId { get; set; }
        public int InvitationId { get; set; }
        public DateTime DateTimeCompleted { get; set; }
    }
}
