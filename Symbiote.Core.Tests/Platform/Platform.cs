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
using System.Collections.Generic;
using Symbiote.SDK.Platform;
using Symbiote.SDK.Plugin.Connector;
using Moq;
using Xunit;
using System.IO;
using Utility.OperationResult;
using System.Linq;

namespace Symbiote.Core.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Platform.Platform"/> class.
    /// </summary>
    /// <remarks>
    ///     Many of the unit tests in this class are actually integration tests due to the fact that the underlying filesystem is
    ///     not abstracted from the tests.
    /// </remarks>
    [Collection("Platform")]
    public class Platform : IDisposable
    {
        private MockPlatform platformMock;
        private string testDirectory;

        public Platform()
        {
            platformMock = new MockPlatform();
            platformMock.InstantiateConnector("instanceName");

            string root = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string dir = Guid.NewGuid().ToString();

            testDirectory = Path.Combine(root, dir);

            Directory.CreateDirectory(testDirectory);
        }

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
                catch (Exception ex)
                {
                    System.Threading.Thread.Sleep(500);
                    retry++;
                }
            }
        }

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsAssignableFrom<Core.Platform.Platform>(platformMock);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            Assert.IsAssignableFrom<IConnector>(platformMock.Connector);
            Assert.Equal(PlatformType.Unknown, platformMock.PlatformType);
            Assert.Equal("1.0", platformMock.Version);
        }

        [Fact]
        public void ListDirectories()
        {
            string dir1 = Path.Combine(testDirectory, "dir1");
            string dir2 = Path.Combine(testDirectory, "dir2");

            Directory.CreateDirectory(dir1);
            Directory.CreateDirectory(dir2);

            Result<List<string>> result = platformMock.ListDirectories(testDirectory);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(2, result.ReturnValue.Count);
            Assert.True(result.ReturnValue.Any(s => s == dir1));
            Assert.True(result.ReturnValue.Any(s => s == dir2));
        }

        [Fact]
        public void ListDirectoriesFailure()
        {
            Result result = platformMock.ListDirectories(Path.Combine(testDirectory, "null"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void CreateDirectory()
        {
            string testDir = Path.Combine(testDirectory, "test");

            // create the directory and assert that it exists
            Result result = platformMock.CreateDirectory(testDir);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(Directory.Exists(testDir));

            // bypass the Platform class to delete the directory
            Directory.Delete(testDir);
        }

        [Fact]
        public void DeleteDirectory()
        {
            string testDir = Path.Combine(testDirectory, "test");

            // bypass the Platform class to create the directory
            Directory.CreateDirectory(testDir);

            // delete the directory and assert that it doesn't exist
            Result result = platformMock.DeleteDirectory(testDir);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.False(Directory.Exists(testDir));
        }

        [Fact]
        public void DeleteFile()
        {
            string file = Path.Combine(testDirectory, "file.txt");
            File.WriteAllText(file, "Hello World!");

            Result result = platformMock.DeleteFile(file);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.False(File.Exists(file));
        }

        [Fact]
        public void DeleteFileFailure()
        {
            Result result = platformMock.DeleteFile("");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ComputeFileChecksum()
        {
            string file = Path.Combine(testDirectory, "file.txt");
            File.WriteAllText(file, "Hello World!");

            Result<string> result = platformMock.ComputeFileChecksum(file);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal("7f83b1657ff1fc53b92dc18148a1d65dfc2d4b1fa3d677284addd200126d9069", result.ReturnValue);
        }

        [Fact]
        public void ComputeFileChecksumFailure()
        {
            Result<string> result = platformMock.ComputeFileChecksum(Path.Combine(testDirectory, "null"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.Equal(default(string), result.ReturnValue);
        }

        [Fact]
        public void CreateDirectoryFailure()
        {
            Result result = platformMock.CreateDirectory(Path.Combine(testDirectory, "?"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void DeleteDirectoryFailure()
        {
            Result result = platformMock.DeleteDirectory(Path.Combine(testDirectory, "null"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

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
            Result result = platformMock.ClearDirectory(testDirectory);

            Assert.Equal(ResultCode.Success, result.ResultCode);

            // assert that the directory exists and is empty
            Assert.True(Directory.Exists(testDirectory));
            Assert.Equal(0, Directory.EnumerateDirectories(testDirectory).Count());
            Assert.Equal(0, Directory.EnumerateFiles(testDirectory).Count());
        }

        [Fact]
        public void ReadFile()
        {
            string file = Path.Combine(testDirectory, "file.txt");
            string content = "Hello World!";
            File.WriteAllText(file, content);

            Result<string> result = platformMock.ReadFile(file);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(content, result.ReturnValue);
        }

        [Fact]
        public void ReadFileFailure()
        {
            string file = Path.Combine(testDirectory, "null");

            Result result = platformMock.ReadFile(file);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ReadFileLines()
        {
            string file = Path.Combine(testDirectory, "file.txt");
            string[] content = new string[] { "Hello", "World!" };
            File.WriteAllLines(file, content);

            Result<string[]> result = platformMock.ReadFileLines(file);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(content, result.ReturnValue);
        }

        [Fact]
        public void ReadFileLinesFailure()
        {
            string file = Path.Combine(testDirectory, "null");

            Result result = platformMock.ReadFileLines(file);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ClearDirectoryFailure()
        {
            Result result = platformMock.ClearDirectory(Path.Combine(testDirectory, "null"));
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void FileExists()
        {
            string goodFile = Path.Combine(testDirectory, "file.txt");
            string badFile = Path.Combine(testDirectory, "badfile.txt");

            File.WriteAllText(goodFile, "Hello World!");

            Assert.True(platformMock.FileExists(goodFile));
            Assert.False(platformMock.FileExists(badFile));
        }

        [Fact]
        public void DirectoryExists()
        {
            string goodDir = Path.Combine(testDirectory, "folder");
            string badDir = Path.Combine(testDirectory, "badfolder");

            Directory.CreateDirectory(goodDir);

            Assert.True(platformMock.DirectoryExists(goodDir));
            Assert.False(platformMock.DirectoryExists(badDir));
        }

        [Fact]
        public void WriteFile()
        {
            string file = Path.Combine(testDirectory, "file.txt");
            string contents = "Hello World!";

            Assert.False(File.Exists(file));

            Result<string> result = platformMock.WriteFile(file, contents);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));
        }

        [Fact]
        public void WriteFileExisting()
        {
            string file = Path.Combine(testDirectory, "file.txt");
            string contents = "Hello World!";
            string newContents = "The quick brown fox jumped over the lazy dog.";

            Result<string> result = platformMock.WriteFile(file, contents);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));

            result = platformMock.WriteFile(file, newContents);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));

            string readContents = File.ReadAllText(file);

            Assert.Equal(newContents, readContents);
        }

        [Fact]
        public void WriteFileFailure()
        {
            string file = Path.Combine(testDirectory, "?");

            Result result = platformMock.WriteFile(file, string.Empty);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void WriteFileLines()
        {
            string file = Path.Combine(testDirectory, "file.txt");
            string[] contents = new string[] { "Hello", "World!" };

            Assert.False(File.Exists(file));

            Result<string> result = platformMock.WriteFileLines(file, contents);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));
        }

        [Fact]
        public void WriteFileLinesExisting()
        {
            string file = Path.Combine(testDirectory, "file.txt");
            string[] contents = new string[] { "Hello", "World!" };
            string[] newContents = new string[] { "The quick brown", "fox jumped over", "the lazy dog." };

            Result<string> result = platformMock.WriteFileLines(file, contents);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));

            result = platformMock.WriteFileLines(file, newContents);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(file, result.ReturnValue);
            Assert.True(File.Exists(file));

            string[] readContents = File.ReadAllLines(file);

            Assert.Equal(newContents, readContents);
        }

        [Fact]
        public void WriteFileLinesFailure()
        {
            string file = Path.Combine(testDirectory, "?");

            Result result = platformMock.WriteFileLines(file, new string[] { });

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        [Fact]
        public void ListFiles()
        {
            string file1 = Path.Combine(testDirectory, "file1.txt");
            string file2 = Path.Combine(testDirectory, "file2.txt");
            string contents = "Hello World!";

            File.WriteAllText(file1, contents);
            File.WriteAllText(file2, contents);

            Assert.True(File.Exists(file1));
            Assert.True(File.Exists(file2));

            Result<List<string>> result = platformMock.ListFiles(testDirectory);

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(2, result.ReturnValue.Count);
            Assert.True(result.ReturnValue.Any(f => f == file1));
            Assert.True(result.ReturnValue.Any(f => f == file2));
        }

        [Fact]
        public void ListFilesFailure()
        {
            Result result = platformMock.ListFiles(Path.Combine(testDirectory, "null"));

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }
    }

    public class MockPlatform : Core.Platform.Platform
    {
        public MockPlatform() : base()
        {
            PlatformType = PlatformType.Unknown;
            Version = "1.0";
        }

        public override IConnector InstantiateConnector(string instanceName)
        {
            Connector = new Mock<IConnector>().Object;
            return Connector;
        }
    }
}