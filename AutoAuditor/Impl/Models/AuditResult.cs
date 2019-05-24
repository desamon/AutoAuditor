using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuditor.Impl.Models
{
    public class AuditResult
    {
        public string Title { get; set; }
        public string Criterion { get; set; }
        public List<QuestionResult> QuestionsResult { get; set; }
        public double Value { get; set; }
    }
}
