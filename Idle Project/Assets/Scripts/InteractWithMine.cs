using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithMine : MonoBehaviour {

    MineboxController minebox;
    //ElevatorController elevatorController;

    private void Start()
    {
        minebox = FindObjectOfType<MineboxController>();
    }

    public void UpdateMineBoxStats(float quantityToRemove)
    {
        minebox.TotalResource -= quantityToRemove;
    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "elevator")
        {
            elevatorController = collision.gameObject.GetComponent<ElevatorController>();
            minebox.TotalResource -= elevatorController.ResourceCollected;
        }
    }*/
}
