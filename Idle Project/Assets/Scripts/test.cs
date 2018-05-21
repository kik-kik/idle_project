using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    ElevatorController elevator;
    BoxCollider2D BoxCol2D;

    private void Start()
    {
        BoxCol2D = GetComponent<BoxCollider2D>();
        elevator = FindObjectOfType<ElevatorController>();
    }

    private void ElevatorStuff()
    {
        print(Time.deltaTime);
        print("inside elevator stuff");
        float timer = 0f;
        while (timer < 50f)
        {
            timer += Time.deltaTime;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");

        ElevatorStuff();
        //for (int i = 0; i > 10; i++)
        //{
        //    print(i);
        //}
        //elevator.isMoving = true;
    }
}
