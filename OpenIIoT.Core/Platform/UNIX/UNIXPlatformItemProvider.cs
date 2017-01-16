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
using OpenIIoT.SDK;
using Utility.OperationResult;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Provider.ItemProvider;

namespace OpenIIoT.Core.Platform.UNIX
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
        public UNIXPlatformItemProvider(string itemProviderName) : base(itemProviderName)
        {
            cpuUsed = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuIdle = new PerformanceCounter("Processor", "% Idle Time", "_Total");

            InitializeItems();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Reads and returns the current value of the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>The value of the specified Item.</returns>
        public override object Read(Item item)
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
        /// <returns>The value of the specified Item.</returns>
        public override async Task<object> ReadAsync(Item item)
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
            ItemRoot = new Item(ItemProviderName, this);

            // create CPU items
            Item cpuRoot = ItemRoot.AddChild(new Item("CPU", this)).ReturnValue;
            cpuRoot.AddChild(new Item("CPU.% Processor Time", this));
            cpuRoot.AddChild(new Item("CPU.% Idle Time", this));

            // prepare variables to use for processor time. you need two successive values to report accurately so rather than
            // sleeping the thread we will just keep track from call to call. the first values will always be zero and that's ok.
            lastCPUUsed = 0;
            lastCPUIdle = 0;

            // create memory items
            Item memRoot = ItemRoot.AddChild(new Item("Memory", this)).ReturnValue;
            memRoot.AddChild(new Item("Memory.Total", this));
            memRoot.AddChild(new Item("Memory.Available", this));
            memRoot.AddChild(new Item("Memory.Cached", this));
            memRoot.AddChild(new Item("Memory.% Used", this));

            // create drive items
            Item driveRoot = ItemRoot.AddChild(new Item("Drives", this)).ReturnValue;

            // system drive
            Item sysDriveRoot = driveRoot.AddChild(new Item("Drives.System", this)).ReturnValue;
            sysDriveRoot.AddChild(new Item("Drives.System.Name", this));
            sysDriveRoot.AddChild(new Item("Path", this));
            sysDriveRoot.AddChild(new Item("Type", this));
            sysDriveRoot.AddChild(new Item("Capacity", this));
            sysDriveRoot.AddChild(new Item("UsedSpace", this));
            sysDriveRoot.AddChild(new Item("FreeSpace", this));
            sysDriveRoot.AddChild(new Item("PercentUsed", this));
            sysDriveRoot.AddChild(new Item("PercentFree", this));

            // data drive
            Item dataDriveRoot = driveRoot.AddChild(new Item("Data", this)).ReturnValue;
            dataDriveRoot.AddChild(new Item("Name", this));
            dataDriveRoot.AddChild(new Item("Path", this));
            dataDriveRoot.AddChild(new Item("Type", this));
            dataDriveRoot.AddChild(new Item("Capacity", this));
            dataDriveRoot.AddChild(new Item("UsedSpace", this));
            dataDriveRoot.AddChild(new Item("FreeSpace", this));
            dataDriveRoot.AddChild(new Item("PercentUsed", this));
            dataDriveRoot.AddChild(new Item("PercentFree", this));
        }

        #endregion Private Methods
    }
}