using System;
using System.Collections.Generic;

namespace Panda_Web.Models
{
    public partial class PendingBattleRequest
    {
        public int BatteId { get; set; }
        public int Gender { get; set; }
        public string RequestorId { get; set; }
        public decimal? LowerPoint { get; set; }
        public decimal? UpperPoint { get; set; }
        public int? Quantity { get; set; }
        public int? Processing { get; set; }
        public int? BattlePlayed { get; set; }
    }
}
