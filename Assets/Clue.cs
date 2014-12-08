using UnityEngine;
using System.Collections;

public class Clue : MonoBehaviour
{
    public ClueType clueType;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasLeft = false;
            StartCoroutine(Freakout());

            switch (clueType)
            {
                case ClueType.Candles:
                    StageManager.instance.seenCandles = true;
                    break;

                case ClueType.Blood:
                    StageManager.instance.seenBlood = true;
                    break;

                default:
                    break;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasLeft = true;
        }
    }

    private bool hasLeft = false;

    private IEnumerator Freakout()
    {
        while (!hasLeft)
        {
            yield return new WaitForSeconds(2.5f);
            StartCameraCraze();
            yield return new WaitForSeconds(2.5f);
            StopCameraCraze();
        }
        yield return null;
    }

    public void StartCameraCraze()
    {
        LeanTween.value(gameObject, "SetCameraFOV", 60f, 120f, 2.5f);
    }

    public void StopCameraCraze()
    {
        LeanTween.value(gameObject, "SetCameraFOV", 120f, 60f, 2.5f);
    }

    private void SetCameraFOV(float value)
    {
        Camera.main.fieldOfView = value;
    }

    public enum ClueType
    {
        Candles,
        Blood
    }
}