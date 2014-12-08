using UnityEngine;
using System.Collections;

public class TriggerSnowmanHands : MonoBehaviour
{
    public GameObject[] hands;
    
    public GameObject finalmessage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < hands.Length; i++)
            {
                hands[i].SetActive(true);
            }
        }

        finalmessage.SetActive(true);
    }
}