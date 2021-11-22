#define DEBUGSTATES
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.StateMachine
{
    /// <summary>
    /// A general purpose state machine. States are paired with a StateIdentifier
    /// so that types don't have to get involved with basic functionality (ie: checking current state).
    /// See ExampleScript.cs for basic setup.
    /// </summary>
    public class StateMachine<T1, T2> where T1 : struct, IConvertible where T2 : State
    {
        /// <summary>
        /// The current state's identifier, see CurrentState for the State itself.
        /// </summary>
        public T1 CurrentStateIdentifier { get; private set; }

        /// <summary>
        /// The currently active State.
        /// </summary>
        public T2 CurrentState { get; private set; }

        /// <summary>
        /// Subscribe to know when the CurrentState is complete.
        /// In the current setup states tell the statemachine when they're done.
        /// </summary>
        public EventHandler<StateCompleteEventArgs<T1>> StateCompleteEvent;

        /// <summary>
        /// State's are paired with their identifier here.
        /// </summary>
        private Dictionary<T1, T2> stateDictionary = new Dictionary<T1, T2>();

        public void AssignState(T1 identifier, T2 state)
        {
            if (state == null)
            {
                Debug.LogError("Assigned a null state to identifier " + identifier.ToString());
                return;
            }

            if (stateDictionary.ContainsKey(identifier))
            {
                Debug.LogError(identifier.ToString() + " has already been assigned, please assign " + state.ToString() + " to a new state identifier");
                return;
            }

            stateDictionary.Add(identifier, state);
            state.StateCompleteEvent += State_StateCompleteEvent;
        }

        public void SetState(T1 identifier)
        {
            // make sure the identifier has been assigned a state
            if (!stateDictionary.ContainsKey(identifier))
            {
#if DEBUGSTATES
                Debug.LogError("State identifier " + identifier.ToString() + " missing from " + this.ToString());
#endif
                return;
            }

            // there is no current state if this is the first one being set
            if (CurrentState != null)
            {
                // if this state is already loaded stop here
                if (CurrentStateIdentifier.Equals(identifier))
                {
                    Debug.LogError(identifier.ToString() + " is already loaded and is the current state");
                    return;
                }
#if DEBUGSTATES
                Debug.Log("Unloading State: " + CurrentStateIdentifier.ToString());
#endif

                CurrentState.Unload();
            }

            CurrentState = stateDictionary[identifier];
            CurrentStateIdentifier = identifier;

            // check if the current state has been initialized first,
            // this can happen if the state is being assigned from awake
            if (!CurrentState.Initialized)
            {
                CurrentState.Initialize();
                CurrentState.Initialized = true;
            }

#if DEBUGSTATES
            Debug.Log("Loading State: " + identifier);
#endif

            CurrentState.Load();
        }

        private void State_StateCompleteEvent(object sender, EventArgs e)
        {
            StateCompleteEvent?.Invoke(this, new StateCompleteEventArgs<T1>(CurrentStateIdentifier, CurrentState));
        }
    }
}