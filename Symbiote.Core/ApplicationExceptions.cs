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
      █  Exceptions for the Program and ApplicationManager classes.
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
    ///     Represents errors that occur at the program level.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ApplicationException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationException"/> class.
        /// </summary>
        public ApplicationException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApplicationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while parsing and applying command line arguments.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ApplicationArgumentException : ApplicationException
    {
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
        ///     Initializes a new instance of the <see cref="ApplicationArgumentException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApplicationArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while initializing the Application.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ApplicationInitializationException : ApplicationException
    {
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
        ///     Initializes a new instance of the <see cref="ApplicationInitializationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApplicationInitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while starting the Application.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ApplicationStartException : ApplicationException
    {
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
        ///     Initializes a new instance of the <see cref="ApplicationStartException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApplicationStartException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while stopping the Application.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ApplicationStopException : ApplicationException
    {
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
        ///     Initializes a new instance of the <see cref="ApplicationStopException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApplicationStopException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while performing the Application startup routine.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ApplicationStartupRoutineException : ApplicationException
    {
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
        ///     Initializes a new instance of the <see cref="ApplicationStartupRoutineException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApplicationStartupRoutineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while performing the Application shutdown routine.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ApplicationShutdownRoutineException : ApplicationException
    {
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
        ///     Initializes a new instance of the <see cref="ApplicationShutdownRoutineException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApplicationShutdownRoutineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur within the ApplicationManager class.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ApplicationManagerException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationManagerException"/> class.
        /// </summary>
        public ApplicationManagerException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationManagerException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ApplicationManagerException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationManagerException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ApplicationManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur when the type list argument for the ApplicationManager constructor is malformed.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ManagerTypeListException : ApplicationManagerException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerTypeListException"/> class.
        /// </summary>
        public ManagerTypeListException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerTypeListException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerTypeListException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerTypeListException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerTypeListException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur when the instantiation of a Manager returns an abnormal result.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ManagerInstantiationException : ApplicationManagerException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerInstantiationException"/> class.
        /// </summary>
        public ManagerInstantiationException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerInstantiationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerInstantiationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerInstantiationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerInstantiationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur when the setup of a Manager returns an abnormal result.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ManagerSetupException : ApplicationManagerException
    {
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
        ///     Initializes a new instance of the <see cref="ManagerSetupException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerSetupException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur during the registration of a Manager instance.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ManagerRegistrationException : ApplicationManagerException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerRegistrationException"/> class.
        /// </summary>
        public ManagerRegistrationException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerRegistrationException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerRegistrationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerRegistrationException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerRegistrationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while fetching Manager dependencies.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ManagerDependencyException : ApplicationManagerException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerDependencyException"/> class.
        /// </summary>
        public ManagerDependencyException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerDependencyException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerDependencyException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerDependencyException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerDependencyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur when a Manager instance is requested but the Manager has not yet been initialized.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [Serializable]
    public class ManagerNotInitializedException : ApplicationManagerException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerNotInitializedException"/> class.
        /// </summary>
        public ManagerNotInitializedException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerNotInitializedException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ManagerNotInitializedException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerNotInitializedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ManagerNotInitializedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
