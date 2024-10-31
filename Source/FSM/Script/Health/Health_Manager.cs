using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(StateDriver))]
/// <summary>
/// Health_Manager is a script that will be used to manage the health of the agent
/// </summary>
/// <param name="Health_Manager"></param>
public class Health_Manager : MonoBehaviour
{
    #region Dependencies
    [Tooltip("State Groupe Instance")]
    public State_Groupe _State_Groupe;
    [Tooltip("Health Instance")]
    public Health Health_Base;
    public Health Health_Instance;
    #endregion

    [Tooltip("Damage bool")]
    public bool Damage; // triggers the damage function
    [Tooltip("Revive bool")]
    public bool Revive;//triggers the revive function

    #region Singleton
    // Start is called before the first frame update
    void Start()
    {
        // dont call on awake since this depends on state driver awake initialisation
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Damage)
        {
            Damage = false;
            Take_Damage(40);
        }
        if (Revive)
        {
            Revive = false;
            Revive_Player();
        }
    }
    /// <summary>
    /// Initialize the script
    /// </summary>
    public void Initialize()
    {
        _State_Groupe = this.transform.GetComponent<StateDriver>()._State_Groupe;

        if (_State_Groupe != null)
        {
            Health_Base = _State_Groupe.Health_Instance;
        }
        Health_Instance = Health.Copy_Constructor(ref Health_Base);
        _State_Groupe.Health_Instance = Health_Instance;

    }
    #endregion

    #region Operations
    /// <summary>
    /// Take damage
    /// </summary>
    /// <param name="h"></param>
    public void Take_Damage(uint h)
    {
        if (Health_Instance != null)
            Health_Instance.Damage(h);
    }
    /// <summary>
    /// Revive the player
    /// </summary>
    public void Revive_Player()
    {
        _State_Groupe._Bool_Settings.Revive = true;
    }
    /// <summary>
    /// heal the player
    /// </summary>
    /// <param name="h"></param>
    public void Heal(uint h)
    {
        if (Health_Instance != null)
            Health_Instance.Increment_Health(h);
    }
    /// <summary>
    /// set the health to a specific value
    /// </summary>
    /// <param name="h"></param>
    public void Set_Health(uint h)
    {
        if (Health_Instance != null)
            Health_Instance.Update_Health(h);
    }
    /// <summary>
    /// Heal the player over time
    /// </summary>
    /// <returns></returns>
    public IEnumerator Heal_Over_Time()
    {
        if (Health_Instance != null)
        {
            if (Health_Instance._Health_Parameters.Can_Heal)
            {
                if (!Health_Instance._Health_Parameters.Is_Dead)
                {
                    Health_Instance._Health_Parameters.Is_Healing = true;
                    while (Health_Instance._Health_Parameters.Current_Health < Health_Instance._Health_Parameters.MaxHealth)
                    {
                        yield return new WaitForSeconds(Health_Instance._Health_Parameters.Health_Regen_Rate);
                        Heal(Health_Instance._Health_Parameters.Health_Regen);
                    }
                    Health_Instance._Health_Parameters.Is_Healing = false;
                }
            }
        }
    }
    #endregion
}