using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBuildingManager : MonoBehaviour {

    [SerializeField] private float resourceHeld = 0f;

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

    public void AddResources(float toAdd)
    {
        resourceHeld += toAdd;
    }

    public void RemoveResources(float toRemove)
    {
        resourceHeld -= toRemove;
    }
}
