using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using NLog;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Symbiote.Core
{
    /// <summary>
    /// The MethodLogger is a generic static class used to provide methods throughout the application with a means
    /// to log the entry and exit of the method body along with the name and value of all method parameters.
    /// </summary>
    /// <remarks>
    /// Modify the readonly string variables below to customize the appearance of the log messages.
    /// 
    /// Modify the values of the AutoPrune constants to enable or disable automatic pruning of persisted methods, and to change the age.
    /// Alternatively, configure the settings programmatically using the Configure() method.  Refer to the documentation for examples.
    /// to the desired settings.
    /// </remarks>
    class MethodLogger
    {
        #region Variables

        /// <summary>
        /// String to log prior to any text block.  If no header is desired, specify a blank string.
        /// </summary>
        private static readonly string Header = "+----------- - ------------------------- ------------------------------------------------------------------- ------- -    -     -";

        /// <summary>
        /// String to append to the beginning of the method entry message.
        /// </summary>
        private static readonly string EnterPrefix = "| --> ";

        /// <summary>
        /// String to append to the beginning of the method exit message.
        /// </summary>
        private static readonly string ExitPrefix = "| <-- ";

        private static readonly string CheckpointPrefix = "| # ";

        private static readonly string ExceptionPrefix = "| X ";

        /// <summary>
        /// String to append to the beginning of each method parameter message.
        /// </summary>
        private static readonly string LinePrefix = "|   +-- ";

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
        private static object PersistedMethodListLock = new object();

        #endregion

        #region Properties

        /// <summary>
        /// A list of Tuples containing a Guid and DateTime corresponding to methods logged with the 
        /// persistence option.
        /// </summary>
        public static List<Tuple<Guid, DateTime>> PersistedMethods { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.  
        /// </summary>
        /// <remarks>
        /// Initializes the PersistedMethods list and sets AutoPruneEnabled and AutoPruneAge to the constants specified above.
        /// This constructor is executed the first time the class is referenced.  To specify new values for AutoPruneEnabled and AutoPruneAge,
        /// invoke the Configure() method.
        /// </remarks>
        static MethodLogger()
        {
            PersistedMethods = new List<Tuple<Guid, DateTime>>();
        }

        #endregion

        #region Static Methods

        #region Enter

        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.  If not supplied, a logger for the calling class is created implicitly.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // simplest example with implicit logger, no persistence and no parameters
        /// public void MyMethod()
        /// {
        ///     MethodLogger.Enter();
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit();
        /// }
        /// 
        /// // simple example with no persistence, no parameters and an explicit logger
        /// public void MyMethod()
        /// {
        ///     MethodLogger.Enter(logger);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger);
        /// }
        /// </example>
        public static Guid Enter(Logger logger = null, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            if (logger == null)
                logger = GetLogger();

            return Enter(logger, null, false, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <param name="parameters">An object array containing the parameters passed into the logged method.  Use the Params() method to build this.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // implicitly defined logger and a list of parameters
        /// public void MyMethod(int one, int two)
        /// {
        ///     MethodLogger.Enter(MethodLogger.Params(one, two));
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit();
        /// }
        /// </example>
        public static Guid Enter(object[] parameters, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return Enter(GetLogger(), parameters, false, caller, filePath, lineNumber);
        }
        
        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="parameters">An object array containing the parameters passed into the logged method.  Use the Params() method to build this.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // non-persistent example with parameters and explicitly defined logger
        /// public void MyMethod(int one, int two)
        /// {
        ///     MethodLogger.Enter(logger, MethodLogger.Params(one, two));
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger);
        /// }
        /// </example>
        public static Guid Enter(Logger logger, object[] parameters, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return Enter(logger, parameters, false, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <param name="persist">
        /// If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.
        /// </param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // persistent example with no parameters and an implicit logger
        /// public void MyMethod()
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(true);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(persistedGuid);
        /// }
        /// </example>
        public static Guid Enter(bool persist, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return Enter(GetLogger(), null, persist, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Overload for Enter() using an explicit logger, no parameters and with persistence.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="persist">
        /// If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.
        /// </param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // persistent example with no parameters and explicitly defined logger
        /// public void MyMethod()
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(logger, true);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger, persistedGuid);
        /// }
        /// </example>
        public static Guid Enter(Logger logger, bool persist, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return Enter(logger, null, persist, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the entrance of execution flow into a method (depending on the placement of this method call)
        /// and attempts to log the parameters passed in.  
        /// </summary>
        /// <param name="parameters">An object array containing the parameters passed into the logged method.  Use the Params() method to build this.</param>
        /// <param name="persist">
        /// If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.
        /// </param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>The Guid for the persisted method.</returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // persistent example with parameters and an implicitly defined logger
        /// public void MyMethod(int one, int two)
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(MethodLogger.Params(one, two), true);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(persistedGuid);
        /// }
        /// </example>
        public static Guid Enter(object[] parameters, bool persist, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return Enter(GetLogger(), parameters, persist, caller, filePath, lineNumber);
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
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
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
        /// // example usage with persistence, parameter list and explicit logger
        /// public void MyMethod(int one, int two)
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(logger, MethodLogger.Params(one, two), true);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger, persistedGuid);
        /// }
        /// </example>
        public static Guid Enter(Logger logger, object[] parameters, bool persist, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            // check to see if tracing is enabled.  if not, bail out immediately to avoild wasting processor time.
            if (!logger.IsTraceEnabled) return default(Guid);

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
            if (Header.Length > 0) logger.Trace(Header);
            logger.Trace(EnterPrefix + "Entering method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ":line " + lineNumber + ")" + (persist ? ", persisting with Guid: " + methodGuid : ""));

            // compose and print the parameter list, but not if the list is null
            if (parameters != null)
            {
                // check to see if the number of supplied parameters matches the method signature parameter list
                // if it doesn't match we really don't want to try to make assumptions about the positioning of what was supplied
                // vs the method signature ordering, so just bail out.
                try
                {
                    ParameterInfo[] parameterInfo = GetParameterInfo();

                    if (parameterInfo.Length != parameters.Length)
                        logger.Trace(LinePrefix + "[Parameter count mismatch]");
                    else
                    {
                        // the counts match, meaning we can infer that a complete parameter list has been supplied.
                        // iterate over the supplied parameter array
                        for (int p = 0; p < parameters.Length; p++)
                        {
                            // check to ensure the type of the supplied parameter in position p is the same
                            // as the type in the method signature parameter list
                            if (!parameterInfo[p].ParameterType.IsAssignableFrom(parameters[p].GetType()))
                                logger.Trace(LinePrefix + "[Parameter type mismatch; expected: " + parameterInfo[p].ParameterType.Name + ", actual: " + parameters[p].GetType().Name + "]");
                            else
                            {
                                foreach (string line in GetObjectSerialization(parameters[p]))
                                    logger.Trace(LinePrefix + parameterInfo[p].Name + ": " + line);
                            }
                        }
                    }
                }
                // swallow any errors we might encounter; this isn't important enough to stop the application.
                catch (Exception ex)
                {
                    logger.Trace(LinePrefix + "[Error: " + ex.Message + "]");
                }
            }

            // print the footer.
            if (Footer.Length > 0) logger.Trace(Footer);

            return methodGuid;
        }

        #endregion

        #region Exit

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.  If not supplied, a logger for the calling class is created implicitly.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Exit(Logger, object, Guid, string, string, int)"/>
        /// <example>
        /// // simplest example with implicit logger, no persistence and no parameters
        /// public void MyMethod()
        /// {
        ///     MethodLogger.Enter();
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit();
        /// }
        /// 
        /// // simple example with no persistence, no parameters and an explicit logger
        /// public void MyMethod()
        /// {
        ///     MethodLogger.Enter(logger);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger);
        /// }
        /// </example>
        public static void Exit(Logger logger = null, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            if (logger == null)
                logger = GetLogger();

            Exit(logger, new UnspecifiedReturnValue(), default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="returnValue">The return value of the method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Exit(Logger, object, Guid, string, string, int)"/>
        /// <example>
        /// // example with no persistence, a return value and an implicit logger
        /// public void MyMethod()
        /// {
        ///     MethodLogger.Enter();
        ///     
        ///     // method body
        ///     
        ///     bool returnValue = false;
        ///     MethodLogger.Exit(returnValue);
        ///     return returnValue;
        /// }
        /// </example>
        public static void Exit(object returnValue, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exit(GetLogger(), returnValue, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the message.</param>
        /// <param name="returnValue">The return value of the method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Exit(Logger, object, Guid, string, string, int)"/>
        /// <example>
        /// // non-persistent example with a return value
        /// public bool MyMethod()
        /// {
        ///     MethodLogger.Enter(logger);
        ///     
        ///     // method body
        ///     
        ///     bool returnValue = false;
        ///     MethodLogger.Exit(logger, returnValue);
        ///     return returnValue;
        /// }
        /// </example>
        public static void Exit(Logger logger, object returnValue, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exit(logger, returnValue, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="guid">The Guid assigned by the corresponding Enter() method invocation.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Exit(Logger, object, Guid, string, string, int)"/>
        /// <example>
        /// // non-persistent example with a return value
        /// public void MyMethod()
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter();
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(persistedGuid);
        /// }
        /// </example>
        public static void Exit(Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exit(GetLogger(), new UnspecifiedReturnValue(), guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the message.</param>
        /// <param name="guid">The Guid assigned by the corresponding Enter() method invocation.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Exit(Logger, object, Guid, string, string, int)"/>
        /// <example>
        /// // persistent example with no return value
        /// public void MyMethod()
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(logger, true);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger, persistedGuid);
        /// }
        /// </example>
        public static void Exit(Logger logger, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exit(logger, new UnspecifiedReturnValue(), guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="returnValue">The return value of the method.</param>
        /// <param name="guid">The Guid assigned by the corresponding Enter() method invocation.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Exit(Logger, object, Guid, string, string, int)"/>
        /// <example>
        /// // persistent example with no return value
        /// public bool MyMethod()
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(true);
        ///     
        ///     // method body
        ///     
        ///     bool returnValue = false;
        ///     MethodLogger.Exit(returnValue, persistedGuid);
        ///     return returnValue;
        /// }
        /// </example>
        public static void Exit(object returnValue, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exit(GetLogger(), returnValue, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="returnValue">The return value of the method.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <example>
        /// // example usage with persistence and a return value
        /// // use sparingly when logging the execution duration of the method is useful
        /// // if using the persistence option with the Enter() method, ensure the resulting Guid
        /// // is passed to the Exit() method or a memory leak will likely occur.
        /// public bool ExamplePersistedMethod(int one, int two)
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(logger, MethodLogger.Params(one, two), true);
        ///     
        ///     // method body
        ///     
        ///     returnValue = true;
        ///     MethodLogger.Exit(logger, returnValue, persistedGuid);
        ///     return returnValue;
        /// }
        /// </example>
        public static void Exit(Logger logger, object returnValue, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            // check to see if tracing is enabled.  if not, bail out immediately to avoild wasting processor time.
            if (!logger.IsTraceEnabled) return;

            if (Header.Length > 0) logger.Trace(Header);
            logger.Trace(ExitPrefix + "Exiting method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ":line " + lineNumber + ")" + (guid != default(Guid) ? ", Guid: " + guid : ""));

            // if returnValue is null, log a simple message and move on.  we do this to differentiate a null returnValue 
            // from a method invocation that didn't supply anything for returnValue
            if (returnValue == null)
                logger.Trace(LinePrefix + "return: null");
            // if returnValue isn't null compare the provided returnValue Type to our internal type UnspecifiedReturnValue.
            // this should only evaluate to true if an instance of UnspecifiedReturnValue is passed in from an overload.
            else if (returnValue.GetType() != typeof(UnspecifiedReturnValue))
            {
                foreach (string line in GetObjectSerialization(returnValue))
                    logger.Trace(LinePrefix + "return: " + line);
            }

            // if a Guid was provided, locate it in the PersistedMethods list, log the duration
            // and remove it from the list
            if (guid != default(Guid))
            {
                // try to fetch the matching tuple
                Tuple<Guid, DateTime> tuple = PersistedMethods.Where(m => m.Item1 == guid).FirstOrDefault();

                // make sure we found a match
                if (tuple != default(Tuple<Guid, DateTime>))
                {
                    logger.Trace(LinePrefix + "Method execution duration: " + (DateTime.UtcNow - tuple.Item2).TotalMilliseconds.ToString() + "ms");

                    // lock the PersistedMethods list to ensure thread safety.
                    lock (PersistedMethodListLock)
                    {
                        PersistedMethods.Remove(tuple);
                    }
                }
                else
                    logger.Trace(LinePrefix + "[Persisted Guid not found]");
            }

            // log the footer.
            if (Footer.Length > 0) logger.Trace(Footer);

            // prune the PersistedMethods list if automatic pruning is enabled.
            if (AutoPruneEnabled) PrunePersistedMethods(AutoPruneAge);
        }

        #endregion

        #region Checkpoint

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // implicitly defined logger
        /// MethodLogger.Checkpoint();
        /// 
        /// // explicitly defined logger
        /// MethodLogger.Checkpoint(logger);
        /// </example>
        public static void Checkpoint(Logger logger = null, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            if (logger == null)
                logger = GetLogger();

            Checkpoint(logger, null, null, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // explicitly defined logger and persistence
        /// Guid guid = MethodLogger.Enter(logger, true);
        /// 
        /// MethodLogger.Checkpoint(logger, guid);
        /// </example>
        public static void Checkpoint(Logger logger, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(logger, null, null, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // implicitly defined logger and persistence
        /// Guid guid = MethodLogger.Enter(true);
        /// 
        /// MethodLogger.Checkpoint(guid);
        /// </example>
        public static void Checkpoint(Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(GetLogger(), null, null, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // explicitly defined logger with nameless variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// MethodLogger.Checkpoint(logger, MethodLogger.Vars(one, two));
        /// </example>
        public static void Checkpoint(Logger logger, object[] variables, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(logger, variables, null, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // implicitly defined logger with nameless variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// MethodLogger.Checkpoint(MethodLogger.Vars(one, two));
        /// </example>
        public static void Checkpoint(object[] variables, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(GetLogger(), variables, null, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // explicitly defined logger with nameless variables and persistence
        /// Guid guid = MethodLogger.Enter(logger, true);
        /// 
        /// int one = 1;
        /// int two = 2;
        /// 
        /// MethodLogger.Checkpoint(logger, MethodLogger.Vars(one, two), guid);
        /// </example>
        public static void Checkpoint(Logger logger, object[] variables, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(logger, variables, null, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // implicitly defined logger with nameless variables and persistence
        /// Guid guid = MethodLogger.Enter(true);
        /// 
        /// int one = 1;
        /// int two = 2;
        /// 
        /// MethodLogger.Checkpoint(MethodLogger.Vars(one, two), guid);
        /// </example>
        public static void Checkpoint(object[] variables, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(GetLogger(), variables, null, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="variableNames">A string array of variable names to be logged along with the supplied variables.  The number and order should match the variable array.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // explicitly defined logger with named variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// MethodLogger.Checkpoint(logger, MethodLogger.Vars(one, two), MethodLogger.Names("one", "two"));
        /// </example>
        public static void Checkpoint(Logger logger, object[] variables, string[] variableNames, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(logger, variables, variableNames, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="variableNames">A string array of variable names to be logged along with the supplied variables.  The number and order should match the variable array.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // implicitly defined logger with named variables
        /// int one = 1;
        /// int two = 2;
        /// 
        /// MethodLogger.Checkpoint(MethodLogger.Vars(one, two), MethodLogger.Names("one", "two"));
        /// </example>
        public static void Checkpoint(object[] variables, string[] variableNames, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(GetLogger(), variables, variableNames, default(Guid), caller, filePath, lineNumber);
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
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
        /// <example>
        /// // implicitly defined logger with named variables and persistence
        /// Guid guid = MethodLogger.Enter(true);
        /// 
        /// int one = 1;
        /// int two = 2;
        /// 
        /// MethodLogger.Checkpoint(MethodLogger.Vars(one, two), MethodLogger.Names("one", "two"), guid);
        /// </example>
        public static void Checkpoint(object[] variables, string[] variableNames, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Checkpoint(GetLogger(), variables, variableNames, guid, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Logs a message indicating that the execution flow of a method has reached an arbitrary checkpoint defined at design-time.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="variables">A list of variables to be logged.  Use the Vars() method to build this.</param>
        /// <param name="variableNames">A string array of variable names to be logged along with the supplied variables.  The number and order should match the variable array.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <example>
        /// // example usage with an explicitly defined logger, a list of variables, a list of matching variable names, and using persistence.
        /// Guid guid = MethodLogger.Enter(logger, true);
        /// 
        /// int one = 1;
        /// int two = 2;
        /// 
        /// MethodLogger.Checkpoint(logger, MethodLogger.Vars(one, two), MethodLogger.Names("one", "two"), guid);
        /// </example>
        public static void Checkpoint(Logger logger, object[] variables, string[] variableNames, Guid guid, [CallerMemberName]string caller ="", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            if (!logger.IsTraceEnabled) return;

            if (Header.Length > 0) logger.Trace(Header);
            logger.Trace(CheckpointPrefix + "Checkpoint reached in method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ":line " + lineNumber + ")" + (guid != default(Guid) ? ", Guid: " + guid : ""));

            if (variables != null)
            {
                bool useVariableNames = false;

                if (variableNames != null)
                {
                    if (variableNames.Length != variables.Length)
                        logger.Trace(LinePrefix + "[Variable name/variable count mismatch; variables: " + variables.Length + ", names: " + variableNames.Length + "]");
                    else
                        useVariableNames = true;
                }

                for (int v = 0; v < variables.Length; v++)
                    foreach (string line in GetObjectSerialization(variables[v]))
                        logger.Trace(LinePrefix + (useVariableNames ? variableNames[v] : "[" + v + "]") + ": " + line);

            }

            if (guid != default(Guid))
            {
                Tuple<Guid, DateTime> tuple = PersistedMethods.Where(m => m.Item1 == guid).FirstOrDefault();
                logger.Trace(LinePrefix + "Current execution duration: " + (DateTime.UtcNow - tuple.Item2).TotalMilliseconds.ToString() + "ms");
            }

            if (Footer.Length > 0) logger.Trace(Footer);
        }

        #endregion

        #region Exception

        public static void Exception(Logger logger, Exception exception, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            if (!logger.IsTraceEnabled) return;

            if (Header.Length > 0) logger.Trace(Header);
            logger.Trace(ExceptionPrefix + "Exception caught in method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ":line " + lineNumber + ")" + (guid != default(Guid) ? ", Guid: " + guid : ""));

            StackTrace stackTrace = new StackTrace();

            int indent = 0;
            foreach(StackFrame frame in stackTrace.GetFrames())
            {
                MethodInfo methodInfo = (MethodInfo)frame.GetMethod();
                logger.Trace(new String(' ', indent * 3) + LinePrefix + GetMethodSignature(methodInfo));
                indent++;
            }


            if (Footer.Length > 0) logger.Trace(Footer);
        }

        #endregion

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
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // Enter() invocation with one parameter
        /// MethodLogger.Enter(logger, MethodLogger.Params(parameterOne));
        /// 
        /// // Enter() invocation with two parameters
        /// MethodLogger.Enter(logger, MethodLogger.Params(parameterOne, parameterTwo));
        /// 
        /// // Enter() invocation with any number of parameters
        /// MethodLogger.Enter(logger, MethodLogger.Params(parameterOne, ..., parameterN));
        /// 
        /// // Enter() invocation with a parameter list containing an array
        /// MethodLogger.Enter(logger, MethodLogger.Params(parameterOne, parameterTwo, (object)arrayParameterThree));
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
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
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
        /// <seealso cref="Checkpoint(Logger, object[], string[], Guid, string, string, int)"/>
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
        public static void PrunePersistedMethods(int age)
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

        #region Common Methods

        /// <summary>
        /// Searches the execution stack and returns the topmost frame not originating from this class, indicating the calling frame.
        /// </summary>
        /// <returns>The StackFrame containing the calling code.</returns>
        private static StackFrame GetStackFrame()
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
        /// Returns the calling method from the calling StackFrame.
        /// </summary>
        /// <param name="stackFrame">The StackFrame for which to return the method.</param>
        /// <returns>The MethodBase of the calling method.</returns>
        private static MethodBase GetMethod(StackFrame stackFrame = null)
        {
            // if no StackFrame is specified, assume the StackFrame containing the calling method.
            if (stackFrame == null) stackFrame = GetStackFrame();
            return stackFrame.GetMethod();
        }

        /// <summary>
        /// Returns the ParameterInfo of the calling method.
        /// </summary>
        /// <param name="methodBase">The MethodBase for which to return the ParameterInfo.</param>
        /// <returns>The ParameterInfo array of the calling method.</returns>
        private static ParameterInfo[] GetParameterInfo(MethodBase methodBase = null)
        {
            // if no MethodBase is specified, assume the calling MethodBase.
            if (methodBase == null) methodBase = GetMethod();
            return methodBase.GetParameters();
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
                methodInfo = (MethodInfo)GetMethod();

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

        /// <summary>
        /// Returns an implicitly created logger for the calling class and namespace.
        /// </summary>
        /// <returns>An implicitly created logger for the calling class and namespace.</returns>
        private static Logger GetLogger()
        {
            Type methodClass = GetMethod().ReflectedType;
            return LogManager.GetLogger(methodClass.Namespace + "." + methodClass.Name);
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

        #endregion

        #endregion

        #region Nested Classes

        /// <summary>
        /// Internal class used to differentiate a null return value from an unspecified return value.
        /// </summary>
        private class UnspecifiedReturnValue { }

        #endregion

    }
}
