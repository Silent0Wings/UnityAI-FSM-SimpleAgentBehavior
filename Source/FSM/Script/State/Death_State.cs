using UnityEngine;
[CreateAssetMenu(fileName = "Death_State", menuName = "New State/Death_State")]
/// <summary>
///  Death_State is the implementation of the death behavior
/// </summary>
/// <param name="Death_State"></param>
public class Death_State : State
{
    public Death_State() : base(State_Value.Die) { }

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

        if (_State_Groupe.Health_Instance._Health_Parameters.Is_Dead)
        {
            if (_State_Groupe._Bool_Settings.Revive && _State_Groupe.Health_Instance._Health_Parameters.Can_Revive)
            {
                return _State_Groupe.State_Dictionary[State_Value.Revive];
            }
            else
            {
                return this;
            }
        }
        else
        {
            return _State_Groupe.State_Dictionary[State_Value.Revive];
        }
    }
}
