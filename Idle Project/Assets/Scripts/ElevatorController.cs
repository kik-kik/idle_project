using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    private BoxCollider2D boxCollider;

    [SerializeField] private bool isMoving = true;
    [SerializeField] private float movementSpeed = -1f;

    [SerializeField] int max_capacity = 0;
    [SerializeField] private bool collect_resources = true;
    

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponentInParent<BoxCollider2D>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "elevator_shaft_top")
        {
            collect_resources = true;
            ChangeDirection();
        }
        else if (collision.transform.tag == "elevator_shaft_bottom")
        {   
            collect_resources = false;
            ChangeDirection();
        }
    }

}
