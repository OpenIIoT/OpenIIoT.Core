using System;

namespace Symbiote.Core
{
    /// <summary>
    /// Represents errors that occur at the program level.
    /// </summary>
    class ProgramException : Exception
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
    class ProgramArgumentException : ProgramException
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
    class ProgramInitializationException : ProgramException
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
    class ProgramStartException : ProgramException
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
    class ProgramStopException : ProgramException
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
    class ProgramStartupRoutineException : ProgramException
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
    class ProgramShutdownRoutineException : ProgramException
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
}
