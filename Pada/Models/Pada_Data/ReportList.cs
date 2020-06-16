using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class ReportList
    {
        public int ReportId { get; set; }
        public string FromUserId { get; set; }
        public string ReportingUserId { get; set; }
        public DateTime DateTimeReported { get; set; }
        public string Reason { get; set; }
    }
}
