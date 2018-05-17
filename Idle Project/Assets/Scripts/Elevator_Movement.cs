using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Movement : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private float movementSpeed = -1f;

    // Use this for initialization
    void Start () {
        boxCollider = GetComponentInParent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
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

    private void LateUpdate()
    {
        
    }

}
