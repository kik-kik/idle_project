using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBuildingManager : MonoBehaviour {

    [SerializeField] private float resourceHeld = 0f;
    [SerializeField] GameObject resourceCounterObject;
    TextMesh resourceCounterTextMesh;

    public float ResourceHeld { get { return resourceHeld; } }

    /*public float ResourceHeld {
        get
        {
            return resourceHeld;
        }
        set
        {
            resourceHeld = value;
        }
         }*/

    private void Start()
    {
        resourceCounterTextMesh = resourceCounterObject.GetComponent<TextMesh>();
    }

    public void AddResources(float toAdd)
    {
        resourceHeld += toAdd;
    }

    public void RemoveResources(float toRemove)
    {
        resourceHeld -= toRemove;
    }

    public void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = resourceHeld.ToString();
    }
}
