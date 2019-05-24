using Logger.Interface;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Logger.Impl
{
    public class Log : ILog
    {
        #region Fields
        private string _folder = "log";
        private string _directory;
        private string _path;
        #endregion

        #region Constructors
        public Log()
        {
            Initialization(_folder);
        }

        public Log(string folder)
        {
            Initialization(folder);
        }
        #endregion

        #region Methods
        private void Initialization(string folder)
        {
            _directory = Extensions.GetFolder(folder);
            Extensions.CreateDirectory(_directory);
            _path = Extensions.GetPath(_directory);
        }

        private void WriteToLog(LogLvl logLvl, string msg = null, Exception ex = null)
        {
            var newMsg = Extensions.MsgHanlder(msg, ex);
            var logString = Extensions.GetLogString(logLvl, newMsg);

            using (var sw = new StreamWriter(_path, true))
                sw.WriteLine(logString);
        }

        async private Task WriteToLogAsync(LogLvl logLvl, string msg, Exception ex = null)
        {
            var newMsg = Extensions.MsgHanlder(msg, ex);
            var logString = Extensions.GetLogString(logLvl, newMsg);

            using (var sw = new StreamWriter(_path, true))
                await sw.WriteLineAsync(logString);
        }

        public void Error(Exception ex, string msg = null)
            => WriteToLog(LogLvl.Error, msg, ex);

        public void Info(string msg)
            => WriteToLog(LogLvl.Info, msg);

        public void Warning(string msg)
            => WriteToLog(LogLvl.Warning, msg);

        public void Debug(string msg)
            => WriteToLog(LogLvl.Debug, msg);

        async public Task ErrorAsync(Exception ex, string msg = null)
            => await WriteToLogAsync(LogLvl.Error, msg, ex);

        async public Task InfoAsync(string msg)
            => await WriteToLogAsync(LogLvl.Info, msg);

        async public Task WarningAsync(string msg)
            => await WriteToLogAsync(LogLvl.Warning, msg);

        async public Task DebugAsync(string msg)
            => await WriteToLogAsync(LogLvl.Debug, msg);
        #endregion
    }
}
