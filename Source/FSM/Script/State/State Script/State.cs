using UnityEngine;
/// <summary>
/// State_Value is an enum that will be used to determine the current state of the enemy
/// </summary>
[System.Serializable]
public enum State_Value
{
    None = 0,
    Idle = 1,
    Attack = 2,
    Chase = 3,
    Run = 4,
    Die = 5,
    Revive = 6,
    Patrol = 7,
    wander = 8,
    follow = 9
}
/// <summary>
/// State is a scriptable object that will be used to create states for the state machine
/// </summary>
public abstract class State : ScriptableObject
{
    [Tooltip("This is the value of the state")]
    public readonly State_Value The_State_Value;

    // Base class constructor
    protected State(State_Value stateValue)
    {
        The_State_Value = stateValue;
    }

    /// <summary>
    /// CurrentState is a function that will be used to determine the next state this is a virtual function that will be overridden
    /// </summary>
    /// <returns></returns>
    public abstract State CurrentState(State_Groupe _State_Groupe);
}
