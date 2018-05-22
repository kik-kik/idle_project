using UnityEngine;

public class ElevatorBuildingManager : MonoBehaviour {

    #region variables
    [SerializeField] private float resourceHeld = 0f;
    [SerializeField] GameObject resourceCounterObject;

    TextMesh resourceCounterTextMesh;
    #endregion

    #region getters_and_setters
    public float ResourceHeld { get { return resourceHeld; } }
    #endregion


    private void Start()
    {
        resourceCounterTextMesh = resourceCounterObject.GetComponent<TextMesh>();
    }


    /// <summary>
    /// This method adds the specified amount to the value resourceHeld by the ElevatorBuilding
    /// </summary>
    /// <param name="toAdd"></param>
    public void AddResources(float toAdd)
    {
        resourceHeld += toAdd;
    }

    /// <summary>
    /// This method removes the specified amount from the value resourceHeld by the ElevatorBuilding
    /// </summary>
    /// <param name="toRemove"></param>
    public void RemoveResources(float toRemove)
    {
        resourceHeld -= toRemove;
    }


    /// <summary>
    /// This method updates the label to display the current value of resourceHeld.
    /// </summary>
    public void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = resourceHeld.ToString();
    }
}
