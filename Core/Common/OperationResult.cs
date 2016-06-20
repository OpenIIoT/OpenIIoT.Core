/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █
      █    ▄██████▄                                                                              ▄████████
      █   ███    ███                                                                            ███    ███
      █   ███    ███    ██████▄    ▄██████    ██████   ▄█████      ██     █   ██████  ██▄▄▄▄    ███    ███    ▄██████   ▄██████ ██    █   █           ██     
      █   ███    ███   ██    ██   ██    █    ██   ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄  ▄███▄▄▄▄██▀   ██    █    ██   ▀  ██    ██ ██       ▀███████▄  
      █   ███    ███   ██    ██  ▄██▄▄▄     ▄██▄▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ▀▀███▀▀▀▀▀    ▄██▄▄▄      ██      ██    ██ ██           ██  ▀  
      █   ███    ███ ▀███████▀  ▀▀██▀▀▀    ▀████████ ▀████████     ██    ██  ██    ██ ██   ██ ▀███████████ ▀▀██▀▀▀    ▀████████ ██    ██ ██           ██     
      █   ███    ███   ██         ██    █    ██   ██   ██   ██     ██    ██  ██    ██ ██   ██   ███    ███   ██    █     ▄   ██ ██    ██ ██▌    ▄     ██     
      █    ▀██████▀   ▄███▀       ████████   ██   ██   ██   █▀    ▄██▀   █    ██████   █   █    ███    ███   ████████  ▄█████▀  ███████  ████▄▄██    ▄██▀     
      █
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █ 
      █  Encapsulates the result of any operation. Includes a result code and a list of messages generated during the operation.
      █
      █  Additional methods provide logging functionality for convenience, and a generic extension class is provided to allow for 
      █  OperationResult instances which contain an object as a return value.
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
                                                                                                   ▀▀                               */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Symbiote.Core
{
    /// <summary>
    /// Defines the return result of an operation.
    /// </summary>
    public enum OperationResultCode
    {
        /// <summary>
        /// The default return type.
        /// </summary>
        Unknown,
        /// <summary>
        /// The operation succeeded.
        /// </summary>
        Success,
        /// <summary>
        /// The operation encountered recoverable issues and ultimately succeeded.
        /// </summary>
        Warning,
        /// <summary>
        /// The operation encountered unrecoverable errors and did not succeed.
        /// </summary>
        Failure
    }

    /// <summary>
    /// Defines the message type for an operation message.
    /// </summary>
    public enum OperationResultMessageType
    {
        /// <summary>
        /// The message contains low level trace information.
        /// </summary>
        Info,
        /// <summary>
        /// The message represents a recoverable issue.
        /// </summary>
        Warning,
        /// <summary>
        /// The message represents an uncoverable error.
        /// </summary>
        Error
    }

    /// <summary>
    /// Encapsulates messages generated by Operations.
    /// </summary>
    public class OperationResultMessage
    {
        #region Properties

        /// <summary>
        /// The <see cref="OperationResultMessageType"/> of the message.
        /// </summary>
        public OperationResultMessageType Type { get; set; }

        /// <summary>
        /// The message.
        /// </summary>
        public string Message { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a message of the optionally supplied <see cref="OperationResultMessageType"/> 
        /// with the optionally supplied message.
        /// </summary>
        /// <param name="type">The <see cref="OperationResultMessageType"/> of the message.</param>
        /// <param name="message">The content of the message.</param>
        public OperationResultMessage(OperationResultMessageType type = OperationResultMessageType.Info, string message = "")
        {
            Type = type;
            Message = message;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a formatted string representation of the message
        /// </summary>
        /// <returns>The formatted message string.</returns>
        public override string ToString()
        {
            return "[" + Type.ToString().ToUpper() + "] " + Message;
        }

        #endregion
    }

    /// <summary>
    /// Encapsulates the result of an operation, including a result code and list of messages generated during the operation.
    /// </summary>
    public class OperationResult
    {
        #region Properties

        /// <summary>
        /// The <see cref="OperationResultCode"/> of the operation.
        /// </summary>
        public OperationResultCode ResultCode { get; private set; }

        /// <summary>
        /// The <see cref="List{T}"/> of <see cref="OperationResultMessage"/>es generated during the operation.
        /// </summary>
        public List<OperationResultMessage> Messages { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new OperationResult with a <see cref="ResultCode"/> of type <see cref="OperationResultCode.Success"/> 
        /// and containing an empty list of <see cref="Messages"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationResult retVal = new OperationResult();
        /// </code>
        /// </example>
        public OperationResult()
        {
            ResultCode = OperationResultCode.Success;
            Messages = new List<OperationResultMessage>();
        }

        #endregion

        #region Instance Methods

        #region Private

        /// <summary>
        /// Logs the supplied message using the supplied logging method <see cref="Action{T}"/>.
        /// </summary>
        /// <param name="action">The logging method <see cref="Action{T}"/> with which to log the message.</param>
        /// <param name="message">The message.</param>
        /// <remarks>
        ///     The accessibility for this method is set to protected as there is no use case for this beyond the 
        ///     support of the other logging methods in this class or derived classes.
        /// </remarks>
        protected void Log(Action<string> action, string message = "")
        {
            action(message);
        }

        #endregion

        #region Public

        /// <summary>
        /// Adds a message of type <see cref="OperationResultMessageType.Info"/> to the message list.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>This OperationResult.</returns>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationResult retVal = new OperationResult();
        /// 
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        /// </code>
        /// </example>
        public virtual OperationResult AddInfo(string message)
        {
            Messages.Add(new OperationResultMessage(OperationResultMessageType.Info, message));
            return this;
        }

        /// <summary>
        /// Adds a message of type <see cref="OperationResultMessageType.Warning"/> to the message list and sets the ResultCode to Warning.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="message">The message to add.</param>
        /// <returns>This OperationResult</returns>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationResult retVal = new OperationResult();
        /// 
        /// // add an informational message
        /// retVal.AddWarning("This is a warning message");
        /// </code>
        /// </example>
        public virtual OperationResult AddWarning(string message)
        {
            Messages.Add(new OperationResultMessage(OperationResultMessageType.Warning, message));
            ResultCode = OperationResultCode.Warning;
            return this;
        }

        /// <summary>
        /// Adds a message of type <see cref="OperationResultMessageType.Error"/> to the message list and sets the ResultCode to Error.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>This OperationResult.</returns>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationResult retVal = new OperationResult();
        /// 
        /// // add an informational message
        /// retVal.AddError("This is an error message");
        /// </code>
        /// </example>
        public virtual OperationResult AddError(string message)
        {
            Messages.Add(new OperationResultMessage(OperationResultMessageType.Error, message));
            ResultCode = OperationResultCode.Failure;
            return this;
        }

        /// <summary>
        ///     Logs the result of the operation using the supplied logger method and the optional caller as the source.
        ///     The default logging methods are applied to corresponding message types; Info for Info, Warn for Warning and Error for Errors.
        /// </summary>
        /// <remarks>
        /// <para>
        ///     The caller parameter is automatically set to the calling method.  In some cases, such as when a result for a method
        ///     is logged within a method different from the executing method, this will need to be explicitly specified
        ///     to reflect the actual source of the OperationResult.
        /// </para>
        /// <para>
        ///     If a logger different from NLog is desired, modify the type of the logger parameter accordingly and substitute
        ///     the appropriate methods for info, warn and error log levels (assuming they are applicable).
        /// </para>
        /// </remarks>
        /// <param name="logger">The logger with which to log the result.</param>
        /// <param name="caller">The name of calling method.</param>
        /// <returns>This <see cref="OperationResult"/>.</returns>
        /// <seealso cref="LogResult(Action{string}, Action{string}, Action{string}, string)"/>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationResult retVal = new OperationResult();
        /// 
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        /// 
        /// // log the result
        /// // use logger.Info for basic and informational messages, logger.Warn for warnings
        /// // and logger.Error for errors.
        /// retVal.LogResult(logger);
        /// </code>
        /// </example>
        public virtual OperationResult LogResult(NLog.Logger logger, [CallerMemberName]string caller = "")
        {
            return LogResult(logger.Info, logger.Warn, logger.Error, caller);
        }

        /// <summary>
        /// Logs the result of the operation using the supplied logger method and the optional caller as the source.
        /// The supplied logging method is applied to all message types.
        /// </summary>
        /// <remarks>
        /// The caller parameter is automatically set to the calling method.  In some cases, such as when a result for a method
        /// is logged within a method different from the executing method, this will need to be explicitly specified
        /// to reflect the actual source of the OperationResult.
        /// </remarks>
        /// <param name="action">The logging method with which to log the result.</param>
        /// <param name="caller">The name of the calling method.</param>
        /// <returns>This <see cref="OperationResult"/>.</returns>
        /// <seealso cref="LogResult(Action{string}, Action{string}, Action{string}, string)"/>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationResult retVal = new OperationResult();
        /// 
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        /// 
        /// // log the result using the Debug logging level for all message types.
        /// retVal.LogResult(logger.Debug);
        /// </code>
        /// </example>
        public virtual OperationResult LogResult(Action<string> action, [CallerMemberName]string caller ="")
        {
            return LogResult(action, action, action, caller);
        }

        /// <summary>
        /// Logs the result of the operation using the supplied logging methods and the optional caller as the source.
        /// </summary>
        /// <remarks>
        /// The caller parameter is automatically set to the calling method.  In some cases, such as when a result for a method
        /// is logged within a method different from the executing method, this will need to be explicitly specified
        /// to reflect the actual source of the OperationResult.
        /// </remarks>
        /// <param name="successAction">The logging method with which to log successful messages.</param>
        /// <param name="warningAction">The logging method with which to log warning messages.</param>
        /// <param name="failureAction">The logging method with which to log messages.</param>
        /// <param name="caller">The name of the calling method.</param>
        /// <returns>This <see cref="OperationResult"/>.</returns>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationResult retVal = new OperationResult();
        /// 
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        /// 
        /// // log the result
        /// // use logger.Trace for basic and informational messages, logger.Debug for warnings
        /// // and logger.Warn for errors.
        /// retVal.LogResult(logger.Trace, logger.Debug, logger.Warn);
        /// </code>
        /// </example>
        public virtual OperationResult LogResult(Action<string> successAction, Action<string> warningAction, Action<string> failureAction, [CallerMemberName]string caller = "")
        {
            // the operation suceeded, with or without warnings
            if (ResultCode != OperationResultCode.Failure)
            {
                Log(successAction, "The operation '" + caller + "' completed successfully.");

                // if any informational messages were generated, print them to the logger
                if (Messages.Where(m => m.Type == OperationResultMessageType.Info).Count() > 0)
                    LogAllMessages(successAction, "The following informational messages were generated during the operation:");

                // if any warnings were generated, print them to the logger
                if (ResultCode == OperationResultCode.Warning)
                    LogAllMessages(warningAction, "The following warnings were generated during the operation:");
            }
            // the operation failed
            else
            {
                Log(failureAction, "The operation '" + caller + "' failed.");
                LogAllMessages(failureAction, "The following messages were generated during the operation:");
            }

            return this;
        }

        /// <summary>
        /// Logs all messages in the message list to the supplied logging method.  If specified, logs a header and footer message before and after the list, respectively.
        /// </summary>
        /// <param name="action">The logging method with which to log the messages.</param>
        /// <param name="header">A header message to log prior to the list of messages.</param>
        /// <param name="footer">A footer message to display after the list of messages.</param>
        /// <returns>This <see cref="OperationResult"/>.</returns>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationResult retVal = new OperationResult();
        /// 
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        /// 
        /// // add a warning
        /// retVal.AddWarning("This is a warning");
        /// 
        /// // log the list of messages with the Info logging level
        /// // include a header and footer
        /// retVal.LogAllMessages(logger.Info, "Message list:", "End of list.");
        /// </code>
        /// </example>
        public virtual OperationResult LogAllMessages(Action<string> action, string header = "", string footer = "")
        {
            if (header != "") Log(action, header);

            foreach (OperationResultMessage message in Messages)
                Log(action, new string(' ', 5) + message.Message);

            if (footer != "") Log(action, footer);

            return this;
        }

        /// <summary>
        /// Returns the most recently added informational message contained within the message list.
        /// </summary>
        /// <returns>The message.</returns>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationREsult retVal = new OperationResult();
        /// 
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        /// 
        /// // print the last info message
        /// Console.WriteLine(retVal.LastInfoMessage());
        /// </code>
        /// </example>
        public virtual string LastInfoMessage()
        {
            return Messages.Where(m => m.Type == OperationResultMessageType.Info).LastOrDefault().Message ?? "";
        }

        /// <summary>
        /// Returns the most recently added warning message contained within the message list.
        /// </summary>
        /// <returns>The message.</returns>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationREsult retVal = new OperationResult();
        /// 
        /// // add a warning message
        /// retVal.AddWarning("This is a warning");
        /// 
        /// // print the last warning
        /// Console.WriteLine(retVal.LastWarningMessage());
        /// </code>
        /// </example>
        public virtual string LastWarningMessage()
        {
            return Messages.Where(m => m.Type == OperationResultMessageType.Warning).LastOrDefault().Message ?? "";
        }

        /// <summary>
        /// Returns the most recently added error message contained within the message list.
        /// </summary>
        /// <returns>The message.</returns>
        /// <example>
        /// <code>
        /// // create a new OperationResult
        /// OperationREsult retVal = new OperationResult();
        /// 
        /// // add an error message
        /// retVal.AddError("This is an error");
        /// 
        /// // print the last error
        /// Console.WriteLine(retVal.LastErrorMessage());
        /// </code>
        /// </example>
        public virtual string LastErrorMessage()
        {
            return Messages.Where(m => m.Type == OperationResultMessageType.Error).LastOrDefault().Message ?? "";
        }

        /// <summary>
        /// Adds details from the supplied OperationResult to this OperationResult.
        /// Copies all Messages and the status if lesser than this status.
        /// </summary>
        /// <param name="operationResult">The OperationResult from which to copy the Messages.</param>
        /// <example>
        /// <code>
        /// // create an "outer" OperationResult
        /// // the ResultCode of this instance is Success by default.
        /// OperationResult outer = new OperationResult();
        /// 
        /// // ... some logic ...
        /// 
        /// // create an "inner" OperationResult
        /// // set this to the result of a different method
        /// OperationResult inner = MyMethod();
        /// 
        /// // incorporate the inner OperationResult into the outer
        /// // this copies all messages and, if the inner instance's ResultCode
        /// // is lesser (Success > Warning > Failure) than the outer, copies the ResultCode as well.
        /// outer.Incorporate(inner);
        /// 
        /// // log the result.  the combined list of messages from both inner and outer
        /// // are logged, and the ResultCode is equal to the lesser of the two ResultCodes.
        /// outer.LogResult(logger); 
        /// </code>
        /// </example>
        public virtual OperationResult Incorporate(OperationResult operationResult)
        {
            foreach (OperationResultMessage message in operationResult.Messages)
                Messages.Add(message);

            // if the value of this OperationResult's ResultCode is less than the provided OperationResult, 
            // copy the provided ResultCode into this ResultCode.  e.g., if we have a warning and we incorporate
            // a failure, we become a failure.
            // unknown < success < warning < failure
            if (ResultCode.CompareTo(operationResult.ResultCode) < 0)
                ResultCode = operationResult.ResultCode;

            return this;
        }
        
        #endregion 

        #endregion

        #region Static Methods

        /// <summary>
        /// Allows for implicit casts to boolean.  Returns false if ResultCode is Failure, true otherwise.
        /// </summary>
        /// <param name="operationResult">The OperationResult to convert.</param>
        /// <example>
        /// <code>
        /// // generate an OperationResult
        /// OperationResult result = SomeOperation();
        /// 
        /// // check the result
        /// if (!result)
        /// {
        ///     Console.WriteLine("Operation failed!");
        /// }
        /// else
        ///     Console.WriteLine("Operation succeeded!");
        /// </code>
        /// </example>
        public static implicit operator bool(OperationResult operationResult)
        {
            return (operationResult.ResultCode != OperationResultCode.Failure);
        }

        #endregion
    }

    /// <summary>
    /// Encapsulates the result of any operation, including a result code, a list of messages generated during the operation, and an object of type T.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Result"/> property.</typeparam>
    public class OperationResult<T> : OperationResult
    {
        #region Properties

        /// <summary>
        /// An object containing the result of the operation.
        /// </summary>
        public T Result { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a default OperationResult.
        /// </summary>
        public OperationResult() : base()
        {
            Result = default(T);
        }

        #endregion

        #region Instance Methods

        #region Public 

        /// <summary>
        /// Adds a message of type <see cref="OperationResultMessageType.Info"/> to the message list.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>This OperationResult.</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// // create a new OperationResult
        /// OperationResult<object> retVal = new OperationResult<object>();
        /// 
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        /// ]]>
        /// </code>
        /// </example>
        new public virtual OperationResult<T> AddInfo(string message)
        {
            base.AddInfo(message);
            return this;
        }

        /// <summary>
        /// Adds a message of type <see cref="OperationResultMessageType.Warning"/> to the message list and sets the ResultCode to Warning.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="message">The message to add.</param>
        /// <returns>This OperationResult.</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// // create a new OperationResult
        /// OperationResult<object> retVal = new OperationResult<object>();
        /// 
        /// // add an informational message
        /// retVal.AddWarning("This is a warning message");
        /// ]]>
        /// </code>
        /// </example>
        new public virtual OperationResult<T> AddWarning(string message)
        {
            base.AddWarning(message);
            return this;
        }

        /// <summary>
        /// Adds a message of type <see cref="OperationResultMessageType.Error"/> to the message list and sets the ResultCode to Error.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>This OperationResult.</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// // create a new OperationResult
        /// OperationResult<object> retVal = new OperationResult<object>();
        /// 
        /// // add an informational message
        /// retVal.AddError("This is an error message");
        /// ]]>
        /// </code>
        /// </example>
        new public virtual OperationResult<T> AddError(string message)
        {
            base.AddError(message);
            return this;
        }

        /// <inheritdoc/>
        /// <returns>This <see cref="OperationResult{T}"/>.</returns>
        new public virtual OperationResult<T> LogResult(NLog.Logger logger, [CallerMemberName]string caller = "")
        {
            base.LogResult(logger, caller);
            return this;
        }

        /// <inheritdoc/>
        /// <returns>This <see cref="OperationResult{T}"/>.</returns>
        new public virtual OperationResult<T> LogResult(Action<string> action, [CallerMemberName]string caller = "")
        {
            base.LogResult(action, caller);
            return this;
        }

        /// <inheritdoc/>
        /// <returns>This <see cref="OperationResult{T}"/>.</returns>
        new public virtual OperationResult LogResult(Action<string> successAction, Action<string> warningAction, Action<string> failureAction, [CallerMemberName]string caller = "")
        {
            base.LogResult(successAction, warningAction, failureAction, caller);
            return this;
        }

        /// <inheritdoc/>
        /// <returns>This <see cref="OperationResult{T}"/>.</returns>
        new public virtual OperationResult<T> LogAllMessages(Action<string> action, string header = "", string footer = "")
        {
            base.LogAllMessages(action, header, footer);
            return this;
        }

        /// <inheritdoc/>
        /// <returns>This <see cref="OperationResult{T}"/>.</returns>
        new public virtual OperationResult<T> Incorporate(OperationResult operationResult)
        {
            base.Incorporate(operationResult);
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Result"/> property to the specified value.
        /// </summary>
        /// <param name="result">The value to which the <see cref="Result"/> property is to be set.</param>
        /// <returns>This <see cref="OperationResult{T}"/>.</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// ///create a new OperationResult
        /// OperationResult<string> or = new OperationResult<string>()
        /// or
        ///   .SetResult("Hello World!")
        ///   .AddInfo("Set value.")
        ///   .LogResult(logger.Info);
        ///  
        /// ]]>
        /// </code>
        /// </example>
        public OperationResult<T> SetResult(T result)
        {
            Result = result;
            return this;
        }

        #endregion

        #endregion
    }
}
