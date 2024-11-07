using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework
{
    public class MyLogger
    {
        private const string logname = "GAMELOG";
        private TraceSource? tSource;

        private MyLogger()
        {
            tSource = new TraceSource(logname);
            tSource.Switch = new SourceSwitch(logname, SourceLevels.All.ToString());

            tSource.Listeners.Add(
                new TextWriterTraceListener($"{logname}.txt"));
        }

        private static readonly MyLogger lInstance = new MyLogger();
        public static MyLogger Instance => lInstance;

        public void AddListener(TraceListener listener)
        {
            tSource?.Listeners.Add(listener);
        }
        public void RemoveListener(TraceListener listener)
        {
            tSource?.Listeners.Remove(listener);
        }
        public void LogInfo(string msg)
        {
            tSource?.TraceEvent(TraceEventType.Information, 200, msg);
        }
    }
}