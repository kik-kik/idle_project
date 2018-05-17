using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeManager : MonoBehaviour {

    [SerializeField] private int totalCash = 0;
    [SerializeField] private int incomeRate = 10;
    [SerializeField] private float incomeBonus = 1.5f;


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

    public int TotalCash
    {
        get {
            return totalCash;
        }
        set
        {
            totalCash = value;
        }
    }

    public float IncomeModifier { get; set; }

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
}
