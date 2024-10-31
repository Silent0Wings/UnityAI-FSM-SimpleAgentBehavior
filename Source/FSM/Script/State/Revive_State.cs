using UnityEngine;
[CreateAssetMenu(fileName = "Revive_State", menuName = "New State/Revive_State")]
/// <summary>
///  Revive_State is the implementation of the reviving behavior
/// </summary>
/// <param name="Revive_State"></param>
public class Revive_State : State
{
    public Revive_State() : base(State_Value.Revive) { }

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
            if (_State_Groupe.Health_Instance._Health_Parameters.Can_Revive)
            {
                if (_State_Groupe._Bool_Settings.Revive)
                {
                    _State_Groupe.Health_Instance.Revive();
                    _State_Groupe._Bool_Settings.Revive = false;
                    return _State_Groupe.State_Dictionary[State_Value.Idle];
                }
                else
                {
                    return _State_Groupe.State_Dictionary[State_Value.Die];
                }
            }
            else
            {
                return _State_Groupe.State_Dictionary[State_Value.Die];
            }
        }
        else
        {
            return _State_Groupe.State_Dictionary[State_Value.Idle];
        }
    }
    public Revive_State Constructor()
    {
        Revive_State copy = ScriptableObject.CreateInstance<Revive_State>();
        return copy;
    }
}
