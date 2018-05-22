using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineboxController : MonoBehaviour {

    [SerializeField] private float totalResource = 0f;

    [SerializeField] GameObject resourceCounterObject;
    TextMesh resourceCounterTextMesh;

    public float TotalResource
    {
        get
        {
            return totalResource;
        }
        set
        {
            totalResource = value;
            print("Setting new value");
            UpdateResourceCounterTextMesh();
        }
    }


    private void Start()
    {
        resourceCounterTextMesh = resourceCounterObject.GetComponent<TextMesh>();
    }

    public void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = totalResource.ToString();
    }

}
