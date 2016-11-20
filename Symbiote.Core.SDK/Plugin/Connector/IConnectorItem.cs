/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █   ▄████████                                                                           ▄█                                  
      █   ███    ███                                                                         ███                                  
      █   ███    █▀   ██████  ██▄▄▄▄  ██▄▄▄▄     ▄█████  ▄██████     ██     ██████     █████ ███▌     ██       ▄█████    ▄▄██▄▄▄  
      █   ███        ██    ██ ██▀▀▀█▄ ██▀▀▀█▄   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██ ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄ 
      █   ███        ██    ██ ██   ██ ██   ██  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ███▌     ██  ▀  ▄██▄▄     ██  ██  ██ 
      █   ███    █▄  ██    ██ ██   ██ ██   ██ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████ ███      ██    ▀▀██▀▀     ██  ██  ██ 
      █   ███    ███ ██    ██ ██   ██ ██   ██   ██   █  ██    ██     ██    ██    ██   ██  ██ ███      ██      ██   █   ██  ██  ██ 
      █   ████████▀   ██████   █   █   █   █    ███████ ██████▀     ▄██▀    ██████    ██  ██ █▀      ▄██▀     ███████   █  ██  █  
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  ConnectorItem is an extension of the Item class.  This class represents Items that are provided by Connector Plugins. 
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using Newtonsoft.Json;
using NLog;
using Symbiote.Core.SDK;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.SDK.Plugin.Connector
{
    public interface IConnectorItem : IItem
    {
        #region Properties

        /// <summary>
        ///     The <see cref="IConnector"/> instance to which this <see cref="Item"/> belongs.
        /// </summary>
        [JsonIgnore]
        IConnector Connector { get; }

        #endregion
    }
}
