using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class WarehouseWorkerController : MonoBehaviour
{

    #region variables
    [SerializeField] private bool move = false;
    [SerializeField] private bool manager = false;

    [Header("Speed")]
    [SerializeField] private float movementSpeed = 1f;
    [Range(1, 3)]
    [SerializeField] private float speedRate = 1f;

    [Header("Carrying")]
    //[Range(1, 3)]
    //[SerializeField] private float collectingSpeed = 1f;
    //[Range(1, 3)]
    //[SerializeField] private float collectingModifier = 1f;
    [SerializeField] float capacity = 100f;
    [SerializeField] private float resourceCollected = 0f;

    ElevatorBuildingManager elevatorManager;
    WarehouseManager warehouseManager;
    [SerializeField] GameObject resourceCounterObject;

    RectTransform resourceCounter;
    TextMesh resourceCounterTextMesh;

    #endregion

    private void Start()
    {
        elevatorManager = FindObjectOfType<ElevatorBuildingManager>();
        warehouseManager = FindObjectOfType<WarehouseManager>();

        resourceCounter = resourceCounterObject.GetComponent<RectTransform>();
        resourceCounterTextMesh = resourceCounterObject.GetComponent<TextMesh>();
    }

    private void OnMouseDown()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    /// <summary>
    /// This method that moves the target on the X axis.
    /// </summary>
    void MoveCharacter()
    {
        if (move || manager)
        {
            float translatePos = movementSpeed * speedRate * Time.deltaTime;
            transform.Translate(translatePos, 0f, 0f);
        }
    }

    /// <summary>
    /// This method rotates the target by 180 degrees on the Y axis.
    /// </summary>
    void RotateCharacter()
    {
        transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
    }

    /// <summary>
    /// This method is used to ensure that the label containing the amount of resources carried is not rotated.
    /// </summary>
    void ResetCounterRotation()
    {
        resourceCounter.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    /// <summary>
    /// This method is responsible for removing resources from the elevator and adding them to the elevator building.
    /// </summary>
    void CollectResource()
    {
        if (resourceCollected < capacity)
        {
            float spaceAvailable = capacity - resourceCollected;
            float resourceAvailable = Mathf.Clamp(elevatorManager.ResourceHeld, 0f, spaceAvailable);

            elevatorManager.RemoveResources(resourceAvailable);
            elevatorManager.UpdateResourceCounterTextMesh();

            resourceCollected += resourceAvailable;
            UpdateResourceCounterTextMesh();
        }
    }

    /// <summary>
    /// This method removes the resources from the warehouse worker and adds them to the warehouseManager.
    /// </summary>
    void DropOffResources()
    {
        warehouseManager.AddResources(resourceCollected);
        //warehouseManager.UpdateResourceCounterTextMesh();

        resourceCollected = 0f;
        UpdateResourceCounterTextMesh();
    }

    /// <summary>
    /// This method updades the label to display the current value of resourceCollected above the object.
    /// </summary>
    void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = resourceCollected.ToString();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "elevator_building")
        {
            CollectResource();
        }
        else if (col.transform.tag == "warehouse")
        {
            DropOffResources();
        }
        RotateCharacter();
        ResetCounterRotation();
    }
}
