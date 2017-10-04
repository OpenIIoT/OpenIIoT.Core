/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄
      █     ███    ███
      █     ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄
      █     ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄
      █   ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██
      █     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██
      █     ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██
      █    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █
      █
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██    ▄█████   ▄█████     ██      ▄█████
      █       ███   ▀   ██   █    ██  ▀  ▀███████▄   ██  ▀
      █       ███      ▄██▄▄      ██         ██  ▀   ██
      █       ███     ▀▀██▀▀    ▀███████     ██    ▀███████
      █       ███       ██   █     ▄  ██     ██       ▄  ██
      █      ▄████▀     ███████  ▄████▀     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Unit tests for the Platform class.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Moq;
using OpenIIoT.SDK.Common.Provider.ItemProvider;
using OpenIIoT.SDK.Platform;
using OpenIIoT.SDK.Common.OperationResult;
using Xunit;

namespace OpenIIoT.Core.Tests.Platform
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Platform.Platform"/> class.
    /// </summary>
    /// <remarks>
    ///     Many of the unit tests in this class are actually integration tests due to the fact that the underlying file system is
    ///     not abstracted from the tests.
    /// </remarks>
    [Collection("Platform")]
    public sealed class Platform : IDisposable
    {
        #region Private Fields

        /// <summary>
        ///     The shared directory into which test files are to be manipulated
        /// </summary>
        private string testDirectory;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Platform"/> class.
        /// </summary>
        public Platform()
        {
            SetupMocks();

            // set test directory = application directory + a new Guid
            string root = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string dir = Guid.NewGuid().ToString();

            testDirectory = Path.Combine(root, dir);

            Directory.CreateDirectory(testDirectory);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="IPlatform"/> mockup for the unit tests.
        /// </summary>
        private PlatformMock PlatformMock { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ClearDirectory(string)"/> method.
        /// </summary>
        [Fact]
        public void ClearDirectory()
        {
            // create a file and directory in the test directory
            string dir = Path.Combine(testDirectory, "folder");
            string file = Path.Combine(testDirectory, "file.txt");

            Directory.CreateDirectory(dir);
            File.WriteAllText(file, "Hello World!");

            // assert that the file and folder exist
            Assert.True(Directory.Exists(dir));
            Assert.True(File.Exists(file));

            // clear the test directory
            IResult result = PlatformMock.ClearDirectory(testDirectory);

            Assert.Equal(ResultCode.Success, result.ResultCode);

            // assert that the directory exists and is empty
            Assert.True(Directory.Exists(testDirectory));
            Assert.Equal(0, Directory.EnumerateDirectories(testDirectory).Count());
            Assert.Equal(0, Directory.EnumerateFiles(testDirectory).Count());
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ClearDirectory(string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void ClearDirectoryFailure()
        {
            IResult result = PlatformMock.ClearDirectory(Path.Combine(testDirectory, "null"));
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ComputeFileChecksum(string)"/> method.
        /// </summary>
        [Fact]
        public void ComputeFileChecksum()
        {
            // create and write a file
            string file = Path.Combine(testDirectory, "file.txt");
            File.WriteAllText(file, "Hello World!");

            // compute the checksum
            IResult<string> result = PlatformMock.ComputeFileChecksum(file);

            // assert that the operation succeeded and compare the result to the known checksum for the written content
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal("7f83b1657ff1fc53b92dc18148a1d65dfc2d4b1fa3d677284addd200126d9069", result.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ComputeFileChecksum(string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void ComputeFileChecksumFailure()
        {
            IResult<string> result = PlatformMock.ComputeFileChecksum(Path.Combine(testDirectory, "null"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.Equal(default(string), result.ReturnValue);
        }

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsAssignableFrom<Core.Platform.Platform>(PlatformMock);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.CopyFile(string, string)"/> method.
        /// </summary>
        [Fact]
        public void CopyFile()
        {
            string sourceFile = Path.Combine(testDirectory, "test.txt");
            string destinationFile = Path.Combine(testDirectory, "test2.txt");

            File.WriteAllText(sourceFile, "hello world");
            Assert.True(File.Exists(sourceFile));

            IResult<string> result = PlatformMock.CopyFile(sourceFile, destinationFile);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(destinationFile));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.CopyFile(string, string)"/> method with an existing file.
        /// </summary>
        [Fact]
        public void CopyFileDestinationExists()
        {
            string sourceFile = Path.Combine(testDirectory, "test.txt");
            string destinationFile = Path.Combine(testDirectory, "test2.txt");

            File.WriteAllText(sourceFile, "hello world");
            File.WriteAllText(destinationFile, "i exist");
            Assert.True(File.Exists(sourceFile));
            Assert.True(File.Exists(destinationFile));

            IResult<string> result = PlatformMock.CopyFile(sourceFile, destinationFile, false);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.CopyFile(string, string)"/> method with an existing file and using the
        ///     overwrite option.
        /// </summary>
        [Fact]
        public void CopyFileDestinationOverwrite()
        {
            string sourceFile = Path.Combine(testDirectory, "test.txt");
            string destinationFile = Path.Combine(testDirectory, "test2.txt");

            File.WriteAllText(sourceFile, "hello world");
            File.WriteAllText(destinationFile, "i exist");
            Assert.True(File.Exists(sourceFile));
            Assert.True(File.Exists(destinationFile));

            IResult<string> result = PlatformMock.CopyFile(sourceFile, destinationFile, true);

            Assert.Equal(ResultCode.Success, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.CreateDirectory(string)"/> method.
        /// </summary>
        [Fact]
        public void CreateDirectory()
        {
            string testDir = Path.Combine(testDirectory, "test");

            // create the directory and assert that it exists
            IResult result = PlatformMock.CreateDirectory(testDir);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(Directory.Exists(testDir));

            // bypass the Platform class to delete the directory
            Directory.Delete(testDir);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.CreateDirectory(string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void CreateDirectoryFailure()
        {
            IResult result = PlatformMock.CreateDirectory(testDirectory + Path.DirectorySeparatorChar + "<>|&\0");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.CreateZip(string, string)"/> method.
        /// </summary>
        [Fact]
        public void CreateZip()
        {
            // create a folder and two files
            string folder = Path.Combine(testDirectory, "folder");
            Directory.CreateDirectory(folder);

            string file1 = Path.Combine(folder, "file1.txt");
            string file2 = Path.Combine(folder, "file2.txt");
            string contents = "Hello World!";

            File.WriteAllText(file1, contents);
            File.WriteAllText(file2, contents);

            // create a zip file from the folder
            string zipFile = Path.Combine(testDirectory, "zip.zip");

            // zip it
            IResult<string> result = PlatformMock.CreateZip(zipFile, folder);

            // assert that the zip succeeded and that the resulting file exists
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(zipFile));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.CreateZip(string, string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void CreateZipFailing()
        {
            IResult<string> result = PlatformMock.CreateZip("?/?", testDirectory);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.DeleteDirectory(string, bool)"/> method.
        /// </summary>
        [Fact]
        public void DeleteDirectory()
        {
            string testDir = Path.Combine(testDirectory, "test");

            // bypass the Platform class to create the directory
            Directory.CreateDirectory(testDir);

            // delete the directory and assert that it doesn't exist
            IResult result = PlatformMock.DeleteDirectory(testDir);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.False(Directory.Exists(testDir));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.DeleteDirectory(string, bool)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void DeleteDirectoryFailure()
        {
            IResult result = PlatformMock.DeleteDirectory(Path.Combine(testDirectory, "null"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Test <see cref="Core.Platform.Platform.DeleteFile(string)"/> method.
        /// </summary>
        [Fact]
        public void DeleteFile()
        {
            // create a file
            string file = Path.Combine(testDirectory, "file.txt");
            File.WriteAllText(file, "Hello World!");

            // delete
            IResult result = PlatformMock.DeleteFile(file);

            // assert that the operation succeeded and that the file no longer exists
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.False(File.Exists(file));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.DeleteFile(string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void DeleteFileFailure()
        {
            IResult result = PlatformMock.DeleteFile(string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.DeleteDirectory(string, bool)"/> method.
        /// </summary>
        [Fact]
        public void DirectoryExists()
        {
            // specify two directories
            string goodDir = Path.Combine(testDirectory, "folder");
            string badDir = Path.Combine(testDirectory, "badfolder");

            // create only one
            Directory.CreateDirectory(goodDir);

            // assert that only the directory we created exists
            Assert.True(PlatformMock.DirectoryExists(goodDir));
            Assert.False(PlatformMock.DirectoryExists(badDir));
        }

        /// <summary>
        ///     Delete the test directory.
        /// </summary>
        /// <remarks>
        ///     In some instances the directory may be locked by the OS when disposal is initiated. Retry the deletion up to 5
        ///     times, pausing between each attempt to allow the OS time to release the lock.
        /// </remarks>
        public void Dispose()
        {
            int retryLimit = 5;
            int retry = 0;

            while (Directory.Exists(testDirectory))
            {
                if (retry >= retryLimit)
                {
                    break;
                }

                try
                {
                    Directory.Delete(testDirectory, true);
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(500);
                    retry++;
                }
            }
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ExtractZipFile(string, string, string, bool)"/> method.
        /// </summary>
        [Fact]
        public void ExtractZip()
        {
            // create a zip file containing two files
            string folder = Path.Combine(testDirectory, "folder");
            Directory.CreateDirectory(folder);

            string file1 = Path.Combine(folder, "file1.txt");
            string file2 = Path.Combine(folder, "file2.txt");
            string contents = "Hello World!";

            File.WriteAllText(file1, contents);
            File.WriteAllText(file2, contents);

            string zipFile = Path.Combine(testDirectory, "zip.zip");

            IResult<string> result = PlatformMock.CreateZip(zipFile, folder);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(zipFile));

            // determine the destination
            string unzipFolder = Path.Combine(testDirectory, "unzipFolder");

            // unzip the file
            IResult<string> extractResult = PlatformMock.ExtractZip(zipFile, unzipFolder);

            // assert that the unzip succeeded
            Assert.Equal(ResultCode.Success, result.ResultCode);

            // list the extracted files
            List<string> extractedFiles = Directory.EnumerateFiles(unzipFolder).ToList<string>();

            // assert that two files matching the files we zipped exist in the destination folder
            Assert.Equal(2, extractedFiles.Count);
            Assert.True(extractedFiles.Any(f => Path.GetFileName(f) == "file1.txt"));
            Assert.True(extractedFiles.Any(f => Path.GetFileName(f) == "file2.txt"));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ExtractZipFile(string, string, string, bool)"/> method with an existing
        ///     destination and with the clearDestination set to false.
        /// </summary>
        [Fact]
        public void ExtractZipDestinationExistsDoNotclear()
        {
            // create a zip file containing two files
            string folder = Path.Combine(testDirectory, "folder");
            Directory.CreateDirectory(folder);

            string file1 = Path.Combine(folder, "file1.txt");
            string file2 = Path.Combine(folder, "file2.txt");
            string contents = "Hello World!";

            File.WriteAllText(file1, contents);
            File.WriteAllText(file2, contents);

            string zipFile = Path.Combine(testDirectory, "zip.zip");

            IResult<string> result = PlatformMock.CreateZip(zipFile, folder);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(zipFile));

            // determine the destination
            string unzipFolder = Path.Combine(testDirectory, "unzipFolder");
            Directory.CreateDirectory(unzipFolder);

            // unzip the file
            IResult<string> extractResult = PlatformMock.ExtractZip(zipFile, unzipFolder, false);

            // assert that the unzip succeeded
            Assert.Equal(ResultCode.Success, result.ResultCode);

            // list the extracted files
            List<string> extractedFiles = Directory.EnumerateFiles(unzipFolder).ToList<string>();

            // assert that two files matching the files we zipped exist in the destination folder
            Assert.Equal(2, extractedFiles.Count);
            Assert.True(extractedFiles.Any(f => Path.GetFileName(f) == "file1.txt"));
            Assert.True(extractedFiles.Any(f => Path.GetFileName(f) == "file2.txt"));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ExtractZipFile(string, string, string, bool)"/> method under expected
        ///     failing conditions.
        /// </summary>
        [Fact]
        public void ExtractZipFailure()
        {
            IResult<string> result = PlatformMock.ExtractZip(".", string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ExtractZipFile(string, string, string, bool)"/> method.
        /// </summary>
        [Fact]
        public void ExtractZipFile()
        {
            // create a zip file containing two files
            string folder = Path.Combine(testDirectory, "folder");
            Directory.CreateDirectory(folder);

            string file1 = Path.Combine(folder, "file1.txt");
            string file2 = Path.Combine(folder, "file2.txt");
            string contents = "Hello World!";

            // repeat the content of the second file to differentiate the two
            File.WriteAllText(file1, contents);
            File.WriteAllText(file2, contents + contents);

            string zipFile = Path.Combine(testDirectory, "zip.zip");

            IResult<string> result = PlatformMock.CreateZip(zipFile, folder);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(zipFile));

            // extract the file create the destination directory
            string destination = Path.Combine(testDirectory, "extracted");
            string destinationFile = Path.Combine(destination, "file1.txt");
            Directory.CreateDirectory(destination);
            Assert.True(Directory.Exists(destination));

            // perform the extraction
            IResult<string> extractFileResult = PlatformMock.ExtractZipFile(zipFile, "file1.txt", destination);

            // assert that the extraction succeeded and that the file exists and contains the expected contents
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(destinationFile));

            string extractedFileContents = File.ReadAllText(destinationFile);
            Assert.Equal(contents, extractedFileContents);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ExtractZipFile(string, string, string, bool)"/> method under expected
        ///     failing conditions.
        /// </summary>
        [Fact]
        public void ExtractZipFileFailure()
        {
            IResult<string> result = PlatformMock.ExtractZipFile(".", string.Empty, string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.FileExists(string)"/> method.
        /// </summary>
        [Fact]
        public void FileExists()
        {
            // build two filenames
            string goodFile = Path.Combine(testDirectory, "file.txt");
            string badFile = Path.Combine(testDirectory, "badfile.txt");

            // write one of them
            File.WriteAllText(goodFile, "Hello World!");

            // assert that only the one we wrote exists
            Assert.True(PlatformMock.FileExists(goodFile));
            Assert.False(PlatformMock.FileExists(badFile));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ListDirectories(string, string)"/> method.
        /// </summary>
        [Fact]
        public void ListDirectories()
        {
            // create two directories
            string dir1 = Path.Combine(testDirectory, "dir1");
            string dir2 = Path.Combine(testDirectory, "dir2");

            Directory.CreateDirectory(dir1);
            Directory.CreateDirectory(dir2);

            // list
            IResult<IList<string>> result = PlatformMock.ListDirectories(testDirectory);

            // assert that two directories matching our directory names were returned
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(2, result.ReturnValue.Count);
            Assert.True(result.ReturnValue.Any(s => s == dir1));
            Assert.True(result.ReturnValue.Any(s => s == dir2));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ListDirectories(string, string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void ListDirectoriesFailure()
        {
            IResult result = PlatformMock.ListDirectories(Path.Combine(testDirectory, "null"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ListFiles(string, string)"/> method.
        /// </summary>
        [Fact]
        public void ListFiles()
        {
            // create two files
            string file1 = Path.Combine(testDirectory, "file1.txt");
            string file2 = Path.Combine(testDirectory, "file2.txt");
            string contents = "Hello World!";

            File.WriteAllText(file1, contents);
            File.WriteAllText(file2, contents);

            // ensure the files we created exist
            Assert.True(File.Exists(file1));
            Assert.True(File.Exists(file2));

            // list the files in the test directory
            IResult<IList<string>> result = PlatformMock.ListFiles(testDirectory);

            // assert that two files matching the files we created are returned
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(2, result.ReturnValue.Count);
            Assert.True(result.ReturnValue.Any(f => f == file1));
            Assert.True(result.ReturnValue.Any(f => f == file2));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ListFiles(string, string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void ListFilesFailure()
        {
            IResult result = PlatformMock.ListFiles(Path.Combine(testDirectory, "null"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ListZipFiles(string, string)"/> method.
        /// </summary>
        [Fact]
        public void ListZipFiles()
        {
            // create a zip file
            string folder = Path.Combine(testDirectory, "folder");
            Directory.CreateDirectory(folder);

            string file1 = Path.Combine(folder, "file1.txt");
            string file2 = Path.Combine(folder, "file2.txt");
            string contents = "Hello World!";

            File.WriteAllText(file1, contents);
            File.WriteAllText(file2, contents);

            string zipFile = Path.Combine(testDirectory, "zip.zip");

            IResult<string> result = PlatformMock.CreateZip(zipFile, folder);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(zipFile));

            // list the contents of the zip we crated
            IResult<IList<string>> listResult = PlatformMock.ListZipFiles(zipFile);

            // ensure the contents match the file we created
            Assert.Equal(ResultCode.Success, listResult.ResultCode);
            Assert.Equal(2, listResult.ReturnValue.Count);
            Assert.True(listResult.ReturnValue.Any(f => f == "file1.txt"));
            Assert.True(listResult.ReturnValue.Any(f => f == "file2.txt"));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ListZipFiles(string, string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void ListZipFilesFailure()
        {
            IResult<IList<string>> result = PlatformMock.ListZipFiles(string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ListZipFiles(string, string)"/> method with search string which does
        ///     not match any files in the zip.
        /// </summary>
        [Fact]
        public void ListZipFilesNoMatches()
        {
            // create a zip file
            string folder = Path.Combine(testDirectory, "folder");
            Directory.CreateDirectory(folder);

            string file1 = Path.Combine(folder, "file1.txt");
            string file2 = Path.Combine(folder, "file2.txt");
            string contents = "Hello World!";

            File.WriteAllText(file1, contents);
            File.WriteAllText(file2, contents);

            string zipFile = Path.Combine(testDirectory, "zip.zip");

            IResult<string> result = PlatformMock.CreateZip(zipFile, folder);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(zipFile));

            // list the contents of the zip we crated
            IResult<IList<string>> listResult = PlatformMock.ListZipFiles(zipFile, "*nomatch*");

            // ensure the contents match the file we created
            Assert.Equal(ResultCode.Success, listResult.ResultCode);
            Assert.Equal(0, listResult.ReturnValue.Count);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            Assert.IsAssignableFrom<IItemProvider>(PlatformMock.ItemProvider);
            Assert.Equal(PlatformType.Unknown, PlatformMock.PlatformType);
            Assert.Equal("1.0", PlatformMock.Version);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ReadFileText(string)"/> method.
        /// </summary>
        [Fact]
        public void ReadFile()
        {
            // create a file
            string file = Path.Combine(testDirectory, "file.txt");
            string content = "Hello World!";
            File.WriteAllText(file, content);

            // read it
            IResult<string> result = PlatformMock.ReadFileText(file);

            // assert that the contents match
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(content, result.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ReadFileBytes(string)"/> method.
        /// </summary>
        [Fact]
        public void ReadFileBytes()
        {
            string file = Path.Combine(testDirectory, Guid.NewGuid().ToString());
            byte[] bytes = new byte[] { 32 };
            File.WriteAllBytes(file, bytes);

            IResult<byte[]> result = PlatformMock.ReadFileBytes(file);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(bytes, result.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ReadFileBytes(string)"/> method with a bad filename.
        /// </summary>
        [Fact]
        public void ReadFileBytesFailure()
        {
            string file = Path.Combine(testDirectory, Guid.NewGuid().ToString());

            IResult<byte[]> result = PlatformMock.ReadFileBytes(file);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ReadFileText(string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void ReadFileFailure()
        {
            string file = Path.Combine(testDirectory, "null");

            IResult result = PlatformMock.ReadFileText(file);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ReadFileLines(string)"/> method.
        /// </summary>
        [Fact]
        public void ReadFileLines()
        {
            // write a file
            string file = Path.Combine(testDirectory, "file.txt");
            string[] content = new string[] { "Hello", "World!" };
            File.WriteAllLines(file, content);

            // read it
            IResult<string[]> result = PlatformMock.ReadFileLines(file);

            // assert that the contents match
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(content, result.ReturnValue);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.ReadFileLines(string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void ReadFileLinesFailure()
        {
            string file = Path.Combine(testDirectory, "null");

            IResult result = PlatformMock.ReadFileLines(file);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.WriteFileText(string, string)"/> method.
        /// </summary>
        [Fact]
        public void WriteFile()
        {
            // set up a filename and contents
            string file = Path.Combine(testDirectory, "file.txt");
            string contents = "Hello World!";

            // assert that it doesn't yet exist
            Assert.False(File.Exists(file));

            // write it
            IResult<string> result = PlatformMock.WriteFileText(file, contents);

            // assert that it was written
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.WriteFileBytes(string, byte[])"/> method.
        /// </summary>
        [Fact]
        public void WriteFileBytes()
        {
            string file = Path.Combine(testDirectory, Guid.NewGuid().ToString());

            IResult<string> result = PlatformMock.WriteFileBytes(file, new byte[] { 32 });

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(File.Exists(file));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.WriteFileBytes(string, byte[])"/> method with a bad filename.
        /// </summary>
        [Fact]
        public void WriteFileBytesFailure()
        {
            string file = Path.Combine(testDirectory, string.Empty);

            IResult<string> result = PlatformMock.WriteFileBytes(file, new byte[] { 32 });

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.WriteFileText(string, string)"/> method by writing an existing file.
        /// </summary>
        [Fact]
        public void WriteFileExisting()
        {
            // write a file
            string file = Path.Combine(testDirectory, "file.txt");
            string contents = "Hello World!";
            string newContents = "The quick brown fox jumped over the lazy dog.";

            IResult<string> result = PlatformMock.WriteFileText(file, contents);

            // assert that it was written
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));

            // write it again with different contents
            result = PlatformMock.WriteFileText(file, newContents);

            // assert that it was overwritten
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));

            string readContents = File.ReadAllText(file);

            Assert.Equal(newContents, readContents);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.WriteFileText(string, string)"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void WriteFileFailure()
        {
            string file = Path.Combine(testDirectory, "?/?");

            IResult result = PlatformMock.WriteFileText(file, string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.WriteFileLines(string, string[])"/> method.
        /// </summary>
        [Fact]
        public void WriteFileLines()
        {
            // set up a file
            string file = Path.Combine(testDirectory, "file.txt");
            string[] contents = new string[] { "Hello", "World!" };

            // assert that it doesn't yet exist
            Assert.False(File.Exists(file));

            // write it
            IResult<string> result = PlatformMock.WriteFileLines(file, contents);

            // assert that it was written
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.WriteFileLines(string, string[])"/> method by writing an existing file.
        /// </summary>
        [Fact]
        public void WriteFileLinesExisting()
        {
            // write a file
            string file = Path.Combine(testDirectory, "file.txt");
            string[] contents = new string[] { "Hello", "World!" };
            string[] newContents = new string[] { "The quick brown", "fox jumped over", "the lazy dog." };

            IResult<string> result = PlatformMock.WriteFileLines(file, contents);

            // assert that it was written
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));

            // write it again
            result = PlatformMock.WriteFileLines(file, newContents);

            // assert that the contents have been overwritten
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));

            string[] readContents = File.ReadAllLines(file);

            Assert.Equal(newContents, readContents);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.Platform.WriteFileLines(string, string[])"/> method under expected failing conditions.
        /// </summary>
        [Fact]
        public void WriteFileLinesFailure()
        {
            string file = Path.Combine(testDirectory, "?/?");

            IResult result = PlatformMock.WriteFileLines(file, new string[] { });

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups for the unit tests.
        /// </summary>
        private void SetupMocks()
        {
            PlatformMock = new PlatformMock();
        }

        #endregion Private Methods
    }

    /// <summary>
    ///     Mocks a <see cref="Core.Platform.Platform"/> of type <see cref="PlatformType.Unknown"/>.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the abstract nature of the base class.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class PlatformMock : Core.Platform.Platform
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlatformMock"/> class.
        /// </summary>
        public PlatformMock()
            : base()
        {
            PlatformType = PlatformType.Unknown;
            Version = "1.0";
            ItemProvider = new Mock<IItemProvider>().Object;
        }

        #endregion Public Constructors
    }
}