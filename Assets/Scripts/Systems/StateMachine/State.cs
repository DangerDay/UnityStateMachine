using System;
using UnityEngine;

namespace Scripts.Systems.StateMachine
{
    [Serializable]
    public abstract class State : MonoBehaviour
    {
        /// <summary>
        /// Called once at startup. See Load for setting the current state.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Called every time the State is set.
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Called when the State completes.
        /// </summary>
        public abstract void Unload();

        /// <summary>
        /// This is for the StateMachine to know when the State has completed.
        /// Subscribe to StateMachine's StateCompleteEvent to receive the same event from every state.
        /// </summary>
        public event EventHandler StateCompleteEvent;

        public bool Initialized { get; internal set; }

        private void Awake()
        {
            // Need to check this here because this can be triggered by the statemachine itself 
            // if the state is called before unity has finished initialization. 
            if (Initialized)
                return;

            Initialize();

            Initialized = true;
        }

        internal void StateComplete()
        {
            StateCompleteEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}