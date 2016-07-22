/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█     █▄                                                      ▄████████                                                    
      █   ███     ███                                                    ███    ███                                                    
      █   ███     ███  █  ██▄▄▄▄  ██████▄   ██████   █     █    ▄█████   ███    █▀     ▄█████    █████  █    █   █   ▄██████    ▄█████ 
      █   ███     ███ ██  ██▀▀▀█▄ ██   ▀██ ██    ██ ██     ██   ██  ▀    ███          ██   █    ██  ██ ██    ██ ██  ██    ██   ██   █  
      █   ███     ███ ██▌ ██   ██ ██    ██ ██    ██ ██     ██   ██     ▀███████████  ▄██▄▄     ▄██▄▄█▀ ██    ██ ██▌ ██    ▀   ▄██▄▄    
      █   ███     ███ ██  ██   ██ ██    ██ ██    ██ ██     ██ ▀███████          ███ ▀▀██▀▀    ▀███████ ██    ██ ██  ██    ▄  ▀▀██▀▀    
      █   ███ ▄█▄ ███ ██  ██   ██ ██   ▄██ ██    ██ ██ ▄█▄ ██    ▄  ██    ▄█    ███   ██   █    ██  ██  █▄  ▄█  ██  ██    ██   ██   █  
      █    ▀███▀███▀  █    █   █  ██████▀   ██████   ███▀███   ▄████▀   ▄████████▀    ███████   ██  ██   ▀██▀   █   ██████▀    ███████ 
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      ▄  
      █  The Windows Service class for the application.
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
using System.ServiceProcess;

namespace Symbiote.Core
{
    /// <summary>
    /// The Windows Service class for the application.
    /// </summary>
    partial class WindowsService : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsService"/> class.
        /// </summary>
        public WindowsService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the service is started.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            // set the working directory for the application to the location of the executable.
            // if this is not set here, the application believes it is running from %windir%\system32\.
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
            Program.Start(args);
        }

        /// <summary>
        /// Invoked when the service is stopped.
        /// </summary>
        protected override void OnStop()
        {
            Program.Stop();
        }
    }
}
