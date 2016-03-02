using System;

namespace Symbiote.Core
{
    class RealtimeLogger
    {
        private static RealtimeLogger instance;

        public static event EventHandler<ItemEventArgs> Changed;
        public delegate void EventHandler<ItemEventArgs>(object sender, RealtimeLoggerEventArgs e);

        public static void AppendLog(string longdate, string level, string logger, string message)
        {
            if (Changed != null)
                Changed(new object(), new RealtimeLoggerEventArgs(longdate, level, logger, message));
        }
    }

    class RealtimeLoggerEventArgs : EventArgs
    {
        public DateTime LongDate { get; private set; }
        public string Level { get; private set; }
        public string Logger { get; private set; }
        public string Message { get; private set; }

        public RealtimeLoggerEventArgs(string longdate, string level, string logger, string message)
        {
            LongDate = DateTime.Parse(longdate);
            Level = level;
            Logger = logger;
            Message = message;
        }
    }
}
