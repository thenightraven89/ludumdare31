using UnityEngine;
using System.Collections;

public class SlidingDoor : MonoBehaviour
{
    public bool isInitiallyOpen;
    public bool isInitiallyLocked;

    private bool isOpen; // open as in position
    private bool isLocked; // locked as in passcode

    public GameObject[] doorPieces;

    public float doorOperatingTime;

    public void Start()
    {
        isOpen = isInitiallyOpen;
        isLocked = isInitiallyLocked;
        InitializeDoor(isOpen);
    }

    #region methods for handling door operations

    public void OpenDoor()
    {
        //LeanTween.moveLocalX(doorPiece, openPosition.localPosition.x, doorOperatingTime);

        for (int i = 0; i < doorPieces.Length; i++)
        {
            LeanTween.scaleX(doorPieces[i], 0.1f, doorOperatingTime);
        }

        isOpen = true;
    }

    public void CloseDoor()
    {
        //LeanTween.moveLocalX(doorPiece, closedPosition.localPosition.x, doorOperatingTime);

        //LeanTween.moveLocalX(doorPiece, openPosition.localPosition.x, doorOperatingTime);

        for (int i = 0; i < doorPieces.Length; i++)
        {
            LeanTween.scaleX(doorPieces[i], 1f, doorOperatingTime);
        }

        isOpen = false;
    }
    

    #endregion

    public void InitializeDoor(bool isOpen)
    {
        if (isOpen)
        {
            //LeanTween.moveLocalX(doorPiece, openPosition.localPosition.x, doorOperatingTime);

            for (int i = 0; i < doorPieces.Length; i++)
            {
                doorPieces[i].transform.localScale = new Vector3(0.1f, 1f, 1f);
            }
        }
        else
        {
            for (int i = 0; i < doorPieces.Length; i++)
            {
                doorPieces[i].transform.localScale = Vector3.one;
            }
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isLocked)
            {
                OpenDoor();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isLocked)
            {
                CloseDoor();
            }
        }
    }

    
    internal void Unlock()
    {
        isLocked = false;
    }

    internal void Lock()
    {
        isLocked = true;
    }
}
