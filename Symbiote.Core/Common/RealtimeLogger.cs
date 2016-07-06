/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █
      █      ▄████████                                                                   ▄█
      █     ███    ███                                                                  ███
      █    ▄███▄▄▄▄██▀    ▄█████   ▄█████   █           ██     █     ▄▄██▄▄▄     ▄█████ ███        ██████     ▄████▄     ▄████▄     ▄█████    █████
      █   ▀▀███▀▀▀▀▀     ██   █    ██   ██ ██       ▀███████▄ ██   ▄█▀▀██▀▀█▄   ██   █  ███       ██    ██   ██    ▀    ██    ▀    ██   █    ██  ██
      █   ▀███████████  ▄██▄▄      ██   ██ ██           ██  ▀ ██▌  ██  ██  ██  ▄██▄▄    ███       ██    ██  ▄██        ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███    ███ ▀▀██▀▀    ▀████████ ██           ██    ██   ██  ██  ██ ▀▀██▀▀    ███       ██    ██ ▀▀██ ███▄  ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███    ███   ██   █    ██   ██ ██▌    ▄     ██    ██   ██  ██  ██   ██   █  ███▌    ▄ ██    ██   ██    ██   ██    ██   ██   █    ██  ██
      █     ███    ███   ███████   ██   █▀ ████▄▄██    ▄██▀   █     █  ██  █    ███████ █████▄▄██  ██████    ██████▀    ██████▀    ███████   ██  ██
      █
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █ 
      █  The RealtimeLogger class works in conjunction with the NLog 'MethodCall' logging target to expose log messages via an event
      █  in real time.  
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀   
      █  The MIT License (MIT)
      █  
      █  Copyright (c) 2016 JP Dillingham (jp@dillingham.ws)
      █  
      █  Permission is hereby granted, free of charge, to any person obtaining a copy
      █  of this software and associated documentation files (the "Software"), to deal
      █  in the Software without restriction, including without limitation the rights
      █  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
      █  copies of the Software, and to permit persons to whom the Software is
      █  furnished to do so, subject to the following conditions:
      █  
      █  The above copyright notice and this permission notice shall be included in all
      █  copies or substantial portions of the Software.
      █  
      █  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
      █  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
      █  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
      █  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
      █  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
      █  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
      █  SOFTWARE. 
      █ 
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀     ▀▀▀   
      █  Dependencies:
      █     └─ NLog (https://www.nuget.org/packages/NLog/)
      █ 
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██   
                                                                                               ▀█▄ ██ ▄█▀                       
                                                                                                 ▀████▀   
                                                                                                   ▀▀                              */
using NLog;
using System;
using System.Collections.Generic;

namespace Symbiote.Core
{
    /// <summary>
    /// The RealtimeLogger class acts as a target for the NLog method logging target.  
    /// Fires the LogArrived event when new log messages are created by NLog.
    /// </summary>
    public class RealtimeLogger
    {
        #region Variables

        /// <summary>
        /// The default log history limit.
        /// </summary>
        private const int logHistoryLimit = 200;

        /// <summary>
        /// Initialization status of the class.
        /// </summary>
        private static bool initialized = false;

        #endregion

        #region Properties

        /// <summary>
        /// A queue containing the newest log messages, up to the LogHistoryLimit.
        /// </summary>
        public static Queue<RealtimeLoggerEventArgs> LogHistory { get; private set; }

        /// <summary>
        /// The maximum number of log messages to store in the log history queue.
        /// </summary>
        /// <remarks>
        /// If the value is reduced while the log is populated, the length of the LogHistory queue
        /// will be reduced to the desired value upon the addition of the next log.
        /// </remarks>
        public static int LogHistoryLimit { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>
        /// Included for good measure.  Not invoked when member methods are invoked using reflection,
        /// such as through NLog's MethodCall target.
        /// </remarks>
        public RealtimeLogger()
        {
            Initialize();
        }

        #endregion

        #region Events

        /// <summary>
        /// The Changed event is fired when new log messages are created by NLog.
        /// </summary>
        public static event EventHandler<RealtimeLoggerEventArgs> LogArrived;
        
        /// <summary>
        /// This delegate is called when the Changed event fires.
        /// </summary>
        /// <typeparam name="RealtimeLoggerEventArgs">The EventArgs type associated with the event.</typeparam>
        /// <param name="sender">The sender of the event.  Null/default in this case.</param>
        /// <param name="e">The EventArgs instance associated with the event.</param>
        public delegate void EventHandler<RealtimeLoggerEventArgs>(object sender, RealtimeLoggerEventArgs e);

        #endregion

        #region Static Methods

        #region Private

        /// <summary>
        /// Initialize properties. 
        /// </summary>
        /// <remarks>
        /// Used in place of a constructor, which is not invoked when member methods are invoked using reflection, 
        /// such as through NLog's MethodCall target.
        /// </remarks>
        private static void Initialize()
        {
            LogHistory = new Queue<RealtimeLoggerEventArgs>();
            LogHistoryLimit = logHistoryLimit;
            initialized = true;
        }

        /// <summary>
        /// Enqueues the supplied RealtimeLoggerEventArgs instance to the LogHistory queue.  
        /// If the queue exceeds 200 entries, the oldest log is first dequeued before the new log is enqueued.
        /// </summary>
        /// <param name="eventArgs">The RealtimeLoggerEventArgs instance to enqueue.</param>
        private static void AppendLogHistory(RealtimeLoggerEventArgs eventArgs)
        {
            LogHistory.Enqueue(eventArgs);

            if (LogHistory.Count > LogHistoryLimit)
                PruneLogHistory();
        }

        /// <summary>
        /// Repeatedly Dequeues logs from the LogHistory queue until the queue length matches LogHistoryLimit.
        /// </summary>
        private static void PruneLogHistory()
        {
            while (LogHistory.Count > LogHistoryLimit)
                LogHistory.Dequeue();
        }

        #endregion

        #region Public

        /// <summary>
        ///     Called by the NLog method logging target, this method fires the Changed event with the thread ID, timestamp, 
        ///     level, logger and message associated with the new log message.
        /// </summary>
        /// <param name="threadID">The ID of the thread that originated the log message.</param>
        /// <param name="dateTime">The timestamp of the log message in long date format.</param>
        /// <param name="level">The level of the log message.</param>
        /// <param name="logger">The logger instance that generated the message.</param>
        /// <param name="message">The log message.</param>
        public static void AppendLog(string threadID, string dateTime, string level, string logger, string message)
        {
            if (!initialized)
                Initialize();

            RealtimeLoggerEventArgs eventArgs = new RealtimeLoggerEventArgs(threadID, dateTime, level, logger, message);

            AppendLogHistory(eventArgs);

            if (LogArrived != null)
                LogArrived(default(object), eventArgs);
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Contains the EventArgs associated with the RealtimeLogger Changed event.
    /// </summary>
    public class RealtimeLoggerEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// The ID of the thread that originated the log message.
        /// </summary>
        public int ThreadID { get; private set; }

        /// <summary>
        /// The timestamp of the log message.
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// The logging level of the log message.
        /// </summary>
        public LogLevel Level { get; private set; }

        /// <summary>
        /// The name of the logger that generated the log message.
        /// </summary>
        public string Logger { get; private set; }

        /// <summary>
        /// The log message.
        /// </summary>
        public string Message { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.  Creates a new instance of RealtimeLoggerEventArgs with the supplied parameters.
        /// </summary>
        /// <param name="threadID">The ID of the thread that originated the log message.</param>
        /// <param name="dateTime">The timestamp of the log message in long date format.</param>
        /// <param name="level">The level of the log message.</param>
        /// <param name="logger">The logger instance that generated the message.</param>
        /// <param name="message">The log message.</param>
        public RealtimeLoggerEventArgs(string threadID, string dateTime, string level, string logger, string message)
        {
            // set up an empty prefix in case we need to append warnings
            string prefix = "";

            // parse the thread ID
            int parsedThreadID;

            if (int.TryParse(threadID, out parsedThreadID))
                ThreadID = parsedThreadID;
            else
            {
                ThreadID = 1;
                prefix += "[Invalid ThreadID; substituted with default]";
            }

            // ensure the supplied long date string is a valid DateTime
            // substitute with the current timestamp if parse fails
            DateTime parsedDateTime;

            if (DateTime.TryParse(dateTime, out parsedDateTime))
                DateTime = parsedDateTime;
            else
            {
                DateTime = DateTime.Now;
                prefix += "[Invalid DateTime; substituted with DateTime.Now]";
            }

            // determine the LogLevel using the supplied level string.
            // if the level isn't found or level is null, substitute LogLevel.Info
            try
            {
                Level = LogLevel.FromString(level);
            }
            catch (Exception ex)
            {
                if ((ex is ArgumentException) || (ex is ArgumentNullException))
                {
                    Level = LogLevel.Info;
                    prefix += "[Invalid LogLevel; substituted with LogLevel.Info]";
                }
                else
                    throw;
            }

            Logger = logger;
            Message = prefix + message;
        }

        #endregion
    }
}
