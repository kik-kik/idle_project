using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    BoxCollider2D boxCollider;
    ElevatorBuildingManager elevatorManager;
    MineboxController mineBoxController;

    [SerializeField] private bool isMoving = true;
    [SerializeField] private float movementSpeed = -1f;

    [SerializeField] float capacity = 100f;
    [SerializeField] float resourceCollected = 0f;
    [SerializeField] private bool collectResources = true;
    

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponentInParent<BoxCollider2D>();
        elevatorManager = FindObjectOfType<ElevatorBuildingManager>();
        mineBoxController = FindObjectOfType<MineboxController>();
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
            Bounds areaBounds = boxCollider.bounds;

            Vector3 currentPosition = transform.position;
            float newYPos = currentPosition.y + movementSpeed * Time.deltaTime;

            newYPos = Mathf.Clamp(newYPos, areaBounds.min.y, areaBounds.max.y);

            transform.position = new Vector2(currentPosition.x, newYPos);

            if (transform.position.y == areaBounds.min.y || transform.position.y == areaBounds.max.y)
            {
                movementSpeed -= movementSpeed * 2f;
            }
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
            mineBoxController.TotalResource -= resourceCollected;
        }
        //TODO: Collect Resources from the elevator
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "elevator_shaft_top")
        {
            DropOffResources();
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
            CollectResources();
        }
    }

}
