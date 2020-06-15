using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class PendingPhotoTransaction
    {
        public int TransactionId { get; set; }
        public int PhotoRequestId { get; set; }
        public string JudgeId { get; set; }
        public int? Approve { get; set; }
        public DateTime? TimeDone { get; set; }
        public decimal? RewardPoint { get; set; }
        public decimal? DeductPoint { get; set; }
    }
}
