/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █     ▄████████
      █     ███    ███
      █     ███    ███    █████▄    █████▄  █        █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄
      █     ███    ███   ██   ██   ██   ██ ██       ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄
      █   ▀███████████   ██   ██   ██   ██ ██       ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██
      █     ███    ███ ▀██████▀  ▀██████▀  ██       ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██
      █     ███    ███   ██        ██      ██▌    ▄ ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██
      █     ███    █▀   ▄███▀     ▄███▀    ████▄▄██ █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █
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
      █  Exceptions for the Program class.
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

namespace OpenIIoT.SDK
{
    /// <summary>
    ///     Represents errors that occur while parsing and applying command line arguments.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ApplicationArgumentException : ApplicationException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationArgumentException"/> class.
        /// </summary>
        public ApplicationArgumentException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationArgumentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApplicationArgumentException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationArgumentException"/> class with a specified error message
        ///     and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ApplicationArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur while initializing the Application.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ApplicationInitializationException : ApplicationException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationInitializationException"/> class.
        /// </summary>
        public ApplicationInitializationException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationInitializationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApplicationInitializationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationInitializationException"/> class with a specified error
        ///     message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ApplicationInitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur while performing the Application shutdown routine.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ApplicationShutdownRoutineException : ApplicationException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationShutdownRoutineException"/> class.
        /// </summary>
        public ApplicationShutdownRoutineException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationShutdownRoutineException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApplicationShutdownRoutineException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationShutdownRoutineException"/> class with a specified error
        ///     message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ApplicationShutdownRoutineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur while starting the Application.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ApplicationStartException : ApplicationException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStartException"/> class.
        /// </summary>
        public ApplicationStartException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStartException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApplicationStartException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStartException"/> class with a specified error message and
        ///     a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ApplicationStartException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur while performing the Application startup routine.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ApplicationStartupRoutineException : ApplicationException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStartupRoutineException"/> class.
        /// </summary>
        public ApplicationStartupRoutineException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStartupRoutineException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApplicationStartupRoutineException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStartupRoutineException"/> class with a specified error
        ///     message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ApplicationStartupRoutineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }

    /// <summary>
    ///     Represents errors that occur while stopping the Application.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ApplicationStopException : ApplicationException
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStopException"/> class.
        /// </summary>
        public ApplicationStopException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStopException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApplicationStopException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationStopException"/> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ApplicationStopException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }
}