using UnityEngine;
[CreateAssetMenu(fileName = "Follow_State", menuName = "New State/Follow_State")]
/// <summary>
///  Follow_State is the implementation of the following behavior
/// </summary>
/// <param name="Follow_State"></param>
public class Follow_State : State
{
    public Follow_State() : base(State_Value.follow) { }

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

        if (!_State_Groupe._Bool_Settings.Can_Follow)
        {
            return _State_Groupe.State_Dictionary[State_Value.Idle];
        }
        if (!_State_Groupe._Bool_Settings.Is_In_Range)
        {
            return this;
        }
        else
        {
            return _State_Groupe.State_Dictionary[State_Value.Idle];
        }
    }
}
