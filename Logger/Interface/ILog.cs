using System;
using System.Threading.Tasks;

namespace Logger.Interface
{
    public interface ILog
    {
        void Error(Exception ex, string msg = null);
        void Warning(string msg);
        void Info(string msg);
        void Debug(string msg);

        Task ErrorAsync(Exception ex, string msg = null);
        Task WarningAsync(string msg);
        Task InfoAsync(string msg);
        Task DebugAsync(string msg);
    }
}
