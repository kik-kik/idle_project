using UnityEngine;

public class SpriteManager : MonoBehaviour {

    [SerializeField] private Sprite crateImage, crystalImage, coinImage;

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
    #endregion
}
