﻿/*
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
      █  The Windows Service class for the application.  Designer generated class.
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
namespace Symbiote.Core
{
    /// <summary>
    ///     The Windows Service class for the application.  Designer generated class.
    /// </summary>
    partial class WindowsService
    {
        /// <summary> 
        ///     Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "WindowsService";
        }

        #endregion
    }
}
