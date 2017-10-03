/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄██████▄                                                                           ▄████████
      █   ███    ███                                                                         ███    ███
      █   ███    ███    █████▄    ▄█████    █████   ▄█████      ██     █   ██████  ██▄▄▄▄   ▄███▄▄▄▄██▀    ▄█████   ▄█████ ██   █   █           ██
      █   ███    ███   ██   ██   ██   █    ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ▀▀███▀▀▀▀▀     ██   █    ██  ▀  ██   ██ ██       ▀███████▄
      █   ███    ███   ██   ██  ▄██▄▄     ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ▀███████████  ▄██▄▄      ██     ██   ██ ██           ██  ▀
      █   ███    ███ ▀██████▀  ▀▀██▀▀    ▀███████ ▀████████     ██    ██  ██    ██ ██   ██   ███    ███ ▀▀██▀▀    ▀███████ ██   ██ ██           ██
      █   ███    ███   ██        ██   █    ██  ██   ██   ██     ██    ██  ██    ██ ██   ██   ███    ███   ██   █     ▄  ██ ██   ██ ██▌    ▄     ██
      █    ▀██████▀   ▄███▀      ███████   ██  ██   ██   █▀    ▄██▀   █    ██████   █   █    ███    ███   ███████  ▄████▀  ██████  ████▄▄██    ▄██▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Encapsulates the result of any operation. Includes a result code and a list of messages generated during the operation.
      █
      █  Additional methods provide logging functionality for convenience, and a generic extension class is provided to allow for
      █  Result instances which contain an object as a return value.
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
                                                                                                   ▀▀                            */

namespace OpenIIoT.SDK.Common.OperationResult
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using NLog;

    /// <summary>
    ///     Represents the result of an operation, including a result code and list of messages generated during the operation.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The primary function of the Result is to store the result of the operation in the <see cref="Result.ResultCode"/>
    ///         property. This property is of type <see cref="ResultCode"/>, which has members <see cref="ResultCode.Success"/>,
    ///         which represents successful operations, <see cref="ResultCode.Warning"/>, which represents operations that
    ///         succeeded but generated warning messages while executing, and <see cref="ResultCode.Failure"/>, which represents
    ///         operations that failed.
    ///     </para>
    ///     <para>
    ///         Operations may also generate messages as they execute. These messages are stored in the
    ///         <see cref="Result.Messages"/> property as a <see cref="List{T}"/> of type <see cref="Message"/>. Each message
    ///         consists of an <see cref="MessageType"/> representing the type of message (informational with
    ///         <see cref="MessageType.Info"/>, warning with <see cref="MessageType.Warning"/>, and errors with
    ///         <see cref="MessageType.Error"/>), and a string containing the message itself.
    ///     </para>
    ///     <para>
    ///         Messages can be added to the Result with the <see cref="AddInfo(string)"/>, <see cref="AddWarning(string)"/> and
    ///         <see cref="AddError(string)"/> methods. The AddWarning() and AddError() messages automatically change the
    ///         ResultCode to Warning and Failure when invoked, respectively.
    ///     </para>
    ///     <para>
    ///         Several shorthand logging methods are provided, namely <see cref="LogResult(NLog.Logger, string)"/> and it's
    ///         overloads, and <see cref="LogAllMessages(Action{string}, string, string)"/>. These methods are designed to leverage
    ///         NLog, however overloads are provided so that most logging functionality can be used by supplying a delegate method
    ///         which accepts a string parameter.
    ///     </para>
    ///     <para>
    ///         The <see cref="Incorporate(IResult)"/> method is provided so that Result objects can be merged with one another.
    ///         The instance on which the Incorporate() method is invoked will copy all messages from the specified Result into
    ///         it's list, and if the ResultCode of the specified Result is "less than" that of the current instance, the instance
    ///         will take on the new ResultCode. For instance, if the invoking instance has a ResultCode of Warning and A Result
    ///         with a ResultCode of Failure is incorporated, the ResultCode of the invoking instance will be changed to Failure.
    ///         This functionality is provided for nested or sequential operations.
    ///     </para>
    ///     <para>
    ///         The generic version of Result, <see cref="Result{T}"/>, accepts a single type parameter and includes an additional
    ///         property corresponding to the specified type in <see cref="ReturnValue"/>. This functionality is provided for
    ///         operations which have a return value other than void, allowing these methods to return the original return value in
    ///         addition to the Result. This version also includes the <see cref="SetReturnValue(T)"/> method, which sets the value
    ///         of the Result property to the specified value. The property may also be set directly; this method, however, allows
    ///         for fluent API usage.
    ///     </para>
    /// </remarks>
    /// <typeparam name="T">The type of the object contained within the Result property.</typeparam>
    public interface IResult<T> : IResult
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the object containing the return value of the operation.
        /// </summary>
        T ReturnValue { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds a message of type Error to the message list and sets the ResultCode to Error.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result<T>
        /// Result<object> retVal = new Result<object>();
        ///
        /// // add an informational message
        /// retVal.AddError("This is an error message");
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> AddError(string message);

        /// <summary>
        ///     Adds a message of type Info to the message list.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result<T>
        /// Result<object> retVal = new Result<object>();
        ///
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> AddInfo(string message);

        /// <summary>
        ///     Adds a message of type Warning to the message list and sets the ResultCode to Warning.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>This Result</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result<T>
        /// Result<object> retVal = new Result<object>();
        ///
        /// // add an informational message
        /// retVal.AddWarning("This is a warning message");
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> AddWarning(string message);

        /// <summary>
        ///     Adds details from the specified Result to this Result, including all Messages and the ResultCode, if lesser than
        ///     the ResultCode of this instance.
        /// </summary>
        /// <param name="result">The Result from which to copy the Messages.</param>
        /// <returns>A Result containing the result of the operation and the return value.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create an "outer" Result<T>
        /// // the ResultCode of this instance is Success by default.
        /// Result<object> outer = new Result<object>();
        ///
        /// // ... some logic ...
        ///
        /// // create an "inner" Result<T>
        /// // set this to the result of a different method
        /// Result<object> inner = MyMethod<object>();
        ///
        /// // incorporate the inner Result into the outer
        /// // this copies all messages and, if the inner instance's ResultCode
        /// // is lesser (Success > Warning > Failure) than the outer, copies the ResultCode as well.
        /// outer.Incorporate(inner);
        ///
        /// // log the result.  the combined list of messages from both inner and outer
        /// // are logged, and the ResultCode is equal to the lesser of the two ResultCodes.
        /// outer.LogResult(logger);
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> Incorporate(IResult result);

        /// <summary>
        ///     Logs all messages in the message list to the specified logging method. If specified, logs a header and footer
        ///     message before and after the list, respectively.
        /// </summary>
        /// <param name="action">The logging method with which to log the messages.</param>
        /// <param name="header">A header message to log prior to the list of messages.</param>
        /// <param name="footer">A footer message to display after the list of messages.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result<T>
        /// Result<object> retVal = new Result<object>();
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
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> LogAllMessages(Action<string> action, string header = "", string footer = "");

        /// <summary>
        ///     Logs the result of the operation using the specified logger instance and the optionally specified caller as the source.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The default logging methods are applied to corresponding message types; Info for Info, Warn for Warning and
        ///         Error for Errors.
        ///     </para>
        ///     <para>
        ///         The caller parameter is automatically set to the calling method. In some cases, such as when a result for a
        ///         method is logged within a method different from the executing method, this will need to be explicitly specified
        ///         to reflect the actual source of the Result.
        ///     </para>
        ///     <para>
        ///         If a logger different from NLog is desired, modify the type of the logger parameter accordingly and substitute
        ///         the appropriate methods for info, warn and error log levels (assuming they are applicable).
        ///     </para>
        /// </remarks>
        /// <param name="logger">The logger with which to log the result.</param>
        /// <param name="caller">The name of calling method.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result<T>
        /// Result<object> retVal = new Result<object>();
        ///
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        ///
        /// // log the result
        /// // use logger.Info for basic and informational messages, logger.Warn for warnings
        /// // and logger.Error for errors.
        /// retVal.LogResult(logger);
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> LogResult(Logger logger, [CallerMemberName]string caller = "");

        /// <summary>
        ///     Logs the result of the operation using the specified logging method and the optionally specified caller as the source.
        /// </summary>
        /// <remarks>
        ///     <para>The specified logging method is applied to all message types (Info, Warning, and Error).</para>
        ///     <para>
        ///         The caller parameter is automatically set to the calling method. In some cases, such as when a result for a
        ///         method is logged within a method different from the executing method, this will need to be explicitly specified
        ///         to reflect the actual source of the Result.
        ///     </para>
        /// </remarks>
        /// <param name="action">The logging method with which to log the result.</param>
        /// <param name="caller">The name of the calling method.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result<T>
        /// Result<object> retVal = new Result<object>();
        ///
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        ///
        /// // log the result using the Debug logging level for all message types.
        /// retVal.LogResult(logger.Debug);
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> LogResult(Action<string> action, [CallerMemberName]string caller = "");

        /// <summary>
        ///     Logs the result of the operation using the three specified logging methods and the optionally specified caller as
        ///     the source.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The first, second and third specified logging methods are applied to messages of type Info, Warning and Error, respectively.
        ///     </para>
        ///     <para>
        ///         The caller parameter is automatically set to the calling method. In some cases, such as when a result for a
        ///         method is logged within a method different from the executing method, this will need to be explicitly specified
        ///         to reflect the actual source of the Result.
        ///     </para>
        /// </remarks>
        /// <param name="successAction">The logging method with which to log successful messages.</param>
        /// <param name="warningAction">The logging method with which to log warning messages.</param>
        /// <param name="failureAction">The logging method with which to log messages.</param>
        /// <param name="caller">The name of the calling method.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result<T>
        /// Result<object> retVal = new Result<object>();
        ///
        /// // add an informational message
        /// retVal.AddInfo("This is an informational message");
        ///
        /// // log the result
        /// // use logger.Trace for basic and informational messages, logger.Debug for warnings
        /// // and logger.Warn for errors.
        /// retVal.LogResult(logger.Trace, logger.Debug, logger.Warn);
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> LogResult(Action<string> successAction, Action<string> warningAction, Action<string> failureAction, [CallerMemberName]string caller = "");

        /// <summary>
        ///     Removes all messages of the optionally specified MessageType, or all messages if MessageType is not specified.
        /// </summary>
        /// <param name="messageType">The type of messages to remove.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result
        /// Result<object> retVal = new Result<object>();
        ///
        /// // add a few messages
        /// retVal.AddError("This is an error message");
        /// retVal.AddError("This is another error message");
        ///
        /// // remove the messages that were just added
        /// retVal.RemoveMessages(MessageType.Error);
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> RemoveMessages(MessageType messageType = MessageType.Any);

        /// <summary>
        ///     Sets the ResultCode property to the optionally supplied ResultCode, or to ResultCode.Success if ResultCode is not specified.
        /// </summary>
        /// <param name="resultCode">The ResultCode to which the ResultCode property should be set.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// // create a new Result and initialize the ResultCode to ResultCode.Failure
        /// Result<object> retVal = new Result<object>().SetResultCode(ResultCode.Failure);
        /// ]]>
        ///     </code>
        /// </example>
        new Result<T> SetResultCode(ResultCode resultCode = ResultCode.Success);

        /// <summary>
        ///     Sets the ReturnValue property to the specified value.
        /// </summary>
        /// <param name="returnValue">The value to which the Result property is to be set.</param>
        /// <returns>This Result.</returns>
        /// <example>
        ///     <code>
        /// <![CDATA[
        /// ///create a new Result
        /// Result<string> result = new Result<string>()
        /// result
        ///   .SetReturnValue("Hello World!")
        ///   .AddInfo("Set value.")
        ///   .LogResult(logger.Info);
        /// ]]>
        ///     </code>
        /// </example>
        Result<T> SetReturnValue(T returnValue);

        #endregion Public Methods
    }
}