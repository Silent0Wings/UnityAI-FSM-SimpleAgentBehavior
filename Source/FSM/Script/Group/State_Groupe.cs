using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State_Group", menuName = "New State/State_Group")]
/// <summary>
/// state Groupe is a scriptable object that will be used to create a link that establishes states for the state machine
/// </summary>
/// /// <param name="State_Groupe"></param>
public class State_Groupe : ScriptableObject
{
    #region Bool
    public Bool_Settings _Bool_Settings;
    #endregion

    #region Data
    [Tooltip("This is the dictionary that will store the states")]
    public Dictionary<State_Value, State> State_Dictionary = new();
    public List<State> State_Values = new();
    [Tooltip("State Groupe Static Instance")]
    public static State_Groupe Instance;
    [Tooltip("Health Instance")]
    public Health Health_Instance;
    #endregion

    public uint Dic_Val = 0;


    private void OnValidate()
    {
        Initialize();
    }
    private void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize the dictionary and link the instance to this script
    /// </summary>
    private void Initialize()
    {
        Instance = this;
        foreach (State item in State_Values)
        {
            if (!State_Dictionary.ContainsKey(item.The_State_Value))
            {
                State_Dictionary.Add(item.The_State_Value, item);
            }
        }
        Dic_Val = (uint)State_Dictionary.Count;
    }
    /// <summary>
    /// Run the state machine and return the current state 
    /// </summary>
    /// <param name="Current_State"></param>
    /// <returns></returns>
    public State RunStateMachine(State Current_State)
    {
        if (Current_State == null || Health_Instance == null) // if the current state is null, then set the current state to the idle state
        {

            if (Health_Instance != null && Health_Instance._Health_Parameters.Is_Dead)
            {
                if (_Bool_Settings.Revive)
                {
                    Current_State = State_Dictionary[State_Value.Revive];
                }
                else
                {
                    Current_State = State_Dictionary[State_Value.Die];
                }
            }
            else
            {
                Current_State = State_Dictionary[State_Value.Idle];
            }
        }
        else // if the current state is not null, then run the current state
        {
            State Next_State = Current_State?.CurrentState(this); // if current state is null, then return null if not then return the next state that will be established inside the scriptable object
            if (Next_State != null) // if the next state is not null
            {
                if (Health_Instance._Health_Parameters.Is_Dead && Next_State.The_State_Value != State_Value.Die && Next_State.The_State_Value != State_Value.Revive)
                {
                    Next_State = State_Dictionary[State_Value.Die];
                }
            }

            if (Current_State != Next_State)
            {
                Current_State = Next_State;
            }
        }

        return Current_State;
    }
    /// <summary>
    /// Update the states externally
    /// </summary>
    /// <param name="is_in_range"></param>
    /// <param name="attack_cooldown"></param>
    /// <param name="attack_range"></param>
    public void Update_State(bool is_in_range, bool attack_cooldown, bool attack_range)
    {
        _Bool_Settings.Is_In_Range = is_in_range;
        _Bool_Settings.Attack_Cooldown = attack_cooldown;
        _Bool_Settings.Attack_Range = attack_range;
    }
    #region Constructor    
    // Default Constructor
    public State_Groupe()
    {
        _Bool_Settings = new Bool_Settings();
    }

    /// <summary>
    /// Copy Constructor
    /// </summary>
    /// <returns></returns>
    public State_Groupe Copy_Constructor()
    {
        State_Groupe state_Groupe = new();

        foreach (KeyValuePair<State_Value, State> item in State_Dictionary)
        {
            if (!state_Groupe.State_Dictionary.ContainsKey(item.Key))
            {
                state_Groupe.State_Dictionary.Add(item.Key, item.Value);
            }
        }

        state_Groupe._Bool_Settings.Assign(this._Bool_Settings);

        state_Groupe.State_Dictionary = this.State_Dictionary;
        state_Groupe.Health_Instance = this.Health_Instance;
        return state_Groupe;

    }
    /// <summary>
    /// Copy Constructor
    /// </summary>
    /// <param name="Base"></param>
    /// <returns></returns>
    public static State_Groupe Copy_Constructor(ref State_Groupe Base)
    {
        if (Base == null)
        {
            return null;
        }
        else
        {
            State_Groupe state_Groupe = ScriptableObject.CreateInstance<State_Groupe>();
            state_Groupe.name = Base.name + Time.fixedTime;

            foreach (KeyValuePair<State_Value, State> item in Base.State_Dictionary)
            {
                if (!state_Groupe.State_Dictionary.ContainsKey(item.Key))
                {
                    state_Groupe.State_Dictionary.Add(item.Key, item.Value);
                }
            }
            if (state_Groupe._Bool_Settings != null)
                state_Groupe._Bool_Settings.Assign(Base._Bool_Settings);

            state_Groupe.State_Dictionary = Base.State_Dictionary;
            state_Groupe.Health_Instance = Base.Health_Instance;
            return state_Groupe;
        }
    }
    #endregion 
}
[System.Serializable]
public class Bool_Settings
{
    [Header("Bool Settings")]
    [Tooltip("Is the agent in range to take action?")]
    public bool Is_In_Range;

    [Tooltip("Is the agent on cooldown before another attack?")]
    public bool Attack_Cooldown;

    [Tooltip("Is the agent within attack range of the player?")]
    public bool Attack_Range;

    [Tooltip("Is the agent currently in a 'Revive' state?")]
    public bool Revive;

    [Tooltip("Can the agent chase the player?")]
    public bool Can_Chase;

    [Tooltip("Can the agent attack the player?")]
    public bool Can_Attack;

    [Tooltip("Can the agent run away from the player?")]
    public bool Can_Run;

    [Tooltip("Can the agent wander around the area?")]
    public bool Can_Wander;

    [Tooltip("Can the agent patrol a specific area?")]
    public bool Can_Patrol;

    [Tooltip("Can the agent run from the player?")]
    public bool can_Run;

    [Tooltip("Can the agent follow the player?")]
    public bool Can_Follow;
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Bool_Settings()
    {
        Is_In_Range = false;
        Attack_Cooldown = false;
        Attack_Range = false;
        Revive = false;
        Can_Chase = true;
        Can_Attack = true;
        Can_Run = false;
        Can_Wander = false;
        Can_Patrol = false;
        Can_Follow = false;
    }
    /// <summary>
    /// Parameterized constructor
    /// </summary>
    /// <param name="val"></param>
    public Bool_Settings(bool val)
    {
        Is_In_Range = val;
        Attack_Cooldown = val;
        Attack_Range = val;
        Revive = val;
        Can_Chase = val;
        Can_Attack = val;
        Can_Run = val;
        Can_Wander = val;
        Can_Patrol = val;
        can_Run = val;
        Can_Follow = val;
    }
    /// <summary>
    /// Copy Constructor
    /// </summary>
    /// <param name="val"></param>
    public Bool_Settings(Bool_Settings val)
    {
        Is_In_Range = val.Is_In_Range;
        Attack_Cooldown = val.Attack_Cooldown;
        Attack_Range = val.Attack_Range;
        Revive = val.Revive;
        Can_Chase = val.Can_Chase;
        Can_Attack = val.Can_Attack;
        Can_Run = val.Can_Run;
        Can_Wander = val.Can_Wander;
        Can_Patrol = val.Can_Patrol;
        can_Run = val.can_Run;
        Can_Follow = val.Can_Follow;
    }
    /// <summary>
    /// Assign the values of the bools from another instance
    /// </summary>
    /// <param name="val"></param>
    public void Assign(Bool_Settings val)
    {
        Is_In_Range = val.Is_In_Range;
        Attack_Cooldown = val.Attack_Cooldown;
        Attack_Range = val.Attack_Range;
        Revive = val.Revive;
        Can_Chase = val.Can_Chase;
        Can_Attack = val.Can_Attack;
        Can_Run = val.Can_Run;
        Can_Wander = val.Can_Wander;
        Can_Patrol = val.Can_Patrol;
        can_Run = val.can_Run;
        Can_Follow = val.Can_Follow;
    }
    /// <summary>
    /// Reset some the bools to false
    /// </summary>
    public void Reset()
    {
        Is_In_Range = false;
        Attack_Cooldown = false;
        Attack_Range = false;
        Revive = false;
    }
}