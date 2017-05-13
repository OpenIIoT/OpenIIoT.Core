using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.SDK.Package.Packaging
{
    internal static class ArgumentValidator
    {
        #region Private Methods

        /// <summary>
        ///     Validates the inputDirectory argument for packaging commands.
        /// </summary>
        /// <param name="inputDirectory">The value specified for the inputDirectory argument.</param>
        /// <exception cref="ArgumentException">Thrown when the directory is an empty or null string.</exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     Thrown when the directory can not be found on the local file system.
        /// </exception>
        /// <exception cref="FileNotFoundException">Thrown when the directory contains no files.</exception>
        internal static void ValidateInputDirectoryArgument(string inputDirectory)
        {
            if (inputDirectory == default(string) || inputDirectory == string.Empty)
            {
                throw new ArgumentException($"The required argument 'directory' was not supplied.");
            }

            if (!Directory.Exists(inputDirectory))
            {
                throw new DirectoryNotFoundException($"The specified directory '{inputDirectory}' could not be found.");
            }

            if (Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories).Length == 0)
            {
                throw new FileNotFoundException($"The specified directory '{inputDirectory}' is empty; Packages must contain at least one file.");
            }
        }

        /// <summary>
        ///     Validates the outputDirectory and overwrite arguments for packaging commands.
        /// </summary>
        /// <param name="outputDirectory">The value specified for the outputDirectory argument.</param>
        /// <param name="overwrite">The value specified for the overwrite argument.</param>
        /// <exception cref="ArgumentException">Thrown when the package is an empty or null string.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the output directory exists and is not empty but the overwrite argument is false.
        /// </exception>
        internal static void ValidateOutputDirectoryArgument(string outputDirectory, bool overwrite)
        {
            if (string.IsNullOrEmpty(outputDirectory))
            {
                throw new ArgumentException("The required argument 'directory' was not supplied.");
            }

            if (Directory.Exists(outputDirectory) && !overwrite)
            {
                if (Directory.GetFiles(outputDirectory).Length > 0)
                {
                    throw new InvalidOperationException($"The directory '{outputDirectory}' exists and is not empty.");
                }
            }
        }

        /// <summary>
        ///     Validates the packageFile argument for packaging commands.
        /// </summary>
        /// <param name="packageFile">The value specified for the packageFile argument.</param>
        /// <exception cref="ArgumentException">Thrown when the package is an empty or null string.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the package can not be found on the local file system.</exception>
        /// <exception cref="InvalidDataException">Thrown when the package contains no files.</exception>
        /// <exception cref="IOException">Thrown when the package can not be read.</exception>
        internal static void ValidatePackageFileArgument(string packageFile)
        {
            if (string.IsNullOrEmpty(packageFile))
            {
                throw new ArgumentException($"The required argument 'package' was not supplied.");
            }

            if (!File.Exists(packageFile))
            {
                throw new FileNotFoundException($"The specified package file '{packageFile}' could not be found.");
            }

            if (new FileInfo(packageFile).Length == 0)
            {
                throw new InvalidDataException($"The specified package file '{packageFile}' is empty.");
            }

            if (!File.OpenRead(packageFile).CanRead)
            {
                throw new IOException($"The specified package file '{packageFile}' could not be opened for reading.  It may be open in another process, or you may have insufficient rights.");
            }

            try
            {
                File.WriteAllText(packageFile, "Hello World!");
                File.Delete(packageFile);
            }
            catch (Exception ex)
            {
                throw new Exception($"The specified package file '{packageFile}' could not be written: {ex.Message}");
            }
        }

        #endregion Private Methods
    }
}