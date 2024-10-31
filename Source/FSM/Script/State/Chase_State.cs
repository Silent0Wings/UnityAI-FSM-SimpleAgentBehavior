using UnityEngine;
[CreateAssetMenu(fileName = "Chase_State", menuName = "New State/Chase_State")]
/// <summary>
///  Chase_State is the implementation of the chase behavior
/// </summary>
/// <param name="Chase_State"></param>
public class Chase_State : State
{
    public Chase_State() : base(State_Value.Chase) { }

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

        if (_State_Groupe._Bool_Settings.can_Run && _State_Groupe._Bool_Settings.Is_In_Range || _State_Groupe._Bool_Settings.Attack_Range)
        {
            if (_State_Groupe.Health_Instance._Health_Parameters.low_health)
                return _State_Groupe.State_Dictionary[State_Value.Run];
        }

        if (_State_Groupe._Bool_Settings.Is_In_Range)
        {
            if (_State_Groupe._Bool_Settings.Attack_Range)
            {
                if (_State_Groupe._Bool_Settings.Attack_Cooldown)
                {
                    return _State_Groupe.State_Dictionary[State_Value.Chase];
                }
                else
                {
                    return _State_Groupe.State_Dictionary[State_Value.Attack];
                }
            }
            else
            {
                return _State_Groupe.State_Dictionary[State_Value.Chase];
            }
        }
        else
        {
            if (_State_Groupe._Bool_Settings.Attack_Range)
            {
                if (_State_Groupe._Bool_Settings.Attack_Cooldown)
                {
                    return _State_Groupe.State_Dictionary[State_Value.Attack];
                }
                else
                {
                    return _State_Groupe.State_Dictionary[State_Value.Idle];
                }
            }
            else
            {
                return _State_Groupe.State_Dictionary[State_Value.Idle];
            }
        }
    }
}
