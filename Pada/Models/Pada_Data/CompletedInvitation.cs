using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class CompletedInvitation
    {
        public int TransactionId { get; set; }
        public int ActivityId { get; set; }
        public string FromUserId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime DateTimeCompleted { get; set; }
        public int Result { get; set; }
    }
}
