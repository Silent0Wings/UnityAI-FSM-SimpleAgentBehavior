using UnityEngine;
[CreateAssetMenu(fileName = "Idle_State", menuName = "New State/Idle_State")]
/// <summary>
///  Idle_State is the implementation of the idling behavior
/// </summary>
/// <param name="Idle_State"></param>
public class Idle_State : State
{
    public Idle_State() : base(State_Value.Idle) { }

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

        if (_State_Groupe._Bool_Settings.Attack_Range && !_State_Groupe.Health_Instance._Health_Parameters.low_health)
        {
            if (_State_Groupe._Bool_Settings.Attack_Cooldown)
            {

                if (_State_Groupe._Bool_Settings.Is_In_Range)
                {
                    return _State_Groupe.State_Dictionary[State_Value.Chase];
                }
                else
                {
                    return this;
                }
            }
            else
            {
                return _State_Groupe.State_Dictionary[State_Value.Attack];
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
                return this;

            }
        }
    }

}
