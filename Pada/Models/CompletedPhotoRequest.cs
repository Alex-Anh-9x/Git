using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class CompletedPhotoRequest
    {
        public int TransactionId { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string OldPhotoPath { get; set; }
        public string NewPhotoPath { get; set; }
        public int? AcceptedVote { get; set; }
        public int? RejectedVote { get; set; }
        public int? VoteRequired { get; set; }
        public string FullPhotoPath { get; set; }
        public string FacePhotoPath { get; set; }
        public string AnyPhotoPath { get; set; }
        public int? Result { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
}
