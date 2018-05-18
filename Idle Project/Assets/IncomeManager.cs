using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeManager : MonoBehaviour {

    #region variables
    [Header("Super Cash properties")]
    [SerializeField] private int totalCash = 0;
    [SerializeField] private int incomeRate = 10;
    [SerializeField] private float incomeModifier = 1.5f;

    [Header("Crystal Properties")]
    [SerializeField] private int crystalTotal = 0;
    #endregion

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



    // Use this for initialization
    void Start()
    {
        InvokeRepeating("AddCash", 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddCash()
    {
        totalCash += incomeRate;
    }

    void AddCrystals(int crystalsToAdd)
    {
        crystalTotal += crystalsToAdd;
    }
}
