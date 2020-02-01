using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public int floor;

    Player player;

    public Elevator NextFloor;
    public Elevator PreviousFloor;

    public ElevatorLight elevatorLight;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        elevatorLight = GetComponentInChildren<ElevatorLight>();
    }

    void Update()
    {
        GetPlayerInput();
    }

    void GetPlayerInput()
    {
        if (player.currentDoor.doorOpen)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.ExitElevator(this);
            enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (NextFloor == null)
                return;

            StartCoroutine(MovingRoutine(NextFloor));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (PreviousFloor == null)
                return;

            StartCoroutine(MovingRoutine(PreviousFloor));
        }
    }

    IEnumerator MovingRoutine(Elevator floor)
    {
        yield return null;

        elevatorLight.enabled = false;
        floor.elevatorLight.enabled = true;
        player.currentDoor = floor.GetComponent<ElevatorDoor>();
        enabled = false;
        floor.enabled = true;

        Vector3 destinyPos = player.transform.position;
        destinyPos.y = floor.transform.position.y - 0.55f;
        player.transform.position = destinyPos;
    }
}
