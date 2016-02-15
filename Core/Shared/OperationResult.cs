using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    /// <summary>
    /// Defines the return result of an operation
    /// </summary>
    public enum OperationResultCode
    {
        /// <summary>
        /// The default return type
        /// </summary>
        Unknown,
        /// <summary>
        /// The operation succeeded
        /// </summary>
        Success,
        /// <summary>
        /// The operation encountered recoverable issues but ultimately succeeded
        /// </summary>
        Warning,
        /// <summary>
        /// The operation encountered unrecoverable errors and did not succeed
        /// </summary>
        Failure
    }

    public enum OperationResultMessageType
    {
        Info,
        Warning,
        Error
    }

    public class OperationResultMessage
    {
        public OperationResultMessageType Type { get; set; }
        public string Message { get; set; }

        public OperationResultMessage()
        {
            Type = OperationResultMessageType.Info;
            Message = "";
        }

        public OperationResultMessage(OperationResultMessageType type = OperationResultMessageType.Info, string message = "")
        {
            Type = type;
            Message = message;
        }

        public override string ToString()
        {
            return "[" + Type.ToString().ToUpper() + "] " + Message;
        }
    }

    public class OperationResult
    {
        public OperationResultCode ResultCode { get; set; }
        public List<OperationResultMessage> Messages { get; set; }

        public OperationResult()
        {
            ResultCode = OperationResultCode.Success;
            Messages = new List<OperationResultMessage>();
        }

        public virtual OperationResult AddInfo(string message)
        {
            Messages.Add(new OperationResultMessage(OperationResultMessageType.Info, message));
            return this;
        }

        public virtual OperationResult AddWarning(string message)
        {
            Messages.Add(new OperationResultMessage(OperationResultMessageType.Warning, message));
            ResultCode = OperationResultCode.Warning;
            return this;
        }

        public virtual OperationResult AddError(string message)
        {
            Messages.Add(new OperationResultMessage(OperationResultMessageType.Error, message));
            ResultCode = OperationResultCode.Failure;
            return this;
        }

        public void LogAllMessagesAsInfo(NLog.ILogger logger, string header = "", string footer = "")
        {
            logger.Info(header);
            foreach (OperationResultMessage message in Messages) logger.Info("\t" + message);
            logger.Info(footer);
        }

        public void LogAllMessagesAsWarn(NLog.ILogger logger, string header = "", string footer = "")
        {
            logger.Warn(header);
            foreach (OperationResultMessage message in Messages) logger.Warn("\t" + message);
            logger.Warn(footer);
        }

        public void LogAllMessagesAsError(NLog.ILogger logger, string header = "", string footer = "")
        {
            logger.Error(header);
            foreach (OperationResultMessage message in Messages) logger.Error("\t" + message);
            logger.Error(footer);
        }

        public void LogAllMessagesAsDebug(NLog.ILogger logger, string header = "", string footer = "")
        {
            logger.Debug(header);
            foreach (OperationResultMessage message in Messages) logger.Debug("\t" + message);
            logger.Debug(footer);
        }

        public void LogAllMessagesAsTrace(NLog.ILogger logger, string header = "", string footer = "")
        {
            logger.Trace(header);
            foreach (OperationResultMessage message in Messages) logger.Trace("\t" + message);
            logger.Trace(footer);
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }

        public OperationResult() : base()
        {
            Result = default(T);
        }

        public virtual OperationResult<T> AddInfo(string message)
        {
            base.AddInfo(message);
            return this;
        }

        public virtual OperationResult<T> AddWarning(string message)
        {
            base.AddWarning(message);
            return this;
        }

        public virtual OperationResult<T> AddError(string message)
        {
            base.AddError(message);
            return this;
        }
    }
}
