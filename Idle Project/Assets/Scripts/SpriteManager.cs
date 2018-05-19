using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour {

    [SerializeField] private Sprite crateImage, crystalImage, coinImage;

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
}
