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
    [Range(1, 3)]
    [SerializeField] private float collectingSpeed = 1f;
    [Range(1, 3)]
    [SerializeField] private float collectingModifier = 1f;
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

        if (move || manager)
        {
            MoveCharacter();
        }

    }

    /// <summary>
    /// This method that moves the target on the X axis.
    /// </summary>
    void MoveCharacter()
    {
        float translatePos = movementSpeed * speedRate * Time.deltaTime;
        transform.Translate(translatePos, 0f, 0f);
    }

    /// <summary>
    /// This method rotates the target by 180 degrees on the Y axis.
    /// </summary>
    void RotateCharacter()
    {
        // this line below will switch between negative and positive values -> change direction
        //movementSpeed -= movementSpeed * 2f;
        //transform.Rotate(0f, transform.eulerAngles.y + 180f, 0f);
        transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
    }

    void ResetCounterRotation()
    {
        resourceCounter.rotation = Quaternion.Euler(0f, 0f, 0f);
    }


    void CollectResource()
    {
        if (resourceCollected < capacity)
        {
            resourceCollected = Mathf.Clamp(elevatorManager.ResourceHeld, 0f, capacity);
            elevatorManager.RemoveResources(resourceCollected);
            UpdateResourceCounterTextMesh();
        }
    }

    void DropOffResources()
    {
        warehouseManager.AddResources(resourceCollected);
        resourceCollected = 0f;
        UpdateResourceCounterTextMesh();
    }

    void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = resourceCollected.ToString();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "elevator_building")
        {
            CollectResource();
            elevatorManager.UpdateResourceCounterTextMesh();
        }
        else if (col.transform.tag == "warehouse")
        {
            //TODO: do something when dropping off the coins
            print("dropping off coins to the warehouse");
            DropOffResources();
        }
        RotateCharacter();
        ResetCounterRotation();
    }
}
