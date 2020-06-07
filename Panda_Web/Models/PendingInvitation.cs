using System;
using System.Collections.Generic;

namespace Panda_Web.Models
{
    public partial class PendingInvitation
    {
        public int TransactionId { get; set; }
        public int ActivityId { get; set; }
        public string FromUserId { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
