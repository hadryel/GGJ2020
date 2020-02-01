using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    Animator animator;
    public bool doorOpen;
    int floor;

    void Awake()
    {
        animator = GetComponent<Animator>();
        floor = GetComponent<Elevator>().floor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (doorOpen)
            return;

        StartCoroutine(OpenDoorRoutine());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!doorOpen)
            return;

        StartCoroutine(CloseDoorRoutine());
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space) && doorOpen)
        {
            other.GetComponent<Player>().EnterElevator(this);
        }
    }

    public IEnumerator OpenDoorRoutine()
    {
        animator.SetTrigger("DoorOpenFinishing");
        animator.SetTrigger("DoorOpenStarted");

        yield return new WaitUntil(DoorOpening);

        doorOpen = true;
    }

    public IEnumerator CloseDoorRoutine()
    {
        animator.SetTrigger("DoorCloseFinishing");
        animator.SetTrigger("DoorCloseStarted");
        // animator.SetBool("DoorOpenFinishing", false);
        // animator.SetBool("DoorOpenStarted", false);

        yield return new WaitUntil(DoorClosing);

        doorOpen = false;
    }

    public bool DoorOpening()
    {
        return !animator.GetBool("DoorOpenStarted") && animator.GetBool("DoorOpenFinishing");
    }

    public bool DoorClosing()
    {
        return !animator.GetBool("DoorCloseStarted") && animator.GetBool("DoorCloseFinishing");
    }

}
