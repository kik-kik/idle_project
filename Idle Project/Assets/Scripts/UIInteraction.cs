using UnityEngine;
using UnityEngine.UI;


public class UIInteraction : MonoBehaviour {

    #region declarations
    [SerializeField] private GameObject store, crateMenu, openCrate, crateStore, customizationMenu;

    public Button storeButton, extraCrystalButton, crateMenuButton, crateStoreButton, openCrateButton, backToCrateMenuButton, customizationButton, githubButton;
    #endregion

    private void Start()
    {
        storeButton.onClick.AddListener(delegate { EnableObject("store"); });
        extraCrystalButton.onClick.AddListener(delegate { EnableObject("store"); });
        crateMenuButton.onClick.AddListener(delegate { EnableObject("crateMenu");  });
        crateStoreButton.onClick.AddListener(delegate { EnableObject("crateStore"); });
        openCrateButton.onClick.AddListener(delegate { EnableObject("openCrate"); });
        backToCrateMenuButton.onClick.AddListener(delegate { EnableObject("backToCrateMenu"); });
        customizationButton.onClick.AddListener(delegate { EnableObject("customizationMenu"); });
        githubButton.onClick.AddListener(delegate { EnableObject("github"); });
    }


    /// <summary>
    /// This method decides which object should be activated depending on which button gets pressed.
    /// </summary>
    /// <param name="target"></param>
    void EnableObject(string target)
    {
        switch (target)
        {
            case "store": store.SetActive(true);
                break;
            case "crateMenu": crateMenu.SetActive(true);
                break;
            case "crateStore":
                crateMenu.SetActive(false);
                crateStore.SetActive(true);
                break;
            case "openCrate":
                openCrate.SetActive(true);
                break;
            case "backToCrateMenu":
                crateStore.SetActive(false);
                crateMenu.SetActive(true);
                break;
            case "customizationMenu": customizationMenu.SetActive(true);
                break;
            case "github":
                Application.OpenURL("https://github.com/Kristofelek/idle_project");
                break;
            default:
                return;
        }
    }
}
