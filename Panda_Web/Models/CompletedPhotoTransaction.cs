﻿using System;
using System.Collections.Generic;

namespace Panda_Web.Models
{
    public partial class CompletedPhotoTransaction
    {
        public int TransactionId { get; set; }
        public int PhotoRequestId { get; set; }
        public string JudgeId { get; set; }
        public int Approve { get; set; }
        public DateTime? TimeDone { get; set; }
        public decimal? RewardPoint { get; set; }
        public decimal? DeductPoint { get; set; }
    }
}
