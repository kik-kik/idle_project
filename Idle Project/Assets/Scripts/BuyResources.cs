using UnityEngine;
using UnityEngine.UI;

public class BuyResources : MonoBehaviour {

    #region variables
    public enum ResourcesList { CASH, CRYSTAL, CRATES };

    [Header("Buying")]
    public ResourcesList resourceToBuy;
    [SerializeField] private int quantityToBuy = 0;

    [Header("Cost")]
    public ResourcesList resourceRequired;
    [SerializeField] private int requiredQuantity = 0;

    ResourceManager resourceManager;
    Button buyButton;
    #endregion


    #region getters_and_setters
    public ResourcesList ResourcesToBuy
    {
        get
        {
            return resourceToBuy;
        }
    }

    public int QuantityToBuy
    {
        get
        {
            return quantityToBuy;
        }
    }

    public ResourcesList ResourceRequired
    {
        get
        {
            return resourceRequired;
        }
    }

    public int RequiredQuantity
    {
        get
        {
            return requiredQuantity;
        }
    }
    #endregion


    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();

        buyButton = GetComponentInChildren<Button>();
        buyButton.onClick.AddListener(BuyOnClick);
    }

    /// <summary>
    /// This method attemps to make a transaction.
    /// </summary>
    void BuyOnClick()
    {
        Transaction(resourceToBuy, quantityToBuy, resourceRequired, requiredQuantity);
    }

    /// <summary>
    /// This method adds the specified quantity of Cash to the players inventory.
    /// </summary>
    /// <param name="quantityToBuy"></param>
    void BuyCash(int quantityToBuy) {
        resourceManager.TotalCash = resourceManager.TotalCash += quantityToBuy;
    }

    /// <summary>
    /// This method adds the specified quantity of Crystal to the players inventory.
    /// </summary>
    /// <param name="crystalsToBuy"></param>
    void BuyCrystals(int crystalsToBuy)
    {
        resourceManager.CrystalTotal = resourceManager.CrystalTotal += crystalsToBuy;
    }

    /// <summary>
    /// This method adds the specified quantity of Crate to the players inventory.
    /// </summary>
    /// <param name="cratesToBuy"></param>
    void BuyCrates(int cratesToBuy)
    {
        resourceManager.CratesTotal = resourceManager.CratesTotal += cratesToBuy;
    }

    /// <summary>
    /// This method attempts to make the requested transaction, checks if transaction is possible. If yes then the exchange happens.
    /// </summary>
    /// <param name="resourceToBuy"></param>
    /// <param name="quantityToBuy"></param>
    /// <param name="resourceRequired"></param>
    /// <param name="requiredQuantity"></param>
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

    /// <summary>
    /// This method removes the specified number of the specified resource from the players inventory.
    /// </summary>
    /// <param name="resourceRequired"></param>
    /// <param name="requiredQuantity"></param>
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

    void InvalidTransaction()
    {
        //todo: display a visual hint that the transaction is not possible.
    }

    /// <summary>
    /// This method returns true if the player has enough of the required resource to make the transaction. Otherwise it returns false.
    /// </summary>
    /// <param name="resourceRequire"></param>
    /// <param name="requiredQuantity"></param>
    /// <returns></returns>
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
