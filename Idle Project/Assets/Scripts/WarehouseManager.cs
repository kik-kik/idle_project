using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseManager : MonoBehaviour {

    ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    public void AddResources(float toAdd)
    {
        resourceManager.AddCash((int)toAdd);
    }
}
