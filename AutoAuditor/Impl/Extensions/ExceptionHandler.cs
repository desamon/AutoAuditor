using Logger.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuditor.Impl.Extension
{
    public static class ExceptionHandler
    {
        async public static void Aggregate(AggregateException ex, ILog logger, string msg = null)
        {
            foreach(var inner in ex.InnerExceptions)
            {
                await logger.ErrorAsync(inner, msg);
            }
        }

        async public static void Another(Exception ex, ILog logger, string msg = null)
            => await logger.ErrorAsync(ex, msg);
    }
}
