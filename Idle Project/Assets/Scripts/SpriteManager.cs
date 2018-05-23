using UnityEngine;

public class SpriteManager : MonoBehaviour {

    [SerializeField] private Sprite crateImage, crystalImage, coinImage;
    [SerializeField] private Sprite muteOffImage, muteOnImage;
    [SerializeField] private Sprite missingImage;

    #region getters
    public Sprite CrateImage
    {
        get
        {
            return crateImage;
        }
    }

    public Sprite CrystalImage
    {
        get
        {
            return crystalImage;
        }
    }

    public Sprite CoinImage
    {
        get
        {
            return coinImage;
        }
    }

    public Sprite MuteOffImage
    {
        get
        {
            return muteOffImage;
        }
    }

    public Sprite MuteOnImage
    {
        get
        {
            return muteOnImage;
        }
    }

    public Sprite MissingImage
    {
        get
        {
            return missingImage;
        }
    }
    #endregion
}
