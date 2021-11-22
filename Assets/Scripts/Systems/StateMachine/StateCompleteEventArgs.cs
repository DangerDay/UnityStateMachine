using System;

namespace Scripts.Systems.StateMachine
{
    public class StateCompleteEventArgs<T> : EventArgs
    {
        public T StateIdentifier { get; private set; }
        public State State { get; private set; }

        public StateCompleteEventArgs(T identifier, State state)
        {
            StateIdentifier = identifier;
            State = state;
        }
    }
}