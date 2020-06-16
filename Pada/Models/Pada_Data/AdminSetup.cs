using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class AdminSetup
    {
        public int? IndexNo { get; set; }
        public decimal? ChangePhotoSubmitPoint { get; set; }
        public int? ChangePhotoVoteRequired { get; set; }
        public int? NewPhotoVoteRequired { get; set; }
        public decimal? NewPhotoAwardPoint { get; set; }
        public decimal? NewPhotoDeductPoint { get; set; }
        public decimal? ChangePhotoAwardPoint { get; set; }
        public decimal? ChangePhotoDeductPoint { get; set; }
        public decimal? NewFaceMashSubmitPoint { get; set; }
        public decimal? SaturatedFaceScore { get; set; }
        public int? MinBattleRequiredToRank { get; set; }
        public decimal? Fmdpfactor { get; set; }
        public int? BeginnerBattleLevel { get; set; }
        public int? BeginnerKvalue { get; set; }
        public int? NormalKvalue { get; set; }
        public int? SaturatedKvalue { get; set; }
        public decimal? CreateActivityPostCost { get; set; }
        public decimal? SendInvitationCost { get; set; }
        public decimal? IncomePeriodMinute { get; set; }
        public decimal? BaseDp { get; set; }
        public decimal? BaseFs { get; set; }
        public decimal? BaseIncome { get; set; }
        public decimal? ReferralIncome { get; set; }
        public decimal? ReferralAward { get; set; }
        public string WelcomeMessage { get; set; }
        public int? MaxCurrentBattle { get; set; }
        public int? MaxCurrentJudge { get; set; }
        public int? MinCurrentBattle { get; set; }
        public int? MinCurrentJudge { get; set; }
        public string AdminPassword { get; set; }
    }
}
