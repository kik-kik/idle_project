using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {

    ResourceManager resourceManager;
    [SerializeField] Text incomeRateText;
    [SerializeField] Text totalCashText;
    [SerializeField] Text totalCrystalsText;
    [SerializeField] Text cratesTotalText;

    [SerializeField] string cratesStatusDisplay = "You have {0} crates.";


    void Start () {
        resourceManager = FindObjectOfType<ResourceManager>();
    }
	
	// Update is called once per frame
	void Update () {
        InvokeRepeating("UpdateUI", 1f, 1f);
        //UpdateUI();
    }

    void UpdateUI()
    {
        int incomeRate = resourceManager.IncomeRate;
        int totalCash = resourceManager.TotalCash;
        int totalCrystals = resourceManager.CrystalTotal;
        int cratesTotal = resourceManager.CratesTotal;
        string formattedCratesStatus = string.Format(cratesStatusDisplay, cratesTotal.ToString());

        incomeRateText.text = incomeRate.ToString();
        totalCashText.text = totalCash.ToString();
        totalCrystalsText.text = totalCrystals.ToString();
        cratesTotalText.text = formattedCratesStatus;
    }
}
