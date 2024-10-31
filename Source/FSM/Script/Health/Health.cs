using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Health", menuName = "New Health/Health")]
[SerializeField]
/// <summary>
/// Health is a scriptable object that will be used to manage the health of the agent
/// </summary>
/// <param name="Health"></param>
public class Health : ScriptableObject
{
    #region Health_Parameters
    [Tooltip("This is the current health ")]
    public Health_Parameters _Health_Parameters = new();
    #endregion
    [Tooltip("This is the health instance")]

    #region Constructors
    /// <summary>
    /// Health Default Constructor
    /// </summary>
    public Health()
    {
        _Health_Parameters.Current_Health = 100;
        _Health_Parameters.MaxHealth = 100;
        _Health_Parameters.MinHealth = 0;
        _Health_Parameters.Health_Regen = 1;
        _Health_Parameters.Health_Regen_Rate = 1;
        _Health_Parameters.Low_Health_Threshold = 25;
        _Health_Parameters.Is_Healing = false;
        _Health_Parameters.low_health = false;
        _Health_Parameters.Is_Dead = false;
    }
    /// <summary>
    /// Health constructor with 1 parameter
    /// </summary>
    /// <param name="ch"></param>
    public Health(uint ch)
    {
        _Health_Parameters.Current_Health = ch;
        _Health_Parameters.MaxHealth = 100;
        _Health_Parameters.MinHealth = 0;
        _Health_Parameters.Health_Regen = 1;
        _Health_Parameters.Health_Regen_Rate = 1;
        _Health_Parameters.Low_Health_Threshold = 25;
        _Health_Parameters.Is_Healing = false;
        _Health_Parameters.low_health = false;
        _Health_Parameters.Is_Dead = false;
    }
    /// <summary>
    /// Health constructor with 2 parameters
    /// </summary>
    /// <param name="ch"></param>
    /// <param name="mh"></param>
    public Health(uint ch, uint mh)
    {
        _Health_Parameters.Current_Health = ch;
        _Health_Parameters.MaxHealth = mh;
        _Health_Parameters.MinHealth = 0;
        _Health_Parameters.Health_Regen = 1;
        _Health_Parameters.Health_Regen_Rate = 1;
        _Health_Parameters.Low_Health_Threshold = 25;
        _Health_Parameters.Is_Healing = false;
        _Health_Parameters.low_health = false;
        _Health_Parameters.Is_Dead = false;
    }
    /// <summary>
    /// Health constructor with 3 parameters
    /// </summary>
    /// <param name="ch"></param>
    /// <param name="mh"></param>
    /// <param name="min_h"></param>
    public Health(uint ch, uint mh, uint min_h)
    {
        _Health_Parameters.Current_Health = ch;
        _Health_Parameters.MaxHealth = mh;
        _Health_Parameters.MinHealth = min_h;
        _Health_Parameters.Health_Regen = 1;
        _Health_Parameters.Health_Regen_Rate = 1;
        _Health_Parameters.Low_Health_Threshold = 25;
        _Health_Parameters.Is_Healing = false;
        _Health_Parameters.low_health = false;
        _Health_Parameters.Is_Dead = false;
    }
    /// <summary>
    /// Create a instance of Health with the values of the base 
    /// </summary>
    /// <param name="Base"></param>
    /// <returns></returns>
    public static Health Copy_Constructor(ref Health Base)
    {
        if (Base == null)
        {
            return null;
        }
        else
        {
            Health New_Health = ScriptableObject.CreateInstance<Health>();
            New_Health.name = Base.name + Time.fixedTime;

            // copy the values from the base to the new instance
            New_Health._Health_Parameters.Assign(Base._Health_Parameters);

            New_Health._Health_Parameters.Can_Heal = Base._Health_Parameters.Can_Heal;
            New_Health._Health_Parameters.Can_Damage = Base._Health_Parameters.Can_Damage;
            New_Health._Health_Parameters.Can_Die = Base._Health_Parameters.Can_Die;
            New_Health._Health_Parameters.Can_Revive = Base._Health_Parameters.Can_Revive;


            return New_Health;
        }
    }
    #endregion

    #region Health
    /// <summary>
    /// Reset the health to the default values
    /// </summary>
    public void Reset_Health()
    {
        _Health_Parameters.Reset();

    }
    /// <summary>
    /// Update the value of the health
    /// </summary>
    /// <param name="value"></param>
    public void Update_Health(uint value)
    {
        _Health_Parameters.Current_Health = (uint)Mathf.Clamp(value, _Health_Parameters.MinHealth, _Health_Parameters.MaxHealth);
        Health_Logic();
    }
    /// <summary>
    /// Increment the health by a value
    /// </summary>
    /// <param name="value"></param>
    public void Increment_Health(uint value)
    {
        if (_Health_Parameters.Current_Health < _Health_Parameters.MaxHealth)
        {
            _Health_Parameters.Current_Health = (uint)Mathf.Clamp(_Health_Parameters.Current_Health + value, _Health_Parameters.MinHealth, _Health_Parameters.MaxHealth);
            Health_Logic();
        }
    }
    /// <summary>
    /// Decrement the health by a value
    /// </summary>
    /// <param name="value"></param>
    public void Damage(uint value)
    {
        if (_Health_Parameters.Current_Health > 0)
        {
            _Health_Parameters.Current_Health = (uint)(Mathf.Clamp((int)(_Health_Parameters.Current_Health - value), _Health_Parameters.MinHealth, _Health_Parameters.MaxHealth)); // the cast inside is important since uint cannot be negative
            Health_Logic();
        }
    }
    /// <summary>
    /// Revive this instance if it is dead
    /// </summary>
    public void Revive()
    {
        if (_Health_Parameters.Current_Health <= 0 && _Health_Parameters.Is_Dead)
        {
            Reset_Health();
            Health_Logic();
        }
    }
    /// <summary>
    /// Establish the logic for the health
    /// </summary>
    public void Health_Logic()
    {
        if (_Health_Parameters.Current_Health <= 0)
        {
            _Health_Parameters.Is_Dead = true;
        }
        else if (_Health_Parameters.Current_Health > 0)
        {
            _Health_Parameters.Is_Dead = false;
        }
        if (_Health_Parameters.Current_Health <= _Health_Parameters.Low_Health_Threshold)
        {
            _Health_Parameters.low_health = true;
        }
        else if (_Health_Parameters.Current_Health > _Health_Parameters.Low_Health_Threshold)
        {
            _Health_Parameters.low_health = false;
        }
    }
    #endregion

    private void Awake()
    {
        Reset_Health();
    }
}

[System.Serializable]
public class Health_Parameters
{
    [Tooltip("This is the current health ")]
    public uint Current_Health = 100;
    [Tooltip("This is the maximum health ")]
    public uint MaxHealth = 100;
    [Tooltip("This is the minimum health ")]
    public uint MinHealth = 0;
    [Tooltip("This is the health regen ")]
    public uint Health_Regen = 1;
    [Tooltip("This is the health regen rate ")]
    public uint Health_Regen_Rate = 1;
    [Tooltip("This is the low health threshold ")]
    public uint Low_Health_Threshold = 25;

    [Tooltip("This is the bool that checks if this instance is healing")]
    public bool Is_Healing;
    [Tooltip("This is the bool that checks if this instance is low health")]
    public bool low_health;
    [Tooltip("This is the bool that checks if this instance is dead")]
    public bool Is_Dead;

    [Tooltip("This is the bool that checks if this instance can heal")]
    public bool Can_Heal;
    [Tooltip("This is the bool that checks if this instance can take damage")]
    public bool Can_Damage;
    [Tooltip("This is the bool that checks if this instance can die")]
    public bool Can_Die;
    [Tooltip("This is the bool that checks if this instance can revive")]
    public bool Can_Revive;

    /// <summary>
    /// Default Constructors
    /// </summary>
    public Health_Parameters()
    {
        Current_Health = 100;
        MaxHealth = 100;
        MinHealth = 0;
        Health_Regen = 1;
        Health_Regen_Rate = 1;
        Low_Health_Threshold = 25;

        Is_Healing = false;
        low_health = false;
        Is_Dead = false;

        Can_Heal = true;
        Can_Damage = true;
        Can_Die = true;
        Can_Revive = true;


    }
    /// <summary>
    /// Copy Constructor
    /// </summary>
    /// <param name="Val"></param>
    public Health_Parameters(Health_Parameters Val)
    {
        Current_Health = Val.Current_Health;
        MaxHealth = Val.MaxHealth;
        MinHealth = Val.MinHealth;
        Health_Regen = Val.Health_Regen;
        Health_Regen_Rate = Val.Health_Regen_Rate;
        Low_Health_Threshold = Val.Low_Health_Threshold;

        Is_Healing = Val.Is_Healing;
        low_health = Val.low_health;
        Is_Dead = Val.Is_Dead;

        Can_Heal = Val.Can_Heal;
        Can_Damage = Val.Can_Damage;
        Can_Die = Val.Can_Die;
        Can_Revive = Val.Can_Revive;
    }
    /// <summary>
    /// Assignment values from one instance to another
    /// </summary>
    /// <param name="Val"></param>
    public void Assign(Health_Parameters Val)
    {
        this.Current_Health = Val.Current_Health;
        this.MaxHealth = Val.MaxHealth;
        this.MinHealth = Val.MinHealth;
        this.Health_Regen = Val.Health_Regen;
        this.Health_Regen_Rate = Val.Health_Regen_Rate;
        this.Low_Health_Threshold = Val.Low_Health_Threshold;

        this.Is_Healing = Val.Is_Healing;
        this.low_health = Val.low_health;
        this.Is_Dead = Val.Is_Dead;

        this.Can_Heal = Val.Can_Heal;
        this.Can_Damage = Val.Can_Damage;
        this.Can_Die = Val.Can_Die;
        this.Can_Revive = Val.Can_Revive;
    }
    public void Reset()
    {
        Current_Health = MaxHealth;
        Is_Healing = false;
        low_health = false;
        Is_Dead = false;
    }
}