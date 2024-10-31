
using UnityEngine;
[CreateAssetMenu(fileName = "Wander_State", menuName = "New State/Wander_State")]
/// <summary>
///  Wander_State is the implementation of the wander behavior
/// </summary>
/// <param name="Wander_State"></param>
public class Wander_State : State
{
    public Wander_State() : base(State_Value.wander) { }
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

        if (!_State_Groupe._Bool_Settings.Attack_Range)
        {
            if (!_State_Groupe._Bool_Settings.Attack_Cooldown)
            {
                return this; ;
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
}
