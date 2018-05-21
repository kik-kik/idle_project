using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MinerController : MonoBehaviour {

    #region variables
    [SerializeField] private bool move = false;
    [SerializeField] private bool manager = false;

    [Header("Speed")]
    [SerializeField] private float movementSpeed = 1f;
    [Range(1,3)]
    [SerializeField] private float movementSpeedModifier = 1f;
    [SerializeField] private float miningSpeed = 1f;
    [SerializeField] private float miningRate = 1f;
    [SerializeField] float capacity = 100f;

    private float resourceCollected = 0f;

    private MineboxController mineBoxController;

    #endregion

    private void OnMouseDown()
    {
        move = true;
    }

    private void Start()
    {
        mineBoxController = GetComponent<MineboxController>();
    }

    // Update is called once per frame
    void Update () {

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
        float translatePos = movementSpeed * movementSpeedModifier * Time.deltaTime;
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

    void MineResource()
    {
        while (capacity <= resourceCollected)
        {
            resourceCollected += miningRate * miningRate;
        }
    }

    void DropOffResources()
    {
        while (resourceCollected > 0f)
        {
            resourceCollected -= miningRate * miningRate;
        }
        //TODO: Update the totalResource in the box controller
        print(mineBoxController.TotalResource);
        mineBoxController.TotalResource += resourceCollected;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "mining_source")
        {
            print("collecting coins");
            MineResource();
        }
        else if (col.transform.tag == "minebox")
        {
            print("dropping coins");
            DropOffResources();
        }

        RotateCharacter();
    }
}
