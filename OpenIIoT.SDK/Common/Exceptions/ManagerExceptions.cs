/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄
      █    ▄██▀▀▀███▀▀▀██▄
      █    ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █    ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █    ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █    ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █    ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █     ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
      █      ▄████████
      █     ███    ███
      █     ███    █▀  ▀███  ▐██▀  ▄██████    ▄█████    █████▄     ██     █   ██████  ██▄▄▄▄    ▄█████
      █    ▄███▄▄▄       ██  ██   ██    ██   ██   █    ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄   ██  ▀
      █   ▀▀███▀▀▀        ████▀   ██    ▀   ▄██▄▄      ██   ██     ██  ▀ ██▌ ██    ██ ██   ██   ██
      █     ███    █▄     ████    ██    ▄  ▀▀██▀▀    ▀██████▀      ██    ██  ██    ██ ██   ██ ▀███████
      █     ███    ███  ▄██ ▀██   ██    ██   ██   █    ██          ██    ██  ██    ██ ██   ██    ▄  ██
      █     ██████████ ███    ██▄ ██████▀    ███████  ▄███▀       ▄██▀   █    ██████   █   █   ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Exceptions for the Manager class and subclasses.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using System;
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

namespace OpenIIoT.SDK.Common.Exceptions
{
    /// <summary>
    ///     Represents errors that occur when referenced dependencies can not be resolved.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class DependencyNotResolvedException : ManagerException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DependencyNotResolvedException"/> class.
        /// </summary>
        public DependencyNotResolvedException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DependencyNotResolvedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DependencyNotResolvedException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DependencyNotResolvedException"/> class with a specified error message
        ///     and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public DependencyNotResolvedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur at the program level.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ManagerException : Exception
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerException"/> class.
        /// </summary>
        public ManagerException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerException"/> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur when the setup of a Manager returns an abnormal result.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ManagerSetupException : ManagerException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerSetupException"/> class.
        /// </summary>
        public ManagerSetupException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerSetupException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerSetupException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerSetupException"/> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ManagerSetupException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur when a Manager fails to start.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ManagerStartException : ManagerException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerStartException"/> class.
        /// </summary>
        public ManagerStartException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerStartException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerStartException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerStartException"/> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ManagerStartException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur when a Manager fails to stop.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ManagerStopException : ManagerException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerStopException"/> class.
        /// </summary>
        public ManagerStopException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerStopException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerStopException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerStopException"/> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ManagerStopException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }
}