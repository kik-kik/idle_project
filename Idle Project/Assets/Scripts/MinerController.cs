using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MinerController : MonoBehaviour {

    #region variables
    [Header("Movement")]
    [SerializeField] private bool move = false;
    [SerializeField] private bool manager = false;

    [Header("Speed")]
    [Range(10, 32)]
    [SerializeField] private float movementSpeed = 16f;
    [Range(1,3)]
    [SerializeField] private float movementSpeedModifier = 1f;

    /*
    [Header("Mining")]
    [Range(1, 3)]
    [SerializeField] private float miningSpeed = 1f;
    [Range(1, 3)]
    [SerializeField] private float miningRate = 1f;
    */

    [Header("Collection")]
    [SerializeField] private float capacity = 100f;
    [SerializeField] private float resourceCollected = 0f;

    Collider2D collider;

    GameObject resourceCounterObject;
    TextMesh resourceCounterTextMesh;

    MineboxController mineBoxController;
    #endregion


    /// <summary>
    /// This method gets called when the character gets clicked.
    /// </summary>
    private void OnMouseDown()
    {
        move = true;
    }

    private void Start()
    {
        resourceCounterObject = gameObject.transform.Find("Resource Counter").gameObject;
        resourceCounterTextMesh = resourceCounterObject.GetComponent<TextMesh>();

        collider = GetComponent<Collider2D>();

        GameObject mineBoxControllerObj = transform.parent.Find("Mine Box").gameObject;
        mineBoxController = mineBoxControllerObj.GetComponent<MineboxController>() ;
    }

    void Update ()
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
            float translatePos = movementSpeed * movementSpeedModifier * Time.deltaTime;
            transform.Translate(translatePos, 0f, 0f);
        }   
    }

    /// <summary>
    /// This method rotates the target by 180 degrees on the Y axis.
    /// </summary>
    void RotateCharacter()
    {
        transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
        ResetCounterRotation();
    }

    /// <summary>
    /// This method sets the Counter rotation to 180 to avoid the text rotating with the character.
    /// </summary>
    void ResetCounterRotation()
    {
        resourceCounterObject.transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
    }

    /// <summary>
    /// This method updates the label above the character to display the current value.
    /// </summary>
    void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = resourceCollected.ToString();
    }

    /// <summary>
    /// Sets resourceCollected value to match the capacity of the character and updates the characters label.
    /// </summary>
    void MineResource()
    {
        if (resourceCollected < capacity)
        {
            resourceCollected = capacity;
        }
        UpdateResourceCounterTextMesh();
    }

    /// <summary>
    ///  Removes resourceCollected from the character and adds it to its box and updates box and characters labels.
    /// </summary>
    void DropOffResources()
    {
        mineBoxController.TotalResource += resourceCollected;
        mineBoxController.UpdateResourceCounterTextMesh();

        resourceCollected = 0f;
        UpdateResourceCounterTextMesh();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "mining_source")
        {
            MineResource();
        }
        else if (col.transform.tag == "minebox")
        {
            DropOffResources();
        }
        RotateCharacter();
    }
}
