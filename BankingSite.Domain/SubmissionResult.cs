using System.Collections.Generic;

namespace BankingSite.Domain
{
    public class SubmissionResult
    {
        public int? ReferenceNumber { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
