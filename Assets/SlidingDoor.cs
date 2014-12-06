using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour
{
    public bool isInitiallyOpen;

    private bool isOpen;

    public GameObject doorPiece;

    public Transform openPosition;
    public Transform closedPosition;

    public float doorOperatingTime;

    public void Start()
    {
        isOpen = isInitiallyOpen;
        InitializeDoor(isOpen);
    }

    #region methods for handling door operations

    public void OpenDoor()
    {
        LeanTween.moveLocalX(doorPiece, openPosition.localPosition.x, doorOperatingTime);
    }

    public void CloseDoor()
    {
        LeanTween.moveLocalX(doorPiece, closedPosition.localPosition.x, doorOperatingTime);
    }

    public void SetDoorOpen(bool value)
    {
        if (value)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    #endregion

    public void InitializeDoor(bool isOpen)
    {
        if (isOpen)
        {
            doorPiece.transform.localPosition = openPosition.transform.localPosition;
        }
        else
        {
            doorPiece.transform.localPosition = closedPosition.transform.localPosition;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Walls"))
        {
            OpenDoor();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Walls"))
        {
            CloseDoor();
        }
    }
}
