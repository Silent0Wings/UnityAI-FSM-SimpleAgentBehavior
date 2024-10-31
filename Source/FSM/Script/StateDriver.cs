using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health_Manager))]
/// <summary>
/// StateDriver is a script that will be used to manage the state of the agent and all dependencies
/// </summary>
/// <param name="StateDriver"></param>
public class StateDriver : MonoBehaviour
{
    [Tooltip("This is the instance of the scriptable object")]
    public State_Groupe _State_Groupe_Base;

    [Tooltip("This is the instance of the scriptable object")]
    public State_Groupe _State_Groupe;

    [Tooltip("This is the current state that the enemy is in")]
    public State Current_State;
    [Tooltip("This is the bool that will be used to determine if the enemy is in range")]
    public bool Is_In_Range;
    [Tooltip("This is the bool that will be used to determine if the enemy is on cooldown")]
    public bool Attack_Cooldown;
    [Tooltip("This is the bool that will be used to determine if the enemy is in attack range")]
    public bool Attack_Range;

    public List<State> State_Values = new();

    private void Awake()
    {
        _State_Groupe_Base = State_Groupe.Instance;
        if (_State_Groupe_Base != null)
        {
            // call the copy constructor 
            _State_Groupe = State_Groupe.Copy_Constructor(ref _State_Groupe_Base);

            foreach (KeyValuePair<State_Value, State> item in _State_Groupe.State_Dictionary)
            {
                State_Values.Add(item.Value);
            }
        }
    }

    void Update()
    {
        if (_State_Groupe != null)
        {
            _State_Groupe.Update_State(Is_In_Range, Attack_Cooldown, Attack_Range);
        }
    }
    private void LateUpdate()
    {
        if (_State_Groupe != null)
            Current_State = _State_Groupe.RunStateMachine(Current_State);
    }
}