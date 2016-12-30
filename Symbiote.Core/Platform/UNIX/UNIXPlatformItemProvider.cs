/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ███    █▄  ███▄▄▄▄    ▄█  ▀████    ▐████▀    ▄███████▄
      █   ███    ███ ███▀▀▀██▄ ███    ███▌   ████▀    ███    ███
      █   ███    ███ ███   ███ ███▌    ███  ▐███      ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄
      █   ███    ███ ███   ███ ███▌    ▀███▄███▀      ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄
      █   ███    ███ ███   ███ ███▌    ████▀██▄     ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██
      █   ███    ███ ███   ███ ███     ▐███  ▀███     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██
      █   ███    ███ ███   ███ ███   ▄███     ███▄    ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██
      █   ████████▀   ▀█   █▀  █▀   ████       ███▄  ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █
      █
      █    ▄█                                     ▄███████▄
      █   ███                                    ███    ███
      █   ███▌     ██       ▄█████    ▄▄██▄▄▄    ███    ███    █████  ██████   █    █   █  ██████▄     ▄█████    █████
      █   ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄   ███    ███   ██  ██ ██    ██ ██    ██ ██  ██   ▀██   ██   █    ██  ██
      █   ███▌     ██  ▀  ▄██▄▄     ██  ██  ██ ▀█████████▀   ▄██▄▄█▀ ██    ██ ██    ██ ██▌ ██    ██  ▄██▄▄     ▄██▄▄█▀
      █   ███      ██    ▀▀██▀▀     ██  ██  ██   ███        ▀███████ ██    ██ ██    ██ ██  ██    ██ ▀▀██▀▀    ▀███████
      █   ███      ██      ██   █   ██  ██  ██   ███          ██  ██ ██    ██  █▄  ▄█  ██  ██   ▄██   ██   █    ██  ██
      █   █▀      ▄██▀     ███████   █  ██  █   ▄████▀        ██  ██  ██████    ▀██▀   █   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Provides Platform statistics and metrics for the UNIX Platform on which the application is run.
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

using System.Diagnostics;
using System.Threading.Tasks;
using Symbiote.SDK;
using Utility.OperationResult;

namespace Symbiote.Core.Platform.UNIX
{
    /// <summary>
    ///     Provides Platform statistics and metrics for the UNIX Platform on which the application is run.
    /// </summary>
    public class UNIXPlatformItemProvider : ItemProvider
    {
        #region Private Fields

        /// <summary>
        ///     PerformanceCounter for the CPU % Idle Time counter.
        /// </summary>
        private PerformanceCounter cpuIdle;

        /// <summary>
        ///     PerformanceCounter for the CPU % Processor Time counter.
        /// </summary>
        private PerformanceCounter cpuUsed;

        /// <summary>
        ///     The last retrieved value for the CPU % Idle Time PerformanceCounter.
        /// </summary>
        private double lastCPUIdle;

        /// <summary>
        ///     The last retrieved value for the CPU % Processor Time PerformanceCounter.
        /// </summary>
        private double lastCPUUsed;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UNIXPlatformItemProvider"/> class.
        /// </summary>
        public UNIXPlatformItemProvider()
        {
            cpuUsed = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuIdle = new PerformanceCounter("Processor", "% Idle Time", "_Total");

            ItemProviderName = "Platform";

            InitializeItems();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Reads and returns the current value of the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>A Result containing the result of the operation and the current value of the Item.</returns>
        public override Result<object> Read(Item item)
        {
            Result<object> retVal = new Result<object>();

            string[] itemName = item.FQN.Split('.');

            if (itemName.Length < 3)
            {
                return null;
            }

            switch (itemName[itemName.Length - 2] + "." + itemName[itemName.Length - 1])
            {
                case "CPU.% Processor Time":
                    lastCPUUsed = cpuUsed.NextValue();
                    lastCPUIdle = cpuIdle.NextValue();
                    retVal.ReturnValue = lastCPUUsed;
                    return retVal;

                case "CPU.% Idle Time":
                    lastCPUUsed = cpuUsed.NextValue();
                    lastCPUIdle = cpuIdle.NextValue();
                    retVal.ReturnValue = lastCPUIdle;
                    return retVal;

                case "Memory.Total":
                    retVal.ReturnValue = 0;
                    return retVal;

                case "Memory.Available":
                    retVal.ReturnValue = new PerformanceCounter("Memory", "Available Bytes").NextValue();
                    return retVal;

                case "Memory.Cached":
                    retVal.ReturnValue = new PerformanceCounter("Memory", "Cache Bytes").NextValue();
                    return retVal;

                case "Memory.% Used":
                    retVal.ReturnValue = new PerformanceCounter("Memory", "% Committed Bytes In Use").NextValue();
                    return retVal;

                default:
                    return retVal.AddError("Unable to find Item '" + item + "'.");
            }
        }

        /// <summary>
        ///     Asynchronously reads and returns the current value of the specified <see cref="Item"/>
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>A Result containing the result of the operation and the current value of the Item.</returns>
        public override async Task<Result<object>> ReadAsync(Item item)
        {
            return await Task.Run(() => Read(item));
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Initializes the <see cref="Item"/> tree.
        /// </summary>
        private void InitializeItems()
        {
            // instantiate an item root
            ItemRoot = new Item(ItemProviderName);

            // create CPU items
            Item cpuRoot = ItemRoot.AddChild(new Item("CPU")).ReturnValue;
            cpuRoot.AddChild(new Item("CPU.% Processor Time"));
            cpuRoot.AddChild(new Item("CPU.% Idle Time"));

            // prepare variables to use for processor time. you need two successive values to report accurately so rather than
            // sleeping the thread we will just keep track from call to call. the first values will always be zero and that's ok.
            lastCPUUsed = 0;
            lastCPUIdle = 0;

            // create memory items
            Item memRoot = ItemRoot.AddChild(new Item("Memory")).ReturnValue;
            memRoot.AddChild(new Item("Memory.Total"));
            memRoot.AddChild(new Item("Memory.Available"));
            memRoot.AddChild(new Item("Memory.Cached"));
            memRoot.AddChild(new Item("Memory.% Used"));

            // create drive items
            Item driveRoot = ItemRoot.AddChild(new Item("Drives")).ReturnValue;

            // system drive
            Item sysDriveRoot = driveRoot.AddChild(new Item("Drives.System")).ReturnValue;
            sysDriveRoot.AddChild(new Item("Drives.System.Name"));
            sysDriveRoot.AddChild(new Item("Path"));
            sysDriveRoot.AddChild(new Item("Type"));
            sysDriveRoot.AddChild(new Item("Capacity"));
            sysDriveRoot.AddChild(new Item("UsedSpace"));
            sysDriveRoot.AddChild(new Item("FreeSpace"));
            sysDriveRoot.AddChild(new Item("PercentUsed"));
            sysDriveRoot.AddChild(new Item("PercentFree"));

            // data drive
            Item dataDriveRoot = driveRoot.AddChild(new Item("Data")).ReturnValue;
            dataDriveRoot.AddChild(new Item("Name"));
            dataDriveRoot.AddChild(new Item("Path"));
            dataDriveRoot.AddChild(new Item("Type"));
            dataDriveRoot.AddChild(new Item("Capacity"));
            dataDriveRoot.AddChild(new Item("UsedSpace"));
            dataDriveRoot.AddChild(new Item("FreeSpace"));
            dataDriveRoot.AddChild(new Item("PercentUsed"));
            dataDriveRoot.AddChild(new Item("PercentFree"));
        }

        #endregion Private Methods
    }
}