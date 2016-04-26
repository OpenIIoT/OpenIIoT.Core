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

        /// <summary>
        /// The initial value for the AutoPruneEnabled property.
        /// </summary>
        private const bool InitialAutoPruneEnabled = true;

        /// <summary>
        /// The initial value for the AutoPruneAge property.
        /// </summary>
        private const int InitialAutoPruneAge = 1;

        /// <summary>
        /// Initialization status of the MethodLogger.
        /// </summary>
        private static bool initialized = false;

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

        /// <summary>
        /// If true, automatically prunes the PersistedMethods list each time the Exit() method is invoked.
        /// </summary>
        public static bool AutoPruneEnabled { get; set; }

        /// <summary>
        /// Specifies the age, in seconds, of tuples in the PersistedMethods list at which they are eligible for automatic pruning.
        /// </summary>
        public static int AutoPruneAge { get; set; }

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
            AutoPruneEnabled = InitialAutoPruneEnabled;
            AutoPruneAge = InitialAutoPruneAge;

            LogManager.GetCurrentClassLogger().Trace("MethodLogger initialized with AutoPruneEnabled = {0}, AutoPruneAge = {1}", AutoPruneEnabled, AutoPruneAge);
        }

        #endregion

        #region Static Methods

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
        /// <returns>The MethodBase of the calling method.</returns>
        private static MethodBase GetMethod()
        {
            return GetStackFrame().GetMethod();
        }

        /// <summary>
        /// Returns the ParameterInfo of the calling method.
        /// </summary>
        /// <returns>The ParameterInfo array of the calling method.</returns>
        private static ParameterInfo[] GetParameterInfo()
        {
            return GetMethod().GetParameters();
        }

        private static string GetMethodReturnType(MethodBase method)
        {
            // cast MethodBase to MethodInfo to gain access to the ReturnType property
            MethodInfo methodInfo = (MethodInfo)method;

            string methodReturnType = methodInfo.ReturnType.Name;

            // if the return type is generic, build the generic type list
            if (methodInfo.ReturnType.IsGenericType)
            {
                // if the type is generic the type name is represented like MyType`1
                // split the string by the ` character and take the first tuple to get rid of the extra.
                methodReturnType = methodReturnType.Split('`')[0] + "<";

                foreach (Type type in methodInfo.ReturnType.GetGenericArguments())
                    methodReturnType += type.Name + ", ";

                methodReturnType = methodReturnType.Substring(0, methodReturnType.Length - 2) + ">";
            }

            return methodReturnType;
        }

        /// <summary>
        /// Builds and returns the calling method signature, including method name, parameter types and names.
        /// </summary>
        /// <returns>The method signature, including method name, parameter types and names, of the calling method.</returns>
        private static string GetMethodSignature()
        {
            // build a signature string to display by iterating over the method parameters and retrieving names and types
            string methodSignature = GetMethodReturnType(GetMethod()) + " " + GetMethod().Name + "(";

            foreach (ParameterInfo pi in GetParameterInfo())
                methodSignature += pi.ParameterType.Name + " " + pi.Name + ", ";

            methodSignature = (methodSignature.Contains(", ") ? methodSignature.Substring(0, methodSignature.Length - 2) : methodSignature) + ")";
            return methodSignature;
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
        /// Reconfigures the MethodLogger with the specified values for the AutoPruneEnabled and AutoPruneAge properties.
        /// </summary>
        /// <param name="autoPruneEnabled">True if automatic pruning of aged persisted methods should occur following invocation of Exit(), false otherwise.</param>
        /// <param name="autoPruneAge">The age, in seconds, of tuples in the PersistedMethods list at which they are eligible for automatic pruning.</param>
        public static void Configure(bool autoPruneEnabled = InitialAutoPruneEnabled, int autoPruneAge = InitialAutoPruneAge)
        {
            AutoPruneEnabled = autoPruneEnabled;
            AutoPruneAge = autoPruneAge;

            LogManager.GetCurrentClassLogger().Trace("MethodLogger reconfigured with AutoPruneEnabled = {0}, AutoPruneAge = {1}", AutoPruneEnabled, AutoPruneAge);
        }

        /// <summary>
        /// Overload for Enter() allowing parameterless, non-persistent usage.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>A string containing a Guid for the method.</returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // simplest example; non-persistent and with no parameters
        /// public void MyMethod()
        /// {
        ///     MethodLogger.Enter(logger);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger);
        /// }
        /// </example>
        public static Guid Enter(Logger logger, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            LogManager.GetCurrentClassLogger().Trace("logger only called");
            return Enter(logger, null, false, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Overload for Enter() allowing non-persistent usage with a list of parameters.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="parameters"></param>
        /// <param name="caller"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // non-persistent example with parameters
        /// public bool MyMethod(int one, int two)
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
            LogManager.GetCurrentClassLogger().Trace("parameter only called");
            return Enter(logger, parameters, false, caller, filePath, lineNumber);
        }

        /// <summary>
        /// Overload for Enter() allowing parameterless usage.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="persist">
        /// If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.
        /// </param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>A string containing a Guid for the method.</returns>
        /// <seealso cref="Enter(Logger, object[], bool, string, string, int)"/>
        /// <example>
        /// // persistent example with no parameters
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
            LogManager.GetCurrentClassLogger().Trace("persist only called");
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
        /// <param name="logger">The NLog Logger instance to which to log the messages.</param>
        /// <param name="parameters">An object array containing the parameters passed into the logged method.  Use the Params() method to build this.</param>
        /// <param name="persist">
        /// If true, persists the method's Guid internally with a timestamp. Entries using persistence need to provide the Guid string returned
        /// when invoking the Exit() method or a memory leak will occur.
        /// </param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <returns>A string containing a Guid for the method.</returns>
        /// <seealso cref="Params(object[])"/>
        /// <example>
        /// // example usage with persistence and a parameter list
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
        public static Guid Enter(Logger logger, object[] parameters, bool persist, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            LogManager.GetCurrentClassLogger().Trace("full overload called");
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
            logger.Trace(EnterPrefix + "Entering method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ": " + lineNumber + ")" + (persist ? ", persisting with Guid: " + methodGuid : ""));

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
                            //logger.Trace(LinePrefix + parameterInfo[p].Name + ": " + parameters[p].ToString());
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
            else LogManager.GetCurrentClassLogger().Trace("Parameters were null");

            // print the footer.
            if (Footer.Length > 0) logger.Trace(Footer);

            return methodGuid;
        }

        /// <summary>
        /// Overload for Exit() allowing an unspecified return value and non-persistent usage.
        /// </summary>
        /// <param name="logger">The NLog Logger instance to which to log the message.</param>
        /// <param name="caller">An implicit parameter which evaluates to the name of the method that called this method.</param>
        /// <param name="filePath">An implicit parameter which evaluates to the filename from which the calling method was executed.</param>
        /// <param name="lineNumber">An implicit parameter which evaluates to the line number containing this method call.</param>
        /// <seealso cref="Exit(Logger, object, Guid, string, string, int)"/>
        /// <example>
        /// // simplest example; non-persistent and with no return value
        /// public void MyMethod()
        /// {
        ///     MethodLogger.Enter(logger);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger);
        /// }
        /// </example>
        public static void Exit(Logger logger, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exit(logger, new UnspecifiedReturnValue(), default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Overload for Exit() allowing a return value and non-persistent usage.
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
        ///     returnValue = false;
        ///     MethodLogger.Exit(logger, returnValue);
        ///     return returnValue;
        /// }
        /// </example>
        public static void Exit(Logger logger, object returnValue, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exit(logger, returnValue, default(Guid), caller, filePath, lineNumber);
        }

        /// <summary>
        /// Overload for Exit() allowing an unspecified return value and persistent usage.
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
        ///     Guid guid = MethodLogger.Enter(logger, true);
        ///     
        ///     // method body
        ///     
        ///     MethodLogger.Exit(logger, guid);
        /// }
        /// </example>
        public static void Exit(Logger logger, Guid guid, [CallerMemberName]string caller = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Exit(logger, new UnspecifiedReturnValue(), guid, caller, filePath, lineNumber);
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
            logger.Trace(ExitPrefix + "Exiting method: " + GetMethodSignature() + " (" + System.IO.Path.GetFileName(filePath) + ": " + lineNumber + ")" + (guid != default(Guid) ? ", Guid: " + guid : ""));

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
        /// Prunes the PersistedMethods list of any tuples older than the specified age in seconds.
        /// </summary>
        /// <remarks>
        /// Should be called on a regular interval (minutes or perhaps hours) to keep things tidy.
        /// 
        /// If doing so, be mindful of long running methods (Main(), for instance) and be aware that persistence will be deleted if used.
        /// </remarks>
        /// <param name="age">The age in seconds after which persisted methods will be pruned.</param>
        /// <seealso cref="Configure(bool, int)"/>
        /// <example>
        /// // prune persisted methods older than 5 minutes (300 seconds)
        /// MethodLogger.PrunePersistedMethods(300);
        /// </example>
        public static void PrunePersistedMethods(int age)
        {
            // retrieve a list of aged tuples
            List<Tuple<Guid, DateTime>> pruneList = PersistedMethods.Where(m => (DateTime.UtcNow - m.Item2).Seconds > age).ToList();

            // remove everything in the list
            foreach (Tuple<Guid, DateTime> tuple in pruneList)
                PersistedMethods.Remove(tuple);

            LogManager.GetCurrentClassLogger().Trace("Pruned {0} methods with age in excess of {1} seconds from the PersistedMethods list.", pruneList.Count, age);
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
