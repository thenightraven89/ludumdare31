using UnityEngine;
using System.Collections;

public class SnowmanAnimation : MonoBehaviour
{
    private IEnumerator WalkCycle()
    {
        while (true)
        {
            LeanTween.scaleY(gameObject, 0.47f, 0.5f).setEase(LeanTweenType.linear).setLoopPingPong().setRepeat(2);
            yield return new WaitForSeconds(1.1f);
        }
    }
    
    public Transform headTransform;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            headTransform.LookAt(other.transform.position);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasLeft = true;
            LeanTween.rotateLocal(headTransform.gameObject, new Vector3(0f, 180f, 0f), 0.3f);        
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasLeft = false;
            StartCoroutine(Freakout());

            StageManager.instance.seenSnowman = true;
        }
    }

    private bool hasLeft = false;

    private IEnumerator Freakout()
    {
        while (!hasLeft)
        {            
            StartCameraCraze();
            yield return new WaitForSeconds(2.5f);
            StopCameraCraze();
            yield return new WaitForSeconds(2.5f);
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
}
