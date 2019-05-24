using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuditor.Impl.Extension
{
    internal static class Extension
    {
        internal static double GetCriterionValue(double value, int count)
            => value / count;
    }
}
