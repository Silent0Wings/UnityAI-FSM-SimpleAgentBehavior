using UnityEngine;

[CreateAssetMenu(fileName = "Run_State", menuName = "New State/Run_State")]
/// <summary>
///  Run_State is the implementation of the running behavior
/// </summary>
/// <param name="Run_State"></param>
public class Run_State : State
{
    public Run_State() : base(State_Value.Run)
    {
    }

    public override State CurrentState(State_Groupe _State_Groupe)
    {
        if (_State_Groupe == null)
        {
            _State_Groupe = State_Groupe.Instance;
            if (_State_Groupe == null)
            {
                return null;
            }
        }

        if (_State_Groupe.Health_Instance._Health_Parameters.Can_Damage || _State_Groupe.Health_Instance._Health_Parameters.Can_Heal)
        {
            if (_State_Groupe.Health_Instance._Health_Parameters.low_health)
            {
                if (_State_Groupe._Bool_Settings.Is_In_Range || _State_Groupe._Bool_Settings.Attack_Range)
                {
                    return this;
                }
                else
                {
                    return _State_Groupe.State_Dictionary[State_Value.Idle];
                }
            }
            else
            {
                return _State_Groupe.State_Dictionary[State_Value.Chase];
            }
        }
        else
        {
            if (_State_Groupe._Bool_Settings.Is_In_Range)
            {
                return _State_Groupe.State_Dictionary[State_Value.Chase];
            }
            else
            {
                return _State_Groupe.State_Dictionary[State_Value.wander];
            }
        }
    }
    public Run_State Constructor()
    {
        Run_State copy = ScriptableObject.CreateInstance<Run_State>();

        return copy;
    }
}
