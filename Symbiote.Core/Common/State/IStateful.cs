using System;

namespace Symbiote.Core
{
    public interface IStateful
    {
        #region Properties

        State State { get; }

        #endregion

        #region Events

        event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion
    }
}
