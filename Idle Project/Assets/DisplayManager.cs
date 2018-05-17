using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {

    IncomeManager incomeManager;
    [SerializeField] Text incomeRateText;
    [SerializeField] Text totalCashText;

	// Use this for initialization
	void Start () {
        incomeManager = FindObjectOfType<IncomeManager>();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateUI();

    }

    void UpdateUI()
    {
        int incomeRate = incomeManager.IncomeRate;
        int totalCash = incomeManager.TotalCash;

        incomeRateText.text = incomeRate.ToString();
        totalCashText.text = totalCash.ToString();
    }
}
