using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    #region variables
    [Header("Movement")]
    [SerializeField] private bool isMoving = true;
    [Tooltip("- speed moves elevator down, + speed moves elevator up")] [Range(-30, 30)]
    [SerializeField] private float movementSpeed = -1f;

    [Header("Collection")]
    [SerializeField] private bool collectResources = true;
    [SerializeField] private float capacity = 100f;
    [SerializeField] private float resourceCollected = 0f;

    ElevatorBuildingManager elevatorManager;
    MineboxController mineBoxController;

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
    }


    void Update()
    {
        MoveElevator();
    }


    /// <summary>
    /// This method moves the elevator.
    /// </summary>
    private void MoveElevator()
    {
        if (isMoving)
        {
            Vector2 currentPosition = transform.position;
            float newYPos = currentPosition.y + movementSpeed * Time.deltaTime;
            transform.position = new Vector2(currentPosition.x, newYPos);
        }
    }

    /// <summary>
    /// This method changes the direction of the elevator (down, up)
    /// </summary>
    private void ChangeDirection()
    {
        movementSpeed -= movementSpeed * 2;
    }

    /// <summary>
    /// Moves the value of resourceCollected to the elevatormanager and sets the value held by the elevator/this object to 0.
    /// </summary>
    private void DropOffResources()
    {
        elevatorManager.AddResources(resourceCollected);
        elevatorManager.UpdateResourceCounterTextMesh();

        resourceCollected = 0f;
        UpdateResourceCounterTextMesh();
    }

    /// <summary>
    /// This method is responsible for removing resources from a minebox and adding it to the resource held by the elevator. The value depends on the amount of space left on the elevator.
    /// </summary>
    private void CollectResources()
    {
        if (resourceCollected < capacity)
        {
            float spaceAvailable = capacity - resourceCollected;
            float resourceAvailable = Mathf.Clamp(mineBoxController.TotalResource, 0f, spaceAvailable);

            resourceCollected += resourceAvailable;
            mineBoxController.TotalResource -= resourceAvailable;

            UpdateResourceCounterTextMesh();
        }

        if (resourceCollected >= capacity)
        {
            collectResources = false;
            ChangeDirection();
        }
    }


    /// <summary>
    /// This method updates the label showing the current value of the resourceCollected by the elevator.
    /// </summary>
    void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = resourceCollected.ToString();
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
            GameObject mineBoxControllerObj = collision.transform.parent.Find("Mine Box").gameObject;
            mineBoxController = mineBoxControllerObj.GetComponent<MineboxController>();

            CollectResources();
            
            mineBoxController.UpdateResourceCounterTextMesh();
        }
    }

}
