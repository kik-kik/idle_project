using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineboxController : MonoBehaviour {

    private float totalResource = 0f;

	public float TotalResource
    {
        get
        {
            return totalResource;
        }
        set
        {
            totalResource = value;
        }
    }

    private void FixedUpdate()
    {
        print(totalResource);
    }
}
