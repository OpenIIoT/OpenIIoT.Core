﻿using NLog;
using System;
using System.Collections.Generic;

namespace Symbiote.Core
{
    /// <summary>
    /// The RealtimeLogger class acts as a target for the NLog method logging target.  
    /// Fires the Changed event when new log messages are created by NLog.
    /// </summary>
    public class RealtimeLogger
    {
        /// <summary>
        /// A queue containing the newest 200 log messages.
        /// </summary>
        public static Queue<RealtimeLoggerEventArgs> LogHistory = new Queue<RealtimeLoggerEventArgs>();

        /// <summary>
        /// The Changed event is fired when new log messages are created by NLog.
        /// </summary>
        public static event EventHandler<RealtimeLoggerEventArgs> Changed;
        
        /// <summary>
        /// This delegate is called when the Changed event fires.
        /// </summary>
        /// <typeparam name="RealtimeLoggerEventArgs">The EventArgs type associated with the event.</typeparam>
        /// <param name="sender">The sender of the event.  Null/default in this case.</param>
        /// <param name="e">The EventArgs instance associated with the event.</param>
        public delegate void EventHandler<RealtimeLoggerEventArgs>(object sender, RealtimeLoggerEventArgs e);

        /// <summary>
        /// Called by the NLog method logging target, this method fires the Changed event with the timestamp, level, logger and message
        /// associated with the new log message.
        /// </summary>
        /// <param name="longdate">The timestamp of the log message in long date format.</param>
        /// <param name="level">The level of the log message.</param>
        /// <param name="logger">The logger instance that generated the message.</param>
        /// <param name="message">The log message.</param>
        public static void AppendLog(string longdate, string level, string logger, string message)
        {
            RealtimeLoggerEventArgs eventArgs = new RealtimeLoggerEventArgs(longdate, level, logger, message);

            AppendLogHistory(eventArgs);

            if (Changed != null)
                Changed(default(object), eventArgs);
        }

        /// <summary>
        /// Enqueues the supplied RealtimeLoggerEventArgs instance to the LogHistory queue.  
        /// If the queue exceeds 200 entries, the oldest log is first dequeued before the new log is enqueued.
        /// </summary>
        /// <param name="eventArgs">The RealtimeLoggerEventArgs instance to enqueue.</param>
        private static void AppendLogHistory(RealtimeLoggerEventArgs eventArgs)
        {
            if (LogHistory.Count > 200)
                LogHistory.Dequeue();

            LogHistory.Enqueue(eventArgs);
        }
    }

    /// <summary>
    /// Contains the EventArgs associated with the RealtimeLogger Changed event.
    /// </summary>
    public class RealtimeLoggerEventArgs : EventArgs
    {
        /// <summary>
        /// The timestamp of the log message.
        /// </summary>
        public DateTime LongDate { get; private set; }

        /// <summary>
        /// The logging level of the log message.
        /// </summary>
        public string Level { get; private set; }

        /// <summary>
        /// The name of the logger that generated the log message.
        /// </summary>
        public string Logger { get; private set; }

        /// <summary>
        /// The log message.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// The default constructor.  Creates a new instance of RealtimeLoggerEventArgs with the supplied parameters.
        /// </summary>
        /// <param name="longdate">The timestamp of the log message in long date format.</param>
        /// <param name="level">The level of the log message.</param>
        /// <param name="logger">The logger instance that generated the message.</param>
        /// <param name="message">The log message.</param>
        public RealtimeLoggerEventArgs(string longdate, string level, string logger, string message)
        {
            LongDate = DateTime.Parse(longdate);
            Level = level;
            Logger = logger;
            Message = message;
        }
    }
}