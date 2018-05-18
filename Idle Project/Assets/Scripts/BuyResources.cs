using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BuyResources : MonoBehaviour {

    public enum ResourcesList { CASH, CRYSTAL, CRATES };

    [Header("Buying")]
    public ResourcesList resourceToBuy;
    [SerializeField] private int quantityToBuy = 0;

    [Header("Cost")]
    public ResourcesList resourceRequired;
    [SerializeField] private int requiredQuantity = 0;

    private ResourceManager resourceManager;
    private Button buyButton;


    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        buyButton = GetComponentInChildren<Button>();
        buyButton.onClick.AddListener(BuyOnClick);
    }

    void BuyOnClick()
    {
        Transaction(resourceToBuy, quantityToBuy, resourceRequired, requiredQuantity);
    }

    void BuyCash(int quantityToBuy) {
        resourceManager.TotalCash = resourceManager.TotalCash += quantityToBuy;
    }

    void BuyCrystals(int crystalsToBuy)
    {
        resourceManager.CrystalTotal = resourceManager.CrystalTotal += crystalsToBuy;
    }

    void BuyCrates(int cratesToBuy)
    {
        resourceManager.CratesTotal = resourceManager.CratesTotal += cratesToBuy;
    }

    // perhaps instead of individual functions for all different resources have one general one
    void Transaction(ResourcesList resourceToBuy, int quantityToBuy, ResourcesList resourceRequired, int requiredQuantity)
    {
        switch (resourceToBuy)
        {
            case ResourcesList.CASH:
                if (CheckQuantity(resourceRequired, requiredQuantity))
                {
                    BuyCash(quantityToBuy);
                }
                else
                {
                    InvalidTransaction();
                    return;
                }
                break;
            case ResourcesList.CRYSTAL:
                if (CheckQuantity(resourceRequired, requiredQuantity))
                {
                    BuyCrystals(quantityToBuy);
                }
                else
                {
                    InvalidTransaction();
                    return;
                }
                break;
            case ResourcesList.CRATES:
                if (CheckQuantity(resourceRequired, requiredQuantity))
                {
                    BuyCrates(quantityToBuy);
                }
                else
                {
                    InvalidTransaction();
                    return;
                }
                break;
            default: InvalidTransaction();
                return;
        }
        RemoveResource(resourceRequired, requiredQuantity);
    }

    void RemoveResource(ResourcesList resourceRequired, int requiredQuantity)
    {
        switch (resourceRequired)
        {
            case ResourcesList.CASH:
                resourceManager.RemoveCash(requiredQuantity);
                break;
            case ResourcesList.CRYSTAL:
                resourceManager.RemoveCrystals(requiredQuantity);
                break;
            /*case ResourcesList.CRATES:
                resourceManager.RemoveCrates(requiredQuantity);
                break;*/
            default:
                break;
        }
    }

    //TODO: Complete this method
    void InvalidTransaction()
    {
        //display a visual hint that the transaction did not work
    }

    bool CheckQuantity(ResourcesList resourceRequire, int requiredQuantity)
    {
        bool transactionIsValid = false;

        switch (resourceRequired)
        {
            case ResourcesList.CASH:
                if (resourceManager.TotalCash >= requiredQuantity)
                {
                    transactionIsValid = true;
                }
                else
                {
                    transactionIsValid = false;
                };
                break;
            case ResourcesList.CRYSTAL:
                if (resourceManager.CrystalTotal >= requiredQuantity)
                {
                    transactionIsValid = true;
                }
                else
                {
                    transactionIsValid = false;
                };
                break;
            /*case ResourcesList.CRATES:
                if (resourceManager.CratesTotal >= requiredQuantity)
                {
                    transactionIsValid = true;
                }
                else
                {
                    transactionIsValid = false;
                };
                break;*/
            default:
                transactionIsValid = false;
                break;
        }
        return transactionIsValid;
    }
}
