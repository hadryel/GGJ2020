using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform CarryingSlot;
    public GameObject Carried;

    public ElevatorDoor currentDoor;

    public float movementSpeed = 2.5f;

    void FixedUpdate()
    {
        GetMovement();
    }

    public void GetMovement()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(0, rb2d.velocity.y);

        if (Input.GetKey(KeyCode.A))
            movement.x = -movementSpeed;
        else if (Input.GetKey(KeyCode.D))
            movement.x = movementSpeed;

        if (movement.x != 0)
        {
            var angle = (movement.x > 0) ? 180 : 0;
            transform.GetChild(0).localRotation = Quaternion.AngleAxis(angle, Vector3.up);

            GetComponentInChildren<Animator>().SetBool("IsWalking", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("IsWalking", false);
        }

        rb2d.velocity = movement;
    }

    public void EnterElevator(ElevatorDoor door)
    {
        currentDoor = door;
        door.StartCoroutine(EnterElevatorRoutine());
    }

    IEnumerator EnterElevatorRoutine()
    {
        yield return new WaitWhile(currentDoor.DoorClosing);

        gameObject.SetActive(false);
        currentDoor.GetComponent<Elevator>().enabled = true;
    }

    public void ExitElevator(Elevator elevator)
    {
        elevator.StartCoroutine(ExitElevatorRoutine());
    }

    IEnumerator ExitElevatorRoutine()
    {
        yield return currentDoor.StartCoroutine("OpenDoorRoutine");

        yield return new WaitWhile(currentDoor.DoorOpening);

        gameObject.SetActive(true);
    }

    public void TreatTarget(GameObject Target)
    {
        Target.GetComponent<Patient>().Treat(Carried.GetComponent<Medicine>());
    }
}
