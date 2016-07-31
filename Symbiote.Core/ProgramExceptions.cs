/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █      ▄███████▄                                                             
      █     ███    ███                                                             
      █     ███    ███    █████  ██████     ▄████▄     █████   ▄█████     ▄▄██▄▄▄  
      █     ███    ███   ██  ██ ██    ██   ██    ▀    ██  ██   ██   ██  ▄█▀▀██▀▀█▄ 
      █   ▀█████████▀   ▄██▄▄█▀ ██    ██  ▄██        ▄██▄▄█▀   ██   ██  ██  ██  ██ 
      █     ███        ▀███████ ██    ██ ▀▀██ ███▄  ▀███████ ▀████████  ██  ██  ██ 
      █     ███          ██  ██ ██    ██   ██    ██   ██  ██   ██   ██  ██  ██  ██ 
      █    ▄████▀        ██  ██  ██████    ██████▀    ██  ██   ██   █▀   █  ██  █  
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
      █  Exceptions for the Program and ProgramManager classes.
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

namespace Symbiote.Core
{
    /// <summary>
    /// Represents errors that occur at the program level.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ProgramException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramException"/> class.
        /// </summary>
        public ProgramException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProgramException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProgramException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur while parsing and applying command line arguments.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ProgramArgumentException : ProgramException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramArgumentException"/> class.
        /// </summary>
        public ProgramArgumentException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramArgumentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProgramArgumentException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramArgumentException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProgramArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur while initializing the program.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ProgramInitializationException : ProgramException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramInitializationException"/> class.
        /// </summary>
        public ProgramInitializationException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramInitializationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProgramInitializationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramInitializationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProgramInitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur while starting the program.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ProgramStartException : ProgramException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStartException"/> class.
        /// </summary>
        public ProgramStartException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStartException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProgramStartException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStartException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProgramStartException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur while stopping the program.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ProgramStopException : ProgramException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStopException"/> class.
        /// </summary>
        public ProgramStopException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStopException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProgramStopException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStopException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProgramStopException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur while performing the program startup routine.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ProgramStartupRoutineException : ProgramException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStartupRoutineException"/> class.
        /// </summary>
        public ProgramStartupRoutineException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStartupRoutineException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProgramStartupRoutineException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramStartupRoutineException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProgramStartupRoutineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur while performing the program shutdown routine.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ProgramShutdownRoutineException : ProgramException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramShutdownRoutineException"/> class.
        /// </summary>
        public ProgramShutdownRoutineException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramShutdownRoutineException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProgramShutdownRoutineException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramShutdownRoutineException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProgramShutdownRoutineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur within the ProgramManager class.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ProgramManagerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramManagerException"/> class.
        /// </summary>
        public ProgramManagerException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramManagerException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProgramManagerException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramManagerException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ProgramManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur Represents errors that occur when the type list argument for the ProgramManager constructor is malformed.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerTypeListException : ProgramManagerException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerTypeListException"/> class.
        /// </summary>
        public ManagerTypeListException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerTypeListException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerTypeListException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerTypeListException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerTypeListException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur Represents errors that occur when the instantiation of a Manager returns an abnormal result.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerInstantiationException : ProgramManagerException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerInstantiationException"/> class.
        /// </summary>
        public ManagerInstantiationException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerInstantiationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerInstantiationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerInstantiationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerInstantiationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur Represents errors that occur when the setup of a Manager returns an abnormal result.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerSetupException : ProgramManagerException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerSetupException"/> class.
        /// </summary>
        public ManagerSetupException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerSetupException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerSetupException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerSetupException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerSetupException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Represents errors that occur Represents errors that occur when a Manager instance is requested but the Manager has not yet been initialized.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerNotInitializedException : ProgramManagerException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerNotInitializedException"/> class.
        /// </summary>
        public ManagerNotInitializedException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerNotInitializedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerNotInitializedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerNotInitializedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerNotInitializedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
