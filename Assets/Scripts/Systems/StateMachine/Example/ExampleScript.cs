using Scripts.Systems.StateMachine;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public ExampleState1 ExampleState1;
    public ExampleState2 ExampleState2;
    public ExampleState3 ExampleState3;

    private StateMachine<ExampleStateIdentifier, State> stateMachine = new StateMachine<ExampleStateIdentifier, State>();

    private void Start ()
    {
        // setup state machine
        stateMachine.AssignState(ExampleStateIdentifier.State1, ExampleState1);
        stateMachine.AssignState(ExampleStateIdentifier.State2, ExampleState2);
        stateMachine.AssignState(ExampleStateIdentifier.State3, ExampleState3);

        // set a state to start off with
        stateMachine.SetState(ExampleStateIdentifier.State1);

        Debug.Log("Press 1-3 to change the state");
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stateMachine.SetState(ExampleStateIdentifier.State1);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            stateMachine.SetState(ExampleStateIdentifier.State2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stateMachine.SetState(ExampleStateIdentifier.State3);
        }
    }
}
