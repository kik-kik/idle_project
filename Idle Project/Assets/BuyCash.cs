using UnityEngine;
using UnityEngine.UI;

public class BuyCash : MonoBehaviour {

    [SerializeField] private int cashValue = 1000;

    private IncomeManager incomeManager;
    private Button buyButton;

    private void Awake()
    {
        buyButton = GetComponentInChildren<Button>();
        buyButton.onClick.AddListener(BuyOnClick);
    }

    private void Start()
    {
        incomeManager = FindObjectOfType<IncomeManager>();
    }

    void BuyOnClick()
    {
        incomeManager.TotalCash = incomeManager.TotalCash += cashValue;
    }
}
