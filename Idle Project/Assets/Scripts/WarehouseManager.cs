using UnityEngine;

public class WarehouseManager : MonoBehaviour {

    #region references
    ResourceManager resourceManager;
    #endregion

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    /// <summary>
    /// This method adds the specified amount of Cash to the players inventory.
    /// </summary>
    /// <param name="toAdd"></param>
    public void AddResources(float toAdd)
    {
        resourceManager.AddCash((int)toAdd);
    }
}
