using UnityEngine;


public class Camera_Movement : MonoBehaviour
{

    #region variables 
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    [SerializeField] private Camera linkedCamera;

    Bounds areaBounds;
    #endregion

    void Start()
    {
        areaBounds = GetComponentInParent<BoxCollider2D>().bounds;
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

        float minYMovement = areaBounds.min.y + vertExtent;
        float maxYMovement = areaBounds.max.y - vertExtent;

        float clampedYBoundary = Mathf.Clamp(linkedCameraPos.y, minYMovement, maxYMovement);

        linkedCamera.transform.position = new Vector3(linkedCameraPos.x, clampedYBoundary, linkedCameraPos.z);
    }

}
