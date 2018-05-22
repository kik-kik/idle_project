using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {

    #region variables
    [SerializeField] string cratesStatusDisplay = "You have {0} crates.";

    [SerializeField] Text incomeRateText;
    [SerializeField] Text totalCashText;
    [SerializeField] Text totalCrystalsText;
    [SerializeField] Text cratesTotalText;
   
    ResourceManager resourceManager;
    #endregion


    void Start () {
        resourceManager = FindObjectOfType<ResourceManager>();
    }
	
	void Update () {
        InvokeRepeating("UpdateUI", 1f, 1f);
    }

    /// <summary>
    /// This method updates the UI at the top of the screen which displays information about resources - cash, crystals, income/s
    /// </summary>
    void UpdateUI()
    {
        int incomeRate = resourceManager.IncomeRate;
        incomeRateText.text = incomeRate.ToString();

        int totalCash = resourceManager.TotalCash;
        totalCashText.text = totalCash.ToString();

        int totalCrystals = resourceManager.CrystalTotal;
        totalCrystalsText.text = totalCrystals.ToString();

        int cratesTotal = resourceManager.CratesTotal;
        string formattedCratesStatus = string.Format(cratesStatusDisplay, cratesTotal.ToString());
        cratesTotalText.text = formattedCratesStatus;
    }
}
