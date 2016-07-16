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
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      ▄  
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
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NLog;

namespace Symbiote.Core
{
    /// <summary>
    /// The <see cref="RealtimeLogger"/> class acts as a target for the NLog method logging target.  
    /// Fires the LogArrived event when new log messages are created by NLog.
    /// </summary>
    public class RealtimeLogger
    {
        #region Fields

        /// <summary>
        /// The default log history limit.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1303:ConstFieldNamesMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]
        private const int logHistoryLimit = 200;

        /// <summary>
        /// Initialization status of the class.
        /// </summary>
        private static bool initialized = false;

        #endregion

        #region Constructors

        /// <summary>
        /// TInitializes a new instance of the <see cref="RealtimeLogger"/> class.
        /// </summary>
        /// <remarks>
        ///     Included for good measure.  Not invoked when member methods are invoked using reflection,
        ///     such as through NLog's MethodCall target.
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

        #endregion

        #region Properties

        /// <summary>
        /// Gets a queue containing the newest log messages, up to the LogHistoryLimit.
        /// </summary>
        public static Queue<RealtimeLoggerEventArgs> LogHistory { get; private set; }

        /// <summary>
        /// Gets or sets the maximum number of log messages to store in the log history queue.
        /// </summary>
        /// <remarks>
        /// If the value is reduced while the log is populated, the length of the LogHistory queue
        /// will be reduced to the desired value upon the addition of the next log.
        /// </remarks>
        public static int LogHistoryLimit { get; set; }

        #endregion

        #region Methods

        #region Public Methods

        #region Public Static Methods

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
            {
                Initialize();
            }

            RealtimeLoggerEventArgs eventArgs = new RealtimeLoggerEventArgs(threadID, dateTime, level, logger, message);

            AppendLogHistory(eventArgs);

            if (LogArrived != null)
            {
                LogArrived(default(object), eventArgs);
            }
        }

        #endregion

        #endregion

        #region Private Methods

        #region Private Static Methods

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
        /// Enqueues the supplied <see cref="RealtimeLoggerEventArgs"/> instance to the LogHistory queue.  
        /// If the queue exceeds 200 entries, the oldest log is first de-queued before the new log is enqueued.
        /// </summary>
        /// <param name="eventArgs">The event args instance to enqueue.</param>
        private static void AppendLogHistory(RealtimeLoggerEventArgs eventArgs)
        {
            LogHistory.Enqueue(eventArgs);

            if (LogHistory.Count > LogHistoryLimit)
            {
                PruneLogHistory();
            }
        }

        /// <summary>
        /// Repeatedly De-queues logs from the LogHistory queue until the queue length matches LogHistoryLimit.
        /// </summary>
        private static void PruneLogHistory()
        {
            while (LogHistory.Count > LogHistoryLimit)
            {
                LogHistory.Dequeue();
            }
        }

        #endregion

        #endregion

        #endregion
    }

    /// <summary>
    /// Contains the EventArgs associated with the <see cref="RealtimeLogger"/> Changed event.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class RealtimeLoggerEventArgs : EventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeLoggerEventArgs"/> class with the supplied parameters.
        /// </summary>
        /// <param name="threadID">The ID of the thread that originated the log message.</param>
        /// <param name="dateTime">The timestamp of the log message in long date format.</param>
        /// <param name="level">The level of the log message.</param>
        /// <param name="logger">The logger instance that generated the message.</param>
        /// <param name="message">The log message.</param>
        public RealtimeLoggerEventArgs(string threadID, string dateTime, string level, string logger, string message)
        {
            // set up an empty prefix in case we need to append warnings
            string prefix = string.Empty;

            // parse the thread ID
            int parsedThreadID;

            if (int.TryParse(threadID, out parsedThreadID))
            {
                this.ThreadID = parsedThreadID;
            }
            else
            {
                this.ThreadID = 1;
                prefix += "[Invalid ThreadID; substituted with default]";
            }

            // ensure the supplied long date string is a valid DateTime
            // substitute with the current timestamp if parse fails
            DateTime parsedDateTime;

            if (DateTime.TryParse(dateTime, out parsedDateTime))
            {
                this.DateTime = parsedDateTime;
            }
            else
            {
                this.DateTime = DateTime.Now;
                prefix += "[Invalid DateTime; substituted with DateTime.Now]";
            }

            // determine the LogLevel using the supplied level string.
            // if the level isn't found or level is null, substitute LogLevel.Info
            try
            {
                this.Level = LogLevel.FromString(level);
            }
            catch (Exception ex)
            {
                if ((ex is ArgumentException) || (ex is ArgumentNullException))
                {
                    this.Level = LogLevel.Info;
                    prefix += "[Invalid LogLevel; substituted with LogLevel.Info]";
                }
                else
                {
                    throw;
                }
            }

            this.Logger = logger;
            this.Message = prefix + message;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the ID of the thread that originated the log message.
        /// </summary>
        public int ThreadID { get; private set; }

        /// <summary>
        /// Gets the timestamp of the log message.
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Gets the logging level of the log message.
        /// </summary>
        public LogLevel Level { get; private set; }

        /// <summary>
        /// Gets the name of the logger that generated the log message.
        /// </summary>
        public string Logger { get; private set; }

        /// <summary>
        /// Gets the log message.
        /// </summary>
        public string Message { get; private set; }

        #endregion
    }
}
