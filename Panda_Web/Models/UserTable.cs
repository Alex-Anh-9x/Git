using System;
using System.Collections.Generic;

namespace Panda_Web.Models
{
    public partial class UserTable
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? WorldRank { get; set; }
        public int? CityRank { get; set; }
        public decimal? RatingScore { get; set; }
        public DateTime? DateJoined { get; set; }
        public decimal? HeightCm { get; set; }
        public decimal? WeightKg { get; set; }
        public int? AccountStatus { get; set; }
        public int? NoReported { get; set; }
        public string ContactNo { get; set; }
        public string ActivationCode { get; set; }
        public string Password { get; set; }
        public decimal? DatePoint { get; set; }
        public decimal? FaceScore { get; set; }
        public int? RankStatus { get; set; }
        public int? TotalGamePlayed { get; set; }
        public int? PhotosApproved { get; set; }
        public string ReferalCode { get; set; }
        public int? ActiveReferal { get; set; }
        public decimal? DailyPointGain { get; set; }
        public DateTime? LastDateTimeCollected { get; set; }
        public decimal? Income { get; set; }
        public string FacePhotoPath { get; set; }
        public string FullPhotoPath { get; set; }
        public string AnyPhotoPath { get; set; }
        public DateTime? LastDateTimeReported { get; set; }
        public int? Advertisement { get; set; }
        public int? CurrentBattle { get; set; }
        public int? CurrentJudge { get; set; }
        public int? UserLevel { get; set; }
        public int? ReadUploadPhoto { get; set; }
        public int? ReadPhotoCheck { get; set; }
        public int? ReadPageantReg { get; set; }
        public int? ReadPageantJudge { get; set; }
        public int? ReadNewDating { get; set; }
        public int? ReadFindDate { get; set; }
        public string AccessToken { get; set; }
        public int? IsFaceBookUser { get; set; }
        public int? PageantRegistered { get; set; }
        public string Fbemail { get; set; }
        public int? PreviousAccountStatus { get; set; }
    }
}
