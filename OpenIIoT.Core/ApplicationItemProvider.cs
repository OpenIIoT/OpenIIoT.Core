using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Provider.ItemProvider;
using OpenIIoT.SDK;

namespace OpenIIoT.Core
{
    /// <summary>
    ///     Provides Platform statistics and metrics for the Windows Platform on which the application is run.
    /// </summary>
    public class ApplicationItemProvider : ItemProvider
    {
        #region Private Fields

        /// <summary>
        ///     The dictionary of <see cref="Func{T}"/> delegates for each Item.
        /// </summary>
        private Dictionary<string, Func<object>> actions;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationItemProvider"/> class.
        /// </summary>
        /// <param name="itemProviderName">The name of the Item Provider.</param>
        public ApplicationItemProvider(string itemProviderName)
            : base(itemProviderName)
        {
            actions = new Dictionary<string, Func<object>>();

            InitializeItems();
        }

        #endregion Public Constructors

        IApplicationManager Manager => ApplicationManager.GetInstance();

        #region Public Methods

        /// <summary>
        ///     Reads and returns the current value of the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>The value of the specified Item.</returns>
        public override object Read(Item item)
        {
            object retVal = default(object);

            if (actions.ContainsKey(item.FQN))
            {
                return actions[item.FQN]();
            }

            return retVal;
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
            Item instance = ItemRoot.AddChild(new Item("InstanceName", this)).ReturnValue;

            actions.Add(instance.FQN, () => { return Manager.InstanceName; });

            Item productName = ItemRoot.AddChild(new Item("ProductName", ItemAccessMode.ReadOnly, this)).ReturnValue;

            actions.Add(productName.FQN, () => { return Manager.ProductName; });

            Item productVersion = ItemRoot.AddChild(new Item("ProductVersion", ItemAccessMode.ReadOnly, this)).ReturnValue;

            actions.Add(productVersion.FQN, () => { return Manager.ProductVersion.ToString(); });

            Item state = ItemRoot.AddChild(new Item("State", ItemAccessMode.ReadOnly, this)).ReturnValue;

            actions.Add(state.FQN, () => { return Manager.State; });
        }

        #endregion Private Methods
    }
}