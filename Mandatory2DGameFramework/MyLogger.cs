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

        public void Start()
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

            tSource.TraceEvent(TraceEventType.Information, 700, "Message: Something went wrong");
            tSource.Close();
        }
    }
}
