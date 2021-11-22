using Scripts.Systems.StateMachine;
using UnityEngine;

public class ExampleState1 : State
{
    public override void Initialize()
    {
        Debug.Log("State 1 initialized");
    }

    public override void Load()
    {
        Debug.Log("State 1 loaded");
    }

    public override void Unload()
    {
        Debug.Log("State 1 unloaded");
    }
}