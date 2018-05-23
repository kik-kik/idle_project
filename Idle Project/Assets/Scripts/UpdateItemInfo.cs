using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BuyResources))]
public class UpdateItemInfo : MonoBehaviour {

    #region variables
    [SerializeField] private string gameObjectNameWithImage = "ItemImage";

    private string itemDescriptionTemplate = "{0} {1}";
    private string buttonTextTemplate = "{0} {1}";

    private int buyQuantity, quantityRequired;

    BuyResources buyResourceScript;
    BuyResources.ResourcesList resourceRequired, resourceToBuy;

    SpriteManager spriteManager;
    GameObject itemImageGameobject;
    Image itemImage;

    Text itemDescriptionText;

    Button buyItemButton;
    #endregion

    
    void Start () {
        spriteManager = FindObjectOfType<SpriteManager>();

        buyResourceScript = GetComponent<BuyResources>();
        buyItemButton = GetComponentInChildren<Button>();

        itemDescriptionText = GetComponentInChildren<Text>();
        itemImage = transform.Find(gameObjectNameWithImage).gameObject.GetComponent<Image>();

        resourceRequired = buyResourceScript.resourceRequired;
        resourceToBuy = buyResourceScript.resourceToBuy;

        buyQuantity = buyResourceScript.QuantityToBuy;
        quantityRequired = buyResourceScript.RequiredQuantity;

        string formattedDescription = string.Format(itemDescriptionTemplate, buyQuantity, resourceToBuy);
        string formattedButtonText = string.Format(buttonTextTemplate, quantityRequired, resourceRequired);

        SetItemDescription(formattedDescription);
        SetItemSprite(resourceToBuy);
        SetButtonText(formattedButtonText);
    }

    /// <summary>
    /// This method figures out and sets the correct sprite image based on the resource to buy
    /// </summary>
    /// <param name="resourceToBuy"></param>
    void SetItemSprite(BuyResources.ResourcesList resourceToBuy)
    {
        Sprite currentItemImage = null;
        switch (resourceToBuy)
        {
            case BuyResources.ResourcesList.CASH:
                currentItemImage = spriteManager.CoinImage;
                break;
            case BuyResources.ResourcesList.CRYSTAL:
                currentItemImage = spriteManager.CrystalImage;
                break;
            case BuyResources.ResourcesList.CRATES:
                currentItemImage = spriteManager.CrateImage;
                break;
            default:
                currentItemImage = spriteManager.MissingImage;
                break;
        }

        itemImage.sprite = currentItemImage;
    }

    /// <summary>
    /// This method sets the description of the item.
    /// </summary>
    /// <param name="formattedDescription"></param>
    void SetItemDescription(string formattedDescription)
    {
        itemDescriptionText.text = formattedDescription;
    }

    /// <summary>
    /// This method sets the text of the button for the specific item.
    /// </summary>
    /// <param name="formattedButtonText"></param>
    void SetButtonText(string formattedButtonText)
    {
        buyItemButton.GetComponentInChildren<Text>().text = formattedButtonText;
    }
}
