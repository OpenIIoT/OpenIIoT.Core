/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ███    █▄
      █   ███    ███
      █   ███    ███     ██     █   █        █      ██    ▄█   ▄
      █   ███    ███ ▀███████▄ ██  ██       ██  ▀███████▄ ██   █▄
      █   ███    ███     ██  ▀ ██▌ ██       ██▌     ██  ▀ ▀▀▀▀▀██
      █   ███    ███     ██    ██  ██       ██      ██    ▄█   ██
      █   ███    ███     ██    ██  ██▌    ▄ ██      ██    ██   ██
      █   ████████▀     ▄██▀   █   ████▄▄██ █      ▄██▀    █████
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
      █  Unit tests for the Utility class.
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
using NLog;
using NLog.Targets;
using Xunit;

namespace OpenIIoT.Core.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Utility"/> class.
    /// </summary>
    [Collection("Utility")]
    public class Utility
    {
        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Core.Utility.DisableLoggingLevel(LogLevel)"/> method.
        /// </summary>
        [Fact]
        public void DisableLoggingLevel()
        {
            Target target = new ConsoleTarget();
            LogManager.Configuration.AddTarget("test", target);
            LogManager.Configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, target);

            Logger logger = LogManager.GetLogger("test");

            Core.Utility.EnableLoggingLevel(LogLevel.Info);

            Assert.True(logger.IsInfoEnabled);

            Core.Utility.DisableLoggingLevel(LogLevel.Info);

            Assert.False(logger.IsInfoEnabled);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Utility.EnableLoggingLevel(LogLevel)"/> method.
        /// </summary>
        [Fact]
        public void EnableLoggingLevel()
        {
            Target target = new ConsoleTarget();
            LogManager.Configuration.AddTarget("test", target);
            LogManager.Configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, target);

            Logger logger = LogManager.GetLogger("test");

            Core.Utility.DisableLoggingLevel(LogLevel.Info);

            Assert.False(logger.IsInfoEnabled);

            Core.Utility.EnableLoggingLevel(LogLevel.Info);

            Assert.True(logger.IsInfoEnabled);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Utility.GetSetting(string, string)"/> method overloads.
        /// </summary>
        [Fact]
        public void GetSettingSubstitution()
        {
            Assert.Equal("default", Core.Utility.GetSetting("InstanceName", "default"));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Utility.PrintLogo(Logger)"/> method.
        /// </summary>
        [Fact]
        public void PrintLogo()
        {
            Target target = new ConsoleTarget();
            LogManager.Configuration.AddTarget("test", target);
            LogManager.Configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, target);
            Logger logger = LogManager.GetLogger("test");

            Core.Utility.PrintLogo(logger);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Utility.PrintLogoFooter(Logger)"/> method.
        /// </summary>
        [Fact]
        public void PrintLogoFooter()
        {
            Target target = new ConsoleTarget();
            LogManager.Configuration.AddTarget("test", target);
            LogManager.Configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, target);
            Logger logger = LogManager.GetLogger("test");

            Core.Utility.PrintLogoFooter(logger);
        }

        /// <summary>
        ///     Tests the
        ///     <see cref="Core.Utility.PrintModel(Logger, SDK.Common.Item, int, System.Collections.Generic.List{bool}, bool)"/> method.
        /// </summary>
        [Fact]
        public void PrintModel()
        {
            Target target = new ConsoleTarget();
            LogManager.Configuration.AddTarget("test", target);
            LogManager.Configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, target);
            Logger logger = LogManager.GetLogger("test");

            SDK.Common.Item root = new SDK.Common.Item("Root");
            SDK.Common.Item child1 = new SDK.Common.Item("Child1");
            SDK.Common.Item child2 = new SDK.Common.Item("Child2");

            root.AddChild(child1);
            root.AddChild(child2);

            Core.Utility.PrintModel(logger, root, 0);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Utility.SetLoggingLevel(string)"/> method.
        /// </summary>
        [Fact]
        public void SetLoggingLevel()
        {
            Target target = new ConsoleTarget();
            LogManager.Configuration.AddTarget("test", target);
            LogManager.Configuration.AddRule(LogLevel.Trace, LogLevel.Fatal, target);

            foreach (var rule in LogManager.Configuration.LoggingRules)
            {
                rule.EnableLoggingForLevel(LogLevel.Trace);
                rule.EnableLoggingForLevel(LogLevel.Debug);
                rule.EnableLoggingForLevel(LogLevel.Info);
                rule.EnableLoggingForLevel(LogLevel.Error);
                rule.EnableLoggingForLevel(LogLevel.Fatal);
            }

            LogManager.ReconfigExistingLoggers();

            Logger logger = LogManager.GetLogger("test");

            Assert.True(logger.IsTraceEnabled);
            Assert.True(logger.IsDebugEnabled);
            Assert.True(logger.IsInfoEnabled);
            Assert.True(logger.IsErrorEnabled);
            Assert.True(logger.IsFatalEnabled);

            Core.Utility.SetLoggingLevel("fatal");

            Assert.False(logger.IsTraceEnabled);
            Assert.False(logger.IsDebugEnabled);
            Assert.False(logger.IsInfoEnabled);
            Assert.False(logger.IsErrorEnabled);
            Assert.True(logger.IsFatalEnabled);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Utility.SetLoggingLevel(string)"/> method with a known bad level.
        /// </summary>
        [Fact]
        public void SetLoggingLevelBad()
        {
            Exception ex = Record.Exception(() => Core.Utility.SetLoggingLevel("bad"));

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Utility.UpdateSetting(string, string)"/> method.
        /// </summary>
        [Fact]
        public void UpdateSettingBad()
        {
            Exception ex = Record.Exception(() => Core.Utility.UpdateSetting("key", "value"));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        #endregion Public Methods
    }
}