using Scripts.Systems.StateMachine;
using UnityEngine;

public class ExampleState3 : State
{
    public override void Initialize()
    {
        Debug.Log("State 3 initialized");
    }

    public override void Load()
    {
        Debug.Log("State 3 loaded");
    }

    public override void Unload()
    {
        Debug.Log("State 3 unloaded");
    }
}