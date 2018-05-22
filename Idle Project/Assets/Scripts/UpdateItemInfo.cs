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

    // Use this for initialization
    void Start () {
        spriteManager = FindObjectOfType<SpriteManager>();

        buyResourceScript = GetComponent<BuyResources>();
        buyItemButton = GetComponentInChildren<Button>();

        itemDescriptionText = GetComponentInChildren<Text>();
        itemImage = transform.Find(gameObjectNameWithImage).gameObject.GetComponent<Image>();

        itemImage.sprite = spriteManager.CrateImage;

        resourceRequired = buyResourceScript.resourceRequired;
        resourceToBuy = buyResourceScript.resourceToBuy;

        buyQuantity = buyResourceScript.QuantityToBuy;
        quantityRequired = buyResourceScript.RequiredQuantity;

        string formattedDescription = string.Format(itemDescriptionTemplate, buyQuantity, resourceToBuy);
        string formattedButtonText = string.Format(buttonTextTemplate, quantityRequired, resourceRequired);

        SetItemDescription(formattedDescription);
        //SetItemSprite();
        SetButtonText(formattedButtonText);
    }

    void SetItemSprite()
    {
        itemImage.sprite = spriteManager.CrateImage;
    }

    void SetItemDescription(string formattedDescription)
    {
        itemDescriptionText.text = formattedDescription;
    }

    void SetButtonText(string formattedButtonText)
    {
        buyItemButton.GetComponentInChildren<Text>().text = formattedButtonText;
    }
}
