using System;

namespace Symbiote.Core.Communication.Services.Web.SignalR
{
    class RealtimeLogger
    {
        private static RealtimeLogger instance;

        public static event EventHandler<ItemEventArgs> Changed;
        public delegate void EventHandler<ItemEventArgs>(object sender, RealtimeLoggerEventArgs e);

        public static void AppendLog(string level, string message)
        {
            if (Changed != null)
                Changed(new object(), new RealtimeLoggerEventArgs(level, message));
        }
    }

    class RealtimeLoggerEventArgs : EventArgs
    {
        public string Level { get; private set; }
        public string Message { get; private set; }

        public RealtimeLoggerEventArgs(string level, string message)
        {
            Level = level;
            Message = message;
        }
    }
}
