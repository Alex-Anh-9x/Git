using System;
using System.Collections.Generic;

namespace Panda_Web.Models
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
