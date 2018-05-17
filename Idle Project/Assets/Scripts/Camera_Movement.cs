using UnityEngine;


public class Camera_Movement : MonoBehaviour
{

    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    [SerializeField] private Camera linkedCamera;
    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponentInParent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            dragOrigin = Input.mousePosition;
            return;
        }
 
        if (!Input.GetMouseButton(0)) return;
 
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(0, pos.y * dragSpeed, 0);

        transform.Translate(move, Space.World);
    }


    private void LateUpdate()
    {
        float vertExtent = linkedCamera.orthographicSize;

        Vector3 linkedCameraPos = linkedCamera.transform.position;
        Bounds areaBounds = boxCollider.bounds; // can move to start?

        float minYMovement = areaBounds.min.y + vertExtent;
        float maxYMovement = areaBounds.max.y - vertExtent;

        float clampedYBoundary = Mathf.Clamp(linkedCameraPos.y, minYMovement, maxYMovement);

        linkedCamera.transform.position = new Vector3(linkedCameraPos.x, clampedYBoundary, linkedCameraPos.z);
    }

}
