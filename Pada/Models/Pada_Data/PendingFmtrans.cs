using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class PendingFmtrans
    {
        public int TransactionId { get; set; }
        public int Gender { get; set; }
        public string PlayerA { get; set; }
        public string PlayerB { get; set; }
        public string Chooser { get; set; }
        public DateTime DateCreated { get; set; }
        public int? PlayerAbattleId { get; set; }
        public int? PlayerBbattleId { get; set; }
    }
}
