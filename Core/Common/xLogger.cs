using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;
using System.Diagnostics;

namespace Symbiote.Core
{
    class xLogger : Logger
    {
        #region Variables

        /// <summary>
        /// String to log prior to any text block.  If no header is desired, specify a blank string.
        /// </summary>
        private static readonly string Header = "+----------- - ------------------------- ------------------------------------------------------------------- ------- -    -     -";

        /// <summary>
        /// String to log when LogSeparator() is invoked.
        /// </summary>
        private static readonly string Separator = "| ------------------------ -       --  ";

        /// <summary>
        /// String to append to the beginning of the method entry message.
        /// </summary>
        private static readonly string EnterPrefix = "| --> ";

        /// <summary>
        /// String to append to the beginning of the method exit message.
        /// </summary>
        private static readonly string ExitPrefix = "| <-- ";

        /// <summary>
        /// String to append to the beginning of checkpoint messages.
        /// </summary>
        private static readonly string CheckpointPrefix = "| # ";

        /// <summary>
        /// String to append to the beginning of exception messages.
        /// </summary>
        private static readonly string ExceptionPrefix = "| X ";

        /// <summary>
        /// String to append to the beginning of each line within a message.
        /// </summary>
        private static readonly string LinePrefix = "|   +-- ";

        /// <summary>
        /// String to append to the beginning of each line requiring variable indentation.  The dollar sign '$' will be substituted for 
        /// a string of spaces of the appropriate length.
        /// </summary>
        private static readonly string LinePrefixVariable = "|   $+-- ";

        /// <summary>
        /// String to log following any text block.  If no footer is desired, specify a blank string.
        /// </summary>
        private static readonly string Footer = "+-------------------- -------------------------------  -  -          - - -    -   -";

        /// <summary>
        /// Determines whether persisted methods are automatically pruned after the interval defined by AutoPruneAge.
        /// </summary>
        private static readonly bool AutoPruneEnabled = true;

        /// <summary>
        /// Interval after which persisted methods are automatically pruned from the PersistedMethods list, if AutoPruneEnabled is true.
        /// </summary>
        private static readonly int AutoPruneAge = 300;

        /// <summary>
        /// Lock to use to ensure thread safety with respect to the PersistedMethods list.
        /// </summary>
        private object PersistedMethodListLock = new object();

        #endregion

        #region Properties

        /// <summary>
        /// A list of Tuples containing a Guid and DateTime corresponding to methods logged with the 
        /// persistence option.
        /// </summary>
        public List<Tuple<Guid, DateTime>> PersistedMethods { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public xLogger()
        {
            PersistedMethods = new List<Tuple<Guid, DateTime>>();
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Logs the separator string
        /// </summary>
        private void LogSeparator()
        {
            Trace(Separator);
        }

        /// <summary>
        /// Logs the supplied variable list with the optionally supplied names.
        /// </summary>
        /// <param name="variables">The list of variables to log.</param>
        /// <param name="variableNames">The list of names to log along with the list of variables.</param>
        private void LogVariables(object[] variables, string[] variableNames = null)
        {
            bool useVariableNames = false;

            // determine whether to use named variables.  variableNames must not be null and the length of the array must match the variable array.
            if (variableNames != null)
            {
                if (variableNames.Length != variables.Length)
                    Trace(LinePrefix + "[Variable name/variable count mismatch; variables: " + variables.Length + ", names: " + variableNames.Length + "]");
                else
                    useVariableNames = true;
            }

            // print the variable list
            for (int v = 0; v < variables.Length; v++)
                foreach (string line in GetObjectSerialization(variables[v]))
                    Trace(LinePrefix + (useVariableNames ? variableNames[v] : "[" + v + "]") + ": " + line);
        }

        /// <summary>
        /// Logs the execution duration for the persisted method matching the supplied Guid using the supplied message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="guid">The Guid of the persisted method for which the execution duration should be calculated.</param>
        /// <param name="remove">If true, removes the supplied Guid from the list of persisted methods after logging.</param>
        private void LogExecutionDuration(string message, Guid guid, bool remove = false)
        {
            // try to fetch the matching tuple
            Tuple<Guid, DateTime> tuple = PersistedMethods.Where(m => m.Item1 == guid).FirstOrDefault();

            // make sure we found a match
            if (tuple != default(Tuple<Guid, DateTime>))
            {
                Trace(LinePrefix + message + (DateTime.UtcNow - tuple.Item2).TotalMilliseconds.ToString() + "ms");

                // if the remove option is used, remove the tuple from the list of persisted methods after logging.
                if (remove)
                {
                    lock (PersistedMethodListLock)
                    {
                        PersistedMethods.Remove(tuple);
                    }
                }
            }
            else
                Trace(LinePrefix + "[Persisted Guid not found]");
        }

        #region EnterMethod

        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <remakrs>
        /// The parameters for the calling method are retrieved via the call stack and reflection and are then compared to the list of 
        /// parameters passed into this method.  It is important for the order and number of these parameters to match for the display
        /// of parameters and values to work properly.
        /// 
        /// The Params() method should be used when invoking this method to pass the method parameters as it is shorthand for creating
        /// an object array explicitly.
        /// </remakrs>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="EnterMethod(object[], bool, string, string, int)"/>
        /// <example>
        /// // simplest example with no persistence and no parameters
        /// public void MyMethod()
        /// {
        ///     logger.EnterMethod();
        ///     
        ///     // method body
        ///     
        ///     logger.ExitMethod();
        /// }
        /// </example>
        public Guid EnterMethod([CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return EnterMethod(null, false, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <remakrs>
        /// The parameters for the calling method are retrieved via the call stack and reflection and are then compared to the list of 
        /// parameters passed into this method.  It is important for the order and number of these parameters to match for the display
        /// of parameters and values to work properly.
        /// 
        /// The Params() method should be used when invoking this method to pass the method parameters as it is shorthand for creating
        /// an object array explicitly.
        /// </remakrs>
        /// <param name="parameters">An object array containing the parameters passed into the logged method.  Use the Params() method to build this.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="EnterMethod(object[], bool, string, string, int)"/>
        /// <example>
        /// // log the method entry and parameters
        /// public void MyMethod(int one, int two)
        /// {
        ///     logger.EnterMethod(xLogger.Params(one, two));
        ///     
        ///     // method body
        ///     
        ///     logger.ExitMethod();
        /// }
        /// </example>
        public Guid EnterMethod(object[] parameters, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return EnterMethod(parameters, false, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <remakrs>
        /// The parameters for the calling method are retrieved via the call stack and reflection and are then compared to the list of 
        /// parameters passed into this method.  It is important for the order and number of these parameters to match for the display
        /// of parameters and values to work properly.
        /// 
        /// The Params() method should be used when invoking this method to pass the method parameters as it is shorthand for creating
        /// an object array explicitly.
        /// </remakrs>
        /// <param name="persist">
        /// If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.
        /// </param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="EnterMethod(object[], bool, string, string, int)"/>
        /// <example>
        /// // log the method entry with persistence and no parameters
        /// public void MyMethod()
        /// {
        ///     Guid persistedGuid = logger.EnterMethod(true);
        ///     
        ///     // method body
        ///     
        ///     logger.ExitMethod(persistedGuid);
        /// }
        /// </example>
        public Guid EnterMethod(bool persist, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return EnterMethod(null, persist, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <remakrs>
        /// The parameters for the calling method are retrieved via the call stack and reflection and are then compared to the list of 
        /// parameters passed into this method.  It is important for the order and number of these parameters to match for the display
        /// of parameters and values to work properly.
        /// 
        /// The Params() method should be used when invoking this method to pass the method parameters as it is shorthand for creating
        /// an object array explicitly.
        /// </remakrs>
        /// <param name="parameters">An object array containing the parameters passed into the logged method.  Use the Params() method to build this.</param>
        /// <param name="persist">
        /// If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.
        /// </param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="Params(object[])"/>
        /// <example>
        /// // log the method entry with persistence and parameters
        /// public void MyMethod(int one, int two)
        /// {
        ///     Guid persistedGuid = logger.EnterMethod(xLogger.Params(one, two), true);
        ///     
        ///     // method body
        ///     
        ///     logger.ExitMethod(persistedGuid);
        /// }
        /// </example>
        public Guid EnterMethod(object[] parameters, bool persist, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            // check to see if tracing is enabled.  if not, bail out immediately to avoild wasting processor time.
            if (!IsTraceEnabled) return default(Guid);

            Guid methodGuid;

            // if the persist option is used, generate a new Guid for the method call and add it to the list of persisted methods along with the current datetime.
            if (persist)
            {
                methodGuid = Guid.NewGuid();

                // lock the PersistedMethods list to ensure thread safety.
                lock (PersistedMethodListLock)
                {
                    PersistedMethods.Add(new Tuple<Guid, DateTime>(methodGuid, DateTime.UtcNow));
                }
            }
            else
                methodGuid = default(Guid);

            // print the header
            if (Header.Length > 0) Trace(Header);
            Trace(EnterPrefix + "Entering method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ":line " + lineNumber + ")" + (persist ? ", persisting with Guid: " + methodGuid : ""));

            // compose and print the parameter list, but not if the list is null
            if (parameters != null)
            {
                // check to see if the number of supplied parameters matches the method signature parameter list
                // if it doesn't match we really don't want to try to make assumptions about the positioning of what was supplied
                // vs the method signature ordering, so just bail out.
                try
                {
                    ParameterInfo[] parameterInfo = GetCallingStackFrame().GetMethod().GetParameters();

                    if (parameterInfo.Length != parameters.Length)
                        Trace(LinePrefix + "[Parameter count mismatch]");
                    else
                    {
                        // the counts match, meaning we can infer that a complete parameter list has been supplied.
                        // iterate over the supplied parameter array
                        for (int p = 0; p < parameters.Length; p++)
                        {
                            // check to ensure the type of the supplied parameter in position p is the same
                            // as the type in the method signature parameter list
                            if (!parameterInfo[p].ParameterType.IsAssignableFrom(parameters[p].GetType()))
                                Trace(LinePrefix + "[Parameter type mismatch; expected: " + parameterInfo[p].ParameterType.Name + ", actual: " + parameters[p].GetType().Name + "]");
                            else
                            {
                                foreach (string line in GetObjectSerialization(parameters[p]))
                                    Trace(LinePrefix + parameterInfo[p].Name + ": " + line);
                            }
                        }
                    }
                }
                // swallow any errors we might encounter; this isn't important enough to stop the application.
                catch (Exception ex)
                {
                    Trace(LinePrefix + "[Error: " + ex.Message + "]");
                }
            }

            // print the footer.
            if (Footer.Length > 0) Trace(Footer);

            return methodGuid;
        }

        #endregion

        #region ExitMethod

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="ExitMethod(object, Guid, string, string, int)"/>
        /// <example>
        /// // simplest example with no persistence and no return value
        /// public void MyMethod()
        /// {
        ///     logger.EnterMethod();
        ///     
        ///     // method body
        ///     
        ///     logger.ExitMethod();
        /// }
        /// </example>
        public void ExitMethod([CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            ExitMethod(new UnspecifiedReturnValue(), default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="returnValue">The return value of the method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="ExitMethod(object, Guid, string, string, int)"/>
        /// <example>
        /// // log the method exit with no persistence and with a return value
        /// public void MyMethod()
        /// {
        ///     logger.EnterMethod();
        ///     
        ///     // method body
        ///     
        ///     bool returnValue = false;
        ///     logger.ExitMethod(returnValue);
        ///     return returnValue;
        /// }
        /// </example>
        public void ExitMethod(object returnValue, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            ExitMethod(returnValue, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="guid">The Guid assigned by the corresponding Enter() method invocation.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="ExitMethod(object, Guid, string, string, int)"/>
        /// <example>
        /// // log the method exit with persistence and no return value
        /// public void MyMethod()
        /// {
        ///     Guid persistedGuid = logger.EnterMethod();
        ///     
        ///     // method body
        ///     
        ///     logger.ExitMethod(persistedGuid);
        /// }
        /// </example>
        public void ExitMethod(Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            ExitMethod(new UnspecifiedReturnValue(), guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="returnValue">The return value of the method.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <example>
        /// // log the method exit with persistence and a return value
        /// public bool ExamplePersistedMethod(int one, int two)
        /// {
        ///     Guid persistedGuid = logger.EnterMethod(xLogger.Params(one, two), true);
        ///     
        ///     // method body
        ///     
        ///     returnValue = true;
        ///     logger.ExitMethod(returnValue, persistedGuid);
        ///     return returnValue;
        /// }
        /// </example>
        public void ExitMethod(object returnValue, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            // check to see if tracing is enabled.  if not, bail out immediately to avoild wasting processor time.
            if (!IsTraceEnabled) return;

            if (Header.Length > 0) Trace(Header);
            Trace(ExitPrefix + "Exiting method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ":line " + lineNumber + ")" + (guid != default(Guid) ? ", Guid: " + guid : ""));

            // if returnValue is null, log a simple message and move on.  we do this to differentiate a null returnValue 
            // from a method invocation that didn't supply anything for returnValue
            if (returnValue == null)
                Trace(LinePrefix + "return: null");
            // if returnValue isn't null compare the provided returnValue Type to our internal type UnspecifiedReturnValue.
            // this should only evaluate to true if an instance of UnspecifiedReturnValue is passed in from an overload.
            else if (returnValue.GetType() != typeof(UnspecifiedReturnValue))
            {
                foreach (string line in GetObjectSerialization(returnValue))
                    Trace(LinePrefix + "return: " + line);
            }

            // if a Guid was provided, locate it in the PersistedMethods list, log the duration
            // and remove it from the list
            if (guid != default(Guid)) LogExecutionDuration("Method execution duration: ", guid, true);

            // log the footer.
            if (Footer.Length > 0) Trace(Footer);

            // prune the PersistedMethods list if automatic pruning is enabled.
            if (AutoPruneEnabled) PrunePersistedMethods(AutoPruneAge);
        }

        #endregion

        #region Checkpoint

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // log a basic checkpoint
        /// logger.Checkpoint();
        /// </example>
        public void Checkpoint([CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(null, null, null, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="name">The checkpoint name.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // log a named checkpoint
        /// logger.Checkpoint("My named checkpoint");
        /// </example>
        public void Checkpoint(string name, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(name, null, null, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // log a method entry using persistence
        /// Guid guid = logger.EnterMethod(true);
        /// 
        /// // log a persistent checkpoint
        /// logger.Checkpoint(guid);
        /// </example>
        public void Checkpoint(Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(null, null, null, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="name">The checkpoint name.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // log a method entry using persistence
        /// Guid guid = logger.EnterMethod(true);
        /// 
        /// // log a named, persistent checkpoint
        /// logger.Checkpoint("My named checkpoint", guid);
        /// </example>
        public void Checkpoint(string name, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(name, null, null, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // declare some variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// // log a checkpoint with unnamed variables
        /// logger.Checkpoint(ExtendedLogger.Vars(one, two));
        /// </example>
        public void Checkpoint(object[] variables, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(null, variables, null, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="name">The checkpoint name.</param>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // declare some variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// // log a named checkpoint with unnamed variables
        /// logger.Checkpoint("My named checkpoint", ExtendedLogger.Vars(one, two));
        /// </example>
        public void Checkpoint(string name, object[] variables, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(name, variables, null, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // log a method entry using persistence
        /// Guid guid = logger.EnterMethod(true);
        /// 
        /// // declare some variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// // log a persistent checkpoint with unnamed variables
        /// logger.Checkpoint(ExtendedLogger.Vars(one, two), guid);
        /// </example>
        public void Checkpoint(object[] variables, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(null, variables, null, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="name">The checkpoint name.</param>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // log a method entry using persistence
        /// Guid guid = logger.EnterMethod(true);
        /// 
        /// // declare some variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// // log a named, persistent checkpoint with unnamed variables
        /// logger.Checkpoint("My named checkpoint", ExtendedLogger.Vars(one, two), guid);
        /// </example>
        public void Checkpoint(string name, object[] variables, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(name, variables, null, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="variableNames">A string array of variable names to be logged along with the supplied variables.  The number and order should match the variable array.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // declare some variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// // log a checkpoint with named variables
        /// logger.Checkpoint(ExtendedLogger.Vars(one, two), ExtendedLogger.Names("one", "two"));
        /// </example>
        public void Checkpoint(object[] variables, string[] variableNames, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(null, variables, variableNames, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="name">The checkpoint name.</param>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="variableNames">A string array of variable names to be logged along with the supplied variables.  The number and order should match the variable array.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // declare some variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// // log a named checkpoint with named variables
        /// logger.Checkpoint("My named checkpoint", ExtendedLogger.Vars(one, two), ExtendedLogger.Names("one", "two"));
        /// </example>
        public void Checkpoint(string name, object[] variables, string[] variableNames, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(name, variables, variableNames, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="variableNames">A string array of variable names to be logged along with the supplied variables.  The number and order should match the variable array.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <example>
        /// // log a method entry using persistence
        /// Guid guid = logger.EnterMethod(true);
        /// 
        /// // declare some variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// // log a persistent checkpoint with named variables
        /// logger.Checkpoint(ExtendedLogger.Vars(one, two), ExtendedLogger.Names("one", "two"), guid);
        /// </example>
        public void Checkpoint(object[] variables, string[] variableNames, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(null, variables, variableNames, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="name">The checkpoint name.</param>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="variableNames">A string array of variable names to be logged along with the supplied variables.  The number and order should match the variable array.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <example>
        /// // log a method entry using persistence
        /// Guid guid = logger.EnterMethod(true);
        /// 
        /// // declare some variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// // log a named, persistent checkpoint with named variables
        /// logger.Checkpoint("My named checkpoint", ExtendedLogger.Vars(one, two), ExtendedLogger.Names("one", "two"), guid);
        /// </example>
        public void Checkpoint(string name, object[] variables, string[] variableNames, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            // if tracing isn't enabled, bail immediately
            if (!IsTraceEnabled) return;

            // print the checkpoint header
            if (Header.Length > 0) Trace(Header);
            Trace(CheckpointPrefix + "Checkpoint " + (name != null ? "'" + name + "'" : "") + " reached in method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ":line " + lineNumber + ")" + (guid != default(Guid) ? ", Guid: " + guid : ""));

            // ensure variables have been supplied before continuing
            if (variables != null) LogVariables(variables, variableNames);
            
            // if persistence is enabled, print the execution duration 
            if (guid != default(Guid)) LogExecutionDuration("Current execution duration: ", guid);

            if (Footer.Length > 0) Trace(Footer);
        }

        #endregion

        #region Exception

        public void Exception([CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(new Exception(), null, null, default(Guid), caller, filePath, lineNumber);
        }

        public void Exception(Exception exception, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(exception, null, null, default(Guid), caller, filePath, lineNumber);
        }

        public void Exception(Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(new Exception(), null, null, guid, caller, filePath, lineNumber);
        }

        public void Exception(object[] variables, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(new Exception(), variables, null, default(Guid), caller, filePath, lineNumber);
        }

        public void Exception(object[] variables, string[] variableNames, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(new Exception(), variables, variableNames, default(Guid), caller, filePath, lineNumber);
        }

        public void Exception(Exception exception, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(exception, null, null, guid, caller, filePath, lineNumber);
        }

        public void Exception(Exception exception, object[] variables, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(exception, variables, null, default(Guid), caller, filePath, lineNumber);
        }

        public void Exception(Exception exception, object[] variables, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(exception, variables, null, guid, caller, filePath, lineNumber);
        }

        public void Exception(Exception exception, object[] variables, string[] variableNames, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(exception, variables, variableNames, default(Guid), caller, filePath, lineNumber);
        }
        
        public void Exception(object[] variables, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(new Exception(), variables, null, guid, caller, filePath, lineNumber);
        }
        
        public void Exception(object[] variables, string[] variableNames, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exception(new Exception(), variables, variableNames, guid, caller, filePath, lineNumber);
        }

        public void Exception(Exception exception, object[] variables, string[] variableNames, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            // if tracing is not enabled on the current logger, bail out immediately to save processor time
            if (!IsTraceEnabled) return;

            // log the header
            if (Header.Length > 0) Trace(Header);
            Trace(ExceptionPrefix + "Exception '" + exception.GetType().Name + "' caught in method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ":line " + lineNumber + ")" + (guid != default(Guid) ? ", Guid: " + guid : ""));
            LogSeparator();


            // log the stack trace followed by a separator
            int indent = 0;
            foreach (StackFrame frame in GetInvertedStackExcerpt())
            {
                MethodInfo methodInfo = (MethodInfo)frame.GetMethod();
                string spaces = new string(' ', indent * 3);
                Trace(LinePrefixVariable.Replace("$", spaces) + GetMethodSignature(methodInfo));
                indent++;
            }
            LogSeparator();

            // log the exception followed by a separator
            LogVariables(Params(exception), Names("ex"));
            LogSeparator();

            // if a variable list was supplied, log it 
            if (variables != null) LogVariables(variables, variableNames);

            // if persistence is used, log the current execution duration
            if (guid != default(Guid)) LogExecutionDuration("Current execution duration: ", guid);

            // log the footer
            if (Footer.Length > 0) Trace(Footer);
        }

        #endregion

        /// <summary>
        /// Prunes the PersistedMethods list of any tuples older than the specified age in seconds.
        /// </summary>
        /// <remarks>
        /// Should be called on a regular interval (minutes or perhaps hours) to keep things tidy.
        /// 
        /// If doing so, be mindful of long running methods (Main(), for instance) and be aware that persistence will be deleted if used.
        /// </remarks>
        /// <param name="age">The age in seconds after which persisted methods will be pruned.</param>
        /// <example>
        /// // prune persisted methods older than 5 minutes (300 seconds)
        /// MethodLogger.PrunePersistedMethods(300);
        /// </example>
        public void PrunePersistedMethods(int age)
        {
            // retrieve a list of aged tuples
            List<Tuple<Guid, DateTime>> pruneList = PersistedMethods.Where(m => (DateTime.UtcNow - m.Item2).Seconds > age).ToList();

            if (pruneList.Count > 0)
            {
                // remove everything in the list
                foreach (Tuple<Guid, DateTime> tuple in pruneList)
                    PersistedMethods.Remove(tuple);

                LogManager.GetCurrentClassLogger().Trace("Pruned {0} methods with age in excess of {1} seconds from the PersistedMethods list.", pruneList.Count, age);
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Returns the object array specified in the input parameter(s) for the method.  Accepts a dynamic number of parameters
        /// of any type which are implictly added to an object array.
        /// </summary>
        /// <remarks>
        /// This is a shorthand method that eliminates the need to explicitly define an object array when using the Enter() method.
        /// This is necessary because the current C# specification doesn't allow for the params keyword and optional implicit parameters in the same method
        /// signature due to ambiguity.
        /// 
        /// Note that if any of the parameters is an array it must be cast to type object when being passed into the method.  This is due to the fact that
        /// arrays of any type are also an object and are presented ambiguously to this method because of the params keyword and type of object[].
        /// </remarks>
        /// <param name="parameters">A dynamic object array of method parameters.</param>
        /// <returns>The provided object array.</returns>
        /// <seealso cref="EnterMethod(object[], bool, string, string, int)"/>
        /// <example>
        /// // Enter() invocation with one parameter
        /// logger.EnterMethod(logger, xLogger.Params(parameterOne));
        /// 
        /// // Enter() invocation with two parameters
        /// logger.EnterMethod(logger, xLogger.Params(parameterOne, parameterTwo));
        /// 
        /// // Enter() invocation with any number of parameters
        /// logger.EnterMethod(logger, xLogger.Params(parameterOne, ..., parameterN));
        /// 
        /// // Enter() invocation with a parameter list containing an array
        /// logger.EnterMethod(logger, xLogger.Params(parameterOne, parameterTwo, (object)arrayParameterThree));
        /// </example>
        public static object[] Params(params object[] parameters)
        {
            return parameters;
        }

        /// <summary>
        /// Returns the object array specified in the variable list for a Checkpoint() method call.  Effectively an overload for Params(),
        /// provided for naming consistency with usage.
        /// </summary>
        /// <param name="variables">A dynamic object array of variables.</param>
        /// <returns>The provided object array.</returns>
        /// <seealso cref="Checkpoint(string, object[], string[], Guid, string, string, int)"/>
        /// <seealso cref="Exception(System.Exception, object[], string[], Guid, string, string, int)"/>
        /// <seealso cref="Params(object[])"/>
        /// <example>
        /// // Checkpoint() invocation with three variables
        /// int one = 1;
        /// int two = 2;
        /// string varThree = "three";
        /// 
        /// MethodLogger.Checkpoint(MethodLogger.Vars(one, two, three), MethodLogger.Names("one", "two", "varThree"));
        /// </example>
        public static object[] Vars(params object[] variables)
        {
            return Params(variables);
        }

        /// <summary>
        /// Returns the string array specified in the variable name list for a Checkpoint() or Exception() method call.
        /// </summary>
        /// <remarks>
        /// When used in conjunction with Checkpoint() or Exception(), ensure the order and number of the supplied names matches that of the 
        /// related object array.
        /// </remarks>
        /// <param name="names">A dynamic string array of variable names.</param>
        /// <returns>The provided string array.</returns>
        /// <seealso cref="Checkpoint(object[], string[], Guid, string, string, int)"/>
        /// <seealso cref="Params(object[])"/>
        /// <example>
        /// // Checkpoint() invocation with three variables
        /// int one = 1;
        /// int two = 2;
        /// string varThree = "three";
        /// 
        /// MethodLogger.Checkpoint(MethodLogger.Vars(one, two, three), MethodLogger.Names("one", "two", "varThree"));
        /// </example>
        public static string[] Names(params string[] names)
        {
            return (string[])Params(names);
        }

        /// <summary>
        /// Returns an inverted excerpt of the current stack trace, omitting methods above Main() and those originating within this class.
        /// </summary>
        /// <returns>A list of type StackFrame containing an inverted excerpt of the current stack trace.</returns>
        private static List<StackFrame> GetInvertedStackExcerpt()
        {
            StackTrace stackTrace = new StackTrace();
            List<StackFrame> retVal = new List<StackFrame>();

            //// get the relevant parts of the current stack trace, beginning with Main() and ending with the method
            //// that invoked this method.

            // iterate over the stack in reverse order beginning with the calling frame and adding the frames to the list as we go,
            // but only if the namespace of the class containing the frame's method is the same as the current namespace.
            // we don't want to add system/framework methods to the stack; this effectively will start the stack with Main().
            for (int f = stackTrace.FrameCount - 1; f >= 1; f--)
            {
                StackFrame frame = stackTrace.GetFrame(f);

                // if the namespace of the reflected type matches the namespace of this class, the frame contains relevant data.
                // if not, the frame contains something above Main() which we don't care about.
                if (frame.GetMethod().ReflectedType.Namespace == MethodBase.GetCurrentMethod().DeclaringType.Namespace)
                {
                    // if the full name of the reflected type isn't the same as this class, add it to the list.
                    // if it is the same, the frame contains a method that originated within this class and we don't care.
                    if (frame.GetMethod().ReflectedType.FullName != MethodBase.GetCurrentMethod().DeclaringType.FullName)
                        retVal.Add(frame);
                }

            }


            return retVal;
        }

        /// <summary>
        /// Searches the execution stack and returns the topmost frame not originating from this class, indicating the calling frame.
        /// </summary>
        /// <returns>The StackFrame containing the calling code.</returns>
        private static StackFrame GetCallingStackFrame()
        {
            // retrieve the trace of the current call stack
            StackTrace stackTrace = new StackTrace();

            // determine the proper stack frame.  
            // do this by iterating over the frames, starting from the one prior to the current frame, attempting to find
            // the first frame that doesn't originate from the current class (GetFrame(0)).
            // this is necessary so that we can be sure to grab the intended method if the Enter() overloads were used to get to this point.
            int relevantFrame = 1;
            for (int f = relevantFrame; f < stackTrace.FrameCount; f++)
            {
                if (stackTrace.GetFrame(f).GetMethod().ReflectedType.Name != stackTrace.GetFrame(0).GetMethod().ReflectedType.Name)
                {
                    relevantFrame = f;
                    break;
                }
            }

            return stackTrace.GetFrame(relevantFrame);
        }

        /// <summary>
        /// Builds and returns the calling method signature, including method name, parameter types and names.
        /// </summary>
        /// <param name="methodInfo">The MethodInfo for which to return the signature.</param>
        /// <returns>The method signature, including method name, parameter types and names, of the calling method.</returns>
        private static string GetMethodSignature(MethodInfo methodInfo = null)
        {
            // if no MethodInfo is provided, return the signature of the calling method.
            if (methodInfo == null)
                methodInfo = (MethodInfo)GetCallingStackFrame().GetMethod();

            // build a signature string to display by iterating over the method parameters and retrieving names and types
            string methodSignature = GetColloquialTypeName(methodInfo.ReturnType) + " " + methodInfo.Name + "(";
            List<string> parameters = new List<string>();

            foreach (ParameterInfo pi in methodInfo.GetParameters())
                parameters.Add(GetColloquialTypeName(pi.ParameterType) + " " + pi.Name);

            // create a string from the type array while converting the type to the readable type
            methodSignature += String.Join(", ", parameters);

            return methodSignature + ")";
        }

        /// <summary>
        /// Returns a "pretty" string representation of the provided Type.  Specifically corrects the naming of generic Types
        /// and appends the type parameters for the type to the name as it appears in the code editor.
        /// </summary>
        /// <param name="type">The type for which the string should be created.</param>
        /// <returns>A "pretty" string representation of the provided Type.</returns>
        private static string GetColloquialTypeName(Type type)
        {
            return (!type.IsGenericType ? type.Name : type.Name.Split('`')[0] + "<" + String.Join(", ", type.GetGenericArguments().Select(a => GetColloquialTypeName(a))) + ">");
        }

        /// <summary>
        /// Returns a List of type string containing each line of the indented serialization of the supplied object.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A List of type string containing each line of the indented serialization of the supplied object.</returns>
        private static List<string> GetObjectSerialization(object obj)
        {
            List<string> retVal = new List<string>();

            // try to serialize the provided object.  swallow any errors.
            try
            {
                // serialize the object using the indented format and
                // convert enumerated values to their respective strings
                string json = JsonConvert.SerializeObject(
                    obj,
                    Formatting.Indented,
                    new JsonSerializerSettings() { Converters = new List<JsonConverter> { new StringEnumConverter() } }
                );

                // split by \n after replacing \r\n with just \n.  if we don't do this extra lines are added to logs in some editors.
                retVal = json.Replace("\r\n", "\n").Split('\n').ToList();
            }
            catch (Exception ex)
            {
                retVal.Add("[Error serializing object: " + ex.Message + "]");
            }

            return retVal;
        }

        #endregion

        #region Nested Classes

        /// <summary>
        /// Internal class used to differentiate a null return value from an unspecified return value.
        /// </summary>
        private class UnspecifiedReturnValue { }

        #endregion
    }
}
