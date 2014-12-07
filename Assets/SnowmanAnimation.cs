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

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(WalkCycle());
    }

    public Transform headTransform;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            headTransform.LookAt(other.transform.position);
        }
    }

    void OnTriggerExit()
    {
        LeanTween.rotateLocal(headTransform.gameObject, new Vector3(0f, 180f, 0f), 0.3f);        
    }
}
