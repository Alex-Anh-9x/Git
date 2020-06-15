using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class CompletedFmtrans
    {
        public int TransactionId { get; set; }
        public int Gender { get; set; }
        public string PlayerA { get; set; }
        public string PlayerB { get; set; }
        public string Chooser { get; set; }
        public string Winner { get; set; }
        public DateTime DatePlayed { get; set; }
        public decimal ScoreWon { get; set; }
        public decimal ScoreLost { get; set; }
        public decimal Dpoint { get; set; }
        public string Loser { get; set; }
    }
}
