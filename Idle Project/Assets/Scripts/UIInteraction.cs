using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIInteraction : MonoBehaviour {

    [SerializeField] private GameObject store, crateMenu, openCrate, crateStore, customizationMenu;
    //[SerializeField] List<GameObject> UIObjects = new List<GameObject>();


    //public enum Action { OPENSTORE, OPENCRATE, OPENCUSTOMIZATIONMENU };
    public Button storeButton, extraCrystalButton, crateMenuButton, crateStoreButton, openCrateButton, backToCrateMenuButton, customizationButton, githubButton;

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

    private void OnMouseDown()
    {
        //Action action = Action.OPENSTORE;
        //EnableObject(target);
    }

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
