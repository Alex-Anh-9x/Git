using System;
using System.Collections.Generic;

namespace Pada.Models
{
    public partial class ReferalIncome
    {
        public string SeniorEmail { get; set; }
        public string JuniorEmail { get; set; }
        public int ReferalType { get; set; }
        public DateTime DateCreated { get; set; }
        public int Status { get; set; }
        public int ReferalValue { get; set; }
        public string PackageName { get; set; }
    }
}
