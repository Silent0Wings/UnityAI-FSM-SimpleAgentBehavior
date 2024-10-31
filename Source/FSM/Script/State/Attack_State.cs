using UnityEngine;
[CreateAssetMenu(fileName = "Attack_State", menuName = "New State/Attack_State")]
/// <summary>
///  Attack_State is the implementation of the attack state
/// </summary>
/// <param name="Attack_State"></param>
public class Attack_State : State
{
    public Attack_State() : base(State_Value.Attack) { }

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

        if (_State_Groupe._Bool_Settings.can_Run && _State_Groupe._Bool_Settings.Is_In_Range)
        {
            if (_State_Groupe.Health_Instance._Health_Parameters.low_health)
                return _State_Groupe.State_Dictionary[State_Value.Run];
        }

        if (_State_Groupe._Bool_Settings.Attack_Range)
        {
            if (_State_Groupe._Bool_Settings.Attack_Cooldown)
            {
                if (_State_Groupe._Bool_Settings.Is_In_Range)
                {
                    return _State_Groupe.State_Dictionary[State_Value.Chase];
                }
                else
                {
                    return _State_Groupe.State_Dictionary[State_Value.Idle];
                }
            }
            else
            {
                return this;
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
                return _State_Groupe.State_Dictionary[State_Value.Idle];
            }
        }
    }
}
