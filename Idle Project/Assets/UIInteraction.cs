﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIInteraction : MonoBehaviour {

    [SerializeField] private GameObject store, crate, customizationMenu;
    //[SerializeField] List<GameObject> UIObjects = new List<GameObject>();


    //public enum Action { OPENSTORE, OPENCRATE, OPENCUSTOMIZATIONMENU };
    public Button storeButton, crateButton, customizationButton;

    private void Start()
    {
        storeButton.onClick.AddListener(delegate { EnableObject("store"); });
        crateButton.onClick.AddListener(delegate { EnableObject("crate");  });
        customizationButton.onClick.AddListener(delegate { EnableObject("customizationMenu"); });
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
            case "crate": crate.SetActive(true);
                break;
            case "customizationMenu": customizationMenu.SetActive(true);
                break;
            default:
                return;
        }
    }
}
