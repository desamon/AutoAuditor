using System;
using System.IO;

namespace Logger.Impl
{
    internal static class Extensions
    {
        internal static string GetFolder(string folder)
            => $"./{folder}";

        internal static void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        internal static string MsgHanlder(string msg, Exception ex = null)
            => ex is null ? msg : $"{msg}{Environment.NewLine}{ex}";

        internal static string GetLogString(LogLvl logLvl, string msg)
            => $"{logLvl}   {DateTime.Now}  >>> {msg}";

        internal static string GetPath(string directory)
            => $"{directory}/log_{DateTime.Now.ToString("dd MMMM yyyy")}.log";
    }
}
