using UnityEngine;

public class ResourceManager : MonoBehaviour {

    #region variables
    [Header("Super Cash properties")]
    [SerializeField] private int totalCash = 0;
    [SerializeField] private int incomeRate = 10;
    [SerializeField] private float incomeModifier = 1.5f;

    [Header("Crystal Properties")]
    [SerializeField] private int crystalTotal = 0;

    [Header("Crates Properties")]
    [SerializeField] private int cratesTotal = 0;
    #endregion

    #region getters_and_setters
    #region superCashProperties
    public int TotalCash
    {
        get
        {
            return totalCash;
        }
        set
        {
            totalCash = value;
        }
    }

    public int IncomeRate
    {
        get
        {
            return incomeRate;
        }
        set
        {
            incomeRate = value;
        }
    }

    public float IncomeModifier { get; set; }
    #endregion

    #region crystalProperties
    public int CrystalTotal
    {
        get
        {
            return crystalTotal;
        }
        set
        {
            crystalTotal = value;
        }
    }
    #endregion

    #region cratesProperties
    public int CratesTotal
    {
        get
        {
            return cratesTotal;
        }
        set
        {
            cratesTotal = value;
        }
    }
    #endregion
    #endregion


    /// <summary>
    /// Adds the specified amount to the amount of Cash resource held by the player.
    /// </summary>
    /// <param name="cashToAdd"></param>
    public void AddCash(int cashToAdd)
    {
        totalCash += cashToAdd;
    }

    /// <summary>
    /// Adds the specified amount to the amount of Crystal resource held by the player.
    /// </summary>
    /// <param name="crystalsToAdd"></param>
    public void AddCrystals(int crystalsToAdd)
    {
        crystalTotal += crystalsToAdd;
    }

    /// <summary>
    /// Adds the specified amount to the amount of Crate resource held by the player.
    /// </summary>
    /// <param name="cratesToAdd"></param>
    public void AddCrate(int cratesToAdd)
    {
        cratesTotal += cratesToAdd;
    }

    /// <summary>
    /// Removes the specified amount to the amount of Cash resource held by the player.
    /// </summary>
    /// <param name="cashToRemove"></param>
    public void RemoveCash(int cashToRemove)
    {
        print("inside removecash");
        totalCash -= cashToRemove;
    }

    /// <summary>
    /// Removes the specified amount to the amount of Crystal resource held by the player.
    /// </summary>
    /// <param name="crystalsToRemove"></param>
    public void RemoveCrystals(int crystalsToRemove)
    {
        crystalTotal -= crystalsToRemove;
    }

    /// <summary>
    /// Removes the specified amount to the amount of Crate resource held by the player.
    /// </summary>
    /// <param name="cratesToRemove"></param>
    public void RemoveCrates(int cratesToRemove)
    {
        cratesTotal -= cratesToRemove;
    }

}
