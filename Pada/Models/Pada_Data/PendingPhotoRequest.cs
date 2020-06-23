using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pada.Models
{
    public partial class PendingPhotoRequest
    {
        [Key]
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
        public int? PendingVote { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }

}
