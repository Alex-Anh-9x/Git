using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class PendingReportTransaction
    {
        public int TransactionId { get; set; }
        public string ReporterId { get; set; }
        public string ReportingId { get; set; }
        public int? ReportType { get; set; }
        public int? ReportTransId { get; set; }
        public string ReportReason { get; set; }
        public int? Status { get; set; }
        public DateTime? DateReported { get; set; }
    }
}
