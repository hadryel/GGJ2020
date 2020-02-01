using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject CarryingSlot;
    public GameObject Carried;

    public ElevatorDoor currentDoor;

    public float movementSpeed = 2.5f;

    void Start()
    {

    }

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

    public bool WaitingCurrentDoor()
    {
        // return currentDoor.DoorOpening() || currentDoor.DoorClosing();
        return !currentDoor.doorOpen;
    }

    public void SetCarried(GameObject carried)
    {
        if (carried.GetComponent<Patient>())
        {
            //This is the logic for patient
            carried.GetComponent<SpriteRenderer>().sortingOrder = 2;
            carried.GetComponent<Patient>().enabled = false;
            carried.GetComponent<BoxCollider2D>().enabled = false;

            carried.transform.parent = CarryingSlot.transform;
            carried.transform.localPosition = new Vector3(0.554f, 1.029f, 0);
            carried.transform.localRotation = Quaternion.AngleAxis(90f, Vector3.forward);
            Carried = carried;
        }
        else if (carried.GetComponent<Medicine>())
        {
            carried = GameObject.Instantiate(carried);
            carried.transform.parent = CarryingSlot.transform;
            carried.transform.localPosition = new Vector3(0.554f, 1.029f, 0);
            carried.transform.localRotation = Quaternion.AngleAxis(90f, Vector3.forward);
            carried.SetActive(true);
            Carried = carried;
        }
    }

    public void DropCarried(GameObject Target)
    {
        if (Carried.GetComponent<Patient>() && !Carried.GetComponent<Patient>().treated && Target.GetComponent<EmptyHospitalBed>())
        {
            // Logic for patient
            Carried.transform.parent = Target.transform;
            Carried.transform.localPosition = Vector3.zero + new Vector3(0.5f, 0, 0);
            Target.GetComponent<EmptyHospitalBed>().enabled = false;
            var occupiedBed = Target.GetComponent<OccupiedHospitalBed>();
            occupiedBed.Target = Carried;
            occupiedBed.enabled = true;
        }
        else if (Target.GetComponent<DischargeArea>() && Carried.GetComponent<Patient>() && Carried.GetComponent<Patient>().treated)
        {
            GameObject.Destroy(Carried);
        }
    }

    public void TreatTarget(GameObject Target)
    {
        Target.GetComponent<Patient>().Treat(Carried.GetComponent<Medicine>());
    }
}
