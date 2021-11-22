using Scripts.Systems.StateMachine;
using UnityEngine;

public class ExampleState2 : State
{
    public override void Initialize()
    {
        Debug.Log("State 2 initialized");
    }

    public override void Load()
    {
        Debug.Log("State 2 loaded");
    }

    public override void Unload()
    {
        Debug.Log("State 2 unloaded");
    }
}