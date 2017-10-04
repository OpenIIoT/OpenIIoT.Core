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
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.SDK.Common.OperationResult
{
    /// <summary>
    ///     Defines the message type for an operation message.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        ///     The default type; represents any level.
        /// </summary>
        Any,

        /// <summary>
        ///     The message contains low level trace information.
        /// </summary>
        Info,

        /// <summary>
        ///     The message represents a recoverable issue.
        /// </summary>
        Warning,

        /// <summary>
        ///     The message represents an unrecoverable error.
        /// </summary>
        Error
    }

    /// <summary>
    ///     Defines the return result of an operation.
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        ///     The default return type.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The operation succeeded.
        /// </summary>
        Success,

        /// <summary>
        ///     The operation encountered recoverable issues and ultimately succeeded.
        /// </summary>
        Warning,

        /// <summary>
        ///     The operation encountered unrecoverable errors and did not succeed.
        /// </summary>
        Failure
    }
}