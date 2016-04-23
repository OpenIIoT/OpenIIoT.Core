using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Symbiote.Core
{
    /// <summary>
    /// The MethodLogger is a generic static class used to provide methods throughout the application with a means
    /// to log the entry and exit of the method body along with the name and value of all method parameters.
    /// </summary>
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

        /// <summary>
        /// String to append to the beginning of each method parameter message.
        /// </summary>
        private static readonly string LinePrefix = "|   +-- ";

        /// <summary>
        /// String to log following any text block.  If no footer is desired, specify a blank string.
        /// </summary>
        private static readonly string Footer = "+-------------------- -------------------------------  -  -          - - -    -   -";

        #endregion

        #region Properties

        public static List<Tuple<Guid, DateTime>> PersistedMethods { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.  
        /// </summary>
        static MethodLogger()
        {
            PersistedMethods = new List<Tuple<Guid, DateTime>>();
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Overload for Enter() allowing parameterless, non-persistent usage.
        /// </summary>
        /// <param name="logger">The NLog logger instance to which to log the messages.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>A string containing a Guid for the method.</returns>
        /// <seealso cref="Enter(NLog.Logger, object[], bool, string, string, int)"/>
        public static Guid Enter(NLog.Logger logger, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return Enter(logger, null, false, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Overload for Enter() allowing parameterless usage.
        /// </summary>
        /// <param name="logger">The NLog logger instance to which to log the messages.</param>
        /// <param name="persist">If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>A string containing a Guid for the method.</returns>
        /// <seealso cref="Enter(NLog.Logger, object[], bool, string, string, int)"/>
        public static Guid Enter(NLog.Logger logger, bool persist, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            return Enter(logger, null, persist, caller, filePath, lineNumber);
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
        /// <param name="logger">The NLog logger instance to which to log the messages.</param>
        /// <param name="parameters">An object array containing the parameters passed into the logged method.  Use the Params() method to build this.</param>
        /// <param name="persist">If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>A string containing a Guid for the method.</returns>
        /// <seealso cref="Params(object[])"/>
        /// <example>
        /// // example usage without persistence
        /// public bool ExampleMethod(string text, int number, SomeObject object)
        /// {
        ///     MethodLogger.Enter(logger, MethodLogger.Params(text, number, object));
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger);
        ///     return true;
        /// }
        /// 
        /// // example usage with persistence
        /// // use sparingly when logging the execution duration of the method is useful
        /// // if using the persistence option with the Enter() method, ensure the resulting Guid
        /// // is passed to the Exit() method or a memory leak will likely occur.
        /// public bool ExamplePersistedMethod(int one, int two)
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(logger, MethodLogger.Params(one, two), true);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger, persistedGuid);
        ///     return true;
        /// }
        /// </example>
        public static Guid Enter(NLog.Logger logger, object[] parameters, bool persist = false, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            // check to see if tracing is enabled.  if not, bail out immediately to avoild wasting processor time.
            if (!logger.IsTraceEnabled)
                return default(Guid);

            Guid methodGuid = default(Guid);

            // if the persist option is true, generate a new Guid for the method call and 
            // add it to the list of persisted methods along with the current datetime.
            if (persist)
            {
                methodGuid = Guid.NewGuid();
                PersistedMethods.Add(new Tuple<Guid, DateTime>(methodGuid, DateTime.UtcNow));
            }

            // print the header
            if (Header.Length > 0) logger.Trace(Header);

            // compose the parameter list.

            // if no parameters were passed, don't waste processor time retrieving the call stack and method parameters.  they aren't relevant anyway.
            if (parameters == null)
                logger.Trace(EnterPrefix + "Entering method '" + caller + "' (" + System.IO.Path.GetFileName(filePath) + ": " + lineNumber + ")" + (persist ? ", persisting with Guid: " + methodGuid : ""));
            else
            {
                // retrieve the trace of the current call stack
                StackTrace stackTrace = new StackTrace();
                // retrieve the parameters of the calling method signature
                ParameterInfo[] parameterInfo = stackTrace.GetFrame(1).GetMethod().GetParameters();

                // build a signature string to display by iterating over the method parameters and retrieving names and types
                string methodSignature = caller + "(";
                foreach (ParameterInfo pi in parameterInfo)
                    methodSignature += pi.ParameterType.Name + " " + pi.Name + ", ";
                methodSignature = methodSignature.Substring(0, methodSignature.Length - 2) + ")";

                // print the entry log
                logger.Trace(EnterPrefix + "Entering method '" + methodSignature + "' (" + System.IO.Path.GetFileName(filePath) + ": " + lineNumber + ")" + (persist ? ", persisting with Guid: " + methodGuid : ""));

                // check to see if the number of supplied parameters matches the method signature parameter list
                // if it doesn't match we really don't want to try to make assumptions about the positioning of what was supplied
                // vs the method signature ordering, so just bail out.
                if (parameterInfo.Length != parameters.Length)
                    logger.Trace(LinePrefix + "[Parameter count mismatch]");
                else
                {
                    // the counts match, meaning we can infer that a complete parameter list has been supplied.
                    // iterate over the supplied parameter array
                    for (int p = 0; p < parameters.Length; p++)
                    {
                        // swallow any errors we might encounter; this isn't important enough to stop the application.
                        try
                        {
                            // check to ensure the type of the supplied parameter in position p is the same
                            // as the type in the method signature parameter list
                            if (!parameterInfo[p].ParameterType.IsAssignableFrom(parameters[p].GetType()))
                                logger.Trace(LinePrefix + "[Parameter type mismatch; expected: " + parameterInfo[p].ParameterType.Name + ", actual: " + parameters[p].GetType().Name + "]");
                            else
                                logger.Trace(LinePrefix + parameterInfo[p].Name + ": " + parameters[p].ToString());
                        }
                        catch (Exception ex)
                        {
                            logger.Trace(LinePrefix + "[Error: " + ex.Message + "]");
                        }
                    }
                }
            }

            // print the footer.
            if (Footer.Length > 0) logger.Trace(Footer);

            return methodGuid;
        }

        /// <summary>
        /// Logs a message indicating the exit of execution flow from a method (depending on the placement of this method call)
        /// </summary>
        /// <param name="logger">The NLog logger instance to which to log the messages.</param>
        /// <param name="guid">The Guid returned by the Enter() method.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <example>
        /// // example usage without persistence
        /// public bool ExampleMethod(string text, int number, SomeObject object)
        /// {
        ///     MethodLogger.Enter(logger, MethodLogger.Params(text, number, object));
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger);
        ///     return true;
        /// }
        /// 
        /// // example usage with persistence
        /// // use sparingly when logging the execution duration of the method is useful
        /// // if using the persistence option with the Enter() method, ensure the resulting Guid
        /// // is passed to the Exit() method or a memory leak will likely occur.
        /// public bool ExamplePersistedMethod(int one, int two)
        /// {
        ///     Guid persistedGuid = MethodLogger.Enter(logger, MethodLogger.Params(one, two), true);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger, persistedGuid);
        ///     return true;
        /// }
        /// </example>
        public static void Exit(NLog.Logger logger, Guid guid = new Guid(), [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            if (Header.Length > 0) logger.Trace(Header);
            logger.Trace(ExitPrefix + "Exiting method '" + caller + "' (" + System.IO.Path.GetFileName(filePath) + ": " + lineNumber + ")" + (guid != default(Guid) ? ", Guid: " + guid : ""));

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
                    PersistedMethods.Remove(tuple);
                }
                else
                    logger.Trace(LinePrefix + "[Persisted Guid not found]");
            }
                

            if (Footer.Length > 0) logger.Trace(Footer);
        }

        /// <summary>
        /// Returns the object array specified in the input parameter(s) for the method.  Accepts a dynamic number of parameters
        /// of any type which are implictly added to an object array.
        /// </summary>
        /// <remarks>
        /// This is a shorthand method that eliminates the need to explicitly define an object array when using the Enter() method.
        /// This is necessary because the current C# specification doesn't allow for the params keyword and optional implicit parameters in the same method
        /// signature due to ambiguity.
        /// </remarks>
        /// <param name="parameters">A dynamic object array of method parameters.</param>
        /// <returns>The provided object array.</returns>
        /// <seealso cref="Enter(NLog.Logger, object[], bool, string, string, int)"/>
        public static object[] Params(params object[] parameters)
        {
            return parameters;
        }

        /// <summary>
        /// Prunes the PersistedMethods list of any tuples older than the specified age in seconds.
        /// </summary>
        /// <param name="age">The age in seconds after which persisted methods will be pruned.</param>
        public static void PrunePersistedMethods(int age)
        {
            List<Tuple<Guid, DateTime>> pruneList = PersistedMethods.Where(m => (DateTime.UtcNow - m.Item2).Seconds > age).ToList();

            foreach(Tuple<Guid, DateTime> tuple in pruneList)
                PersistedMethods.Remove(tuple);
        }
        #endregion
    }
}
