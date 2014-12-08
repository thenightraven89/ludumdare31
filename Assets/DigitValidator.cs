using UnityEngine;
using System.Collections;

public class DigitValidator : MonoBehaviour
{
    public string validEntry;

    public ValidatorState initialState;

    private TextMesh textMesh;

    public SlidingDoor door;

    // Use this for initialization
    void Start()
    {
        state = initialState;
        textMesh = GetComponent<TextMesh>();
    }
    
    private ValidatorState state;

    public void AddDigit(string p)
    {
        if (state == ValidatorState.Locked)
        {
            textMesh.text += p;

            if (textMesh.text.Length == 4)
            {
                StartCoroutine(ValidationResultCoroutine());
            }
        }        
    }

    public enum ValidatorState
    {
        Locked,
        Unlocked,
        Blocked
    }

    private IEnumerator ValidationResultCoroutine()
    {
        state = ValidatorState.Blocked;

        yield return new WaitForSeconds(0.5f);

        if (textMesh.text == validEntry)
        {
            textMesh.text = "OPEN";            
        }
        else
        {
            textMesh.text = "ERROR";            
        }

        yield return new WaitForSeconds(1.5f);

        if (textMesh.text == "OPEN")
        {
            state = ValidatorState.Unlocked;
            door.Unlock();
        }

        if (textMesh.text == "ERROR")
        {
            state = ValidatorState.Locked;
        }

        textMesh.text = "";

        yield return null;
    }

    public void SetState(ValidatorState newState)
    {
        state = newState;
    }
}