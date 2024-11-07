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

        public void StartGamelog()
        {
            TraceSource tSource = new TraceSource(logname);
            tSource.Switch = new SourceSwitch(logname, SourceLevels.Information.ToString());

            tSource.Listeners.Add(new ConsoleTraceListener());

            tSource.Listeners.Add(
                new TextWriterTraceListener($"{logname}.txt")
                {
                    Filter = new EventTypeFilter(SourceLevels.Error)
                });

            tSource.Listeners.Add(new XmlWriterTraceListener($"{logname}.xml"));

            tSource.TraceEvent(TraceEventType.Error, 700, "Message: Something went wrong");
            tSource.TraceEvent(TraceEventType.Critical, 700, "Message: Critical error occurred");
            tSource.Close();
        }
    }
}
