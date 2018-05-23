using UnityEngine;
using UnityEngine.UI;


public class UIInteraction : MonoBehaviour {

    #region declarations
    [SerializeField] private GameObject store, crateMenu, openCrate, crateStore;

    public Button storeButton, extraCrystalButton;
    public Button crateStoreButton, crateMenuButton, backToCrateMenuButton, openCrateButton;
    public Button muteButton, githubButton;

    Image muteButtonImage;

    AudioPlayer audioPlayer;
    SpriteManager spriteManager;

    #endregion

    private void Start()
    {
        storeButton.onClick.AddListener(delegate { EnableObject("store"); });
        extraCrystalButton.onClick.AddListener(delegate { EnableObject("store"); });
        crateMenuButton.onClick.AddListener(delegate { EnableObject("crateMenu");  });
        crateStoreButton.onClick.AddListener(delegate { EnableObject("crateStore"); });
        openCrateButton.onClick.AddListener(delegate { EnableObject("openCrate"); });
        backToCrateMenuButton.onClick.AddListener(delegate { EnableObject("backToCrateMenu"); });
        muteButton.onClick.AddListener(delegate { EnableObject("mute"); });
        githubButton.onClick.AddListener(delegate { EnableObject("github"); });

        muteButtonImage = muteButton.GetComponent<Image>();

        audioPlayer = FindObjectOfType<AudioPlayer>();
        spriteManager = FindObjectOfType<SpriteManager>();
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
            case "mute":
                audioPlayer.MuteSound();
                if (audioPlayer.MuteOn)
                {
                    muteButtonImage.sprite = spriteManager.MuteOnImage;
                }
                else {
                    muteButtonImage.sprite = spriteManager.MuteOffImage;
                }
                break;
            case "github":
                Application.OpenURL("https://github.com/Kristofelek/idle_project");
                break;
            default:
                return;
        }
    }
}
