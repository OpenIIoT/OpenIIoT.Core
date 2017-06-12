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
      █   ████████▄                                                               
      █   ███   ▀███                                                              
      █   ███    ███    ▄█████   ▄█████  █     ▄████▄  ██▄▄▄▄     ▄█████    █████ 
      █   ███    ███   ██   █    ██  ▀  ██    ██    ▀  ██▀▀▀█▄   ██   █    ██  ██ 
      █   ███    ███  ▄██▄▄      ██     ██▌  ▄██       ██   ██  ▄██▄▄     ▄██▄▄█▀ 
      █   ███    ███ ▀▀██▀▀    ▀███████ ██  ▀▀██ ███▄  ██   ██ ▀▀██▀▀    ▀███████ 
      █   ███   ▄███   ██   █     ▄  ██ ██    ██    ██ ██   ██   ██   █    ██  ██ 
      █   ████████▀    ███████  ▄████▀  █     ██████▀   █   █    ███████   ██  ██ 
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      ▄  
      █  The Windows Service class for the application.
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
namespace OpenIIoT.Core
{
    /// <summary>
    ///     The Windows Service class for the application. 
    /// </summary>
    /// <remarks>
    ///     Designer generated class.
    /// </remarks>
    partial class WindowsService
    {
        #region Private Fields

        /// <summary> 
        ///     Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #endregion Private Fields

        #region Protected Methods

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // WindowsService
            // 
            this.ServiceName = "OpenIIoT";

        }

        #endregion Private Methods
    }
}
