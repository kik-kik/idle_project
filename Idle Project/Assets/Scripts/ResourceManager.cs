using System;
using System.Collections;
using System.Collections.Generic;
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


    public void AddCash(int cashToAdd)
    {
        //float cashToAddFloat = Convert.ToSingle(cashToAdd) * incomeModifier;
        //cashToAdd = cashToAdd * incomeModifier;
        //print("Adding: " + (int)cashToAddFloat);
        //totalCash += (int)cashToAddFloat;
        totalCash += cashToAdd;
    }

    public void AddCrystals(int crystalsToAdd)
    {
        crystalTotal += crystalsToAdd;
    }

    public void AddCrate(int cratesToAdd)
    {
        cratesTotal += cratesToAdd;
    }

    public void RemoveCash(int cashToRemove)
    {
        print("inside removecash");
        totalCash -= cashToRemove;
    }

    public void RemoveCrystals(int crystalsToRemove)
    {
        crystalTotal -= crystalsToRemove;
    }

    public void RemoveCrates(int cratesToRemove)
    {
        cratesTotal -= cratesToRemove;
    }

}
