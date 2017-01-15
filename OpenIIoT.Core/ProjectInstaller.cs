/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                        ▄█
      █     ███    ███                                                       ███
      █     ███    ███    █████  ██████       █    ▄█████  ▄██████     ██    ███▌ ██▄▄▄▄    ▄█████     ██      ▄█████   █        █          ▄█████    █████
      █     ███    ███   ██  ██ ██    ██     ██   ██   █  ██    ██ ▀███████▄ ███▌ ██▀▀▀█▄   ██  ▀  ▀███████▄   ██   ██ ██       ██         ██   █    ██  ██
      █   ▀█████████▀   ▄██▄▄█▀ ██    ██     ██  ▄██▄▄    ██    ▀      ██  ▀ ███▌ ██   ██   ██         ██  ▀   ██   ██ ██       ██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ▀███████ ██    ██     ██ ▀▀██▀▀    ██    ▄      ██    ███  ██   ██ ▀███████     ██    ▀████████ ██       ██       ▀▀██▀▀    ▀███████
      █     ███          ██  ██ ██    ██ █▄ ▄██   ██   █  ██    ██     ██    ███  ██   ██    ▄  ██     ██      ██   ██ ██▌    ▄ ██▌    ▄   ██   █    ██  ██
      █    ▄████▀        ██  ██  ██████  ▀▀▀▀▀    ███████ ██████▀     ▄██▀   █▀    █   █   ▄████▀     ▄██▀     ██   █▀ ████▄▄██ ████▄▄██   ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The Windows Service installer for the application; allows the Windows Service to be installed and uninstalled from within the application.
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

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenIIoT.Core
{
    /// <summary>
    ///     The Windows Service installer for the application; allows the Windows Service to be installed and uninstalled from
    ///     within the application.
    /// </summary>
    /// <remarks>Designer generated class.</remarks>
    [RunInstaller(true)]
    [ExcludeFromCodeCoverage]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectInstaller"/> class.
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        #endregion Public Constructors
    }
}