using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    #region variables
    ElevatorBuildingManager elevatorManager;
    MineboxController mineBoxController;

    [SerializeField] private bool isMoving = true;
    [SerializeField] private float movementSpeed = -1f;

    [Header("Collection")]
    [SerializeField] private bool collectResources = true;
    [SerializeField] private float capacity = 100f;
    [SerializeField] private float resourceCollected = 0f;
    

    //GameObject resourceCounterObject;
    TextMesh resourceCounterTextMesh;
    #endregion

    #region getters_and_setters
    public float ResourceCollected
    {
        get
        {
            return resourceCollected;
        }

    }
    #endregion

    void Start()
    {
        GameObject resourceCounterObject = gameObject.transform.Find("Resource Counter").gameObject;
        resourceCounterTextMesh = resourceCounterObject.GetComponent<TextMesh>();

        UpdateResourceCounterTextMesh();

        elevatorManager = FindObjectOfType<ElevatorBuildingManager>();
        //mineBoxController = FindObjectOfType<MineboxController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveElevator();
    }

    private void MoveElevator()
    {
        if (isMoving)
        {
            //Bounds areaBounds = boxCollider.bounds;

            Vector3 currentPosition = transform.position;
            float newYPos = currentPosition.y + movementSpeed * Time.deltaTime;

            //newYPos = Mathf.Clamp(newYPos, areaBounds.min.y, areaBounds.max.y);

            transform.position = new Vector2(currentPosition.x, newYPos);

            /*if (transform.position.y == areaBounds.min.y || transform.position.y == areaBounds.max.y)
            {
                movementSpeed -= movementSpeed * 2f;
            }*/
        }
    }

    private void ChangeDirection()
    {
        //TODO: Change elevator movement
        movementSpeed -= movementSpeed * 2;
    }

    private void DropOffResources()
    {
        //TODO: Drop off resources to the elevator building
        elevatorManager.AddResources(resourceCollected);
        resourceCollected = 0f;
    }

    private void CollectResources()
    {
        if (resourceCollected < capacity)
        {
            resourceCollected = Mathf.Clamp(mineBoxController.TotalResource, 0f, capacity);
            UpdateResourceCounterTextMesh();
        }
        if (resourceCollected >= capacity)
        {
            collectResources = false;
            ChangeDirection();
        }
    }

    void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = resourceCollected.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {               
        if (collision.transform.tag == "elevator_shaft_top")
        {
            DropOffResources();
            UpdateResourceCounterTextMesh();
            elevatorManager.UpdateResourceCounterTextMesh();
            collectResources = true;
            ChangeDirection();
        }
        else if (collision.transform.tag == "elevator_shaft_bottom")
        {
            collectResources = false;
            ChangeDirection();
        }
        else if (collision.transform.tag == "mine_trigger" && collectResources)
        {
            GameObject mineBoxControllerObj = collision.transform.parent.Find("Mine Box").gameObject;
            mineBoxController = mineBoxControllerObj.GetComponent<MineboxController>();

            CollectResources();
            mineBoxController.TotalResource -= resourceCollected;
            mineBoxController.UpdateResourceCounterTextMesh();

            
        }
    }

}
