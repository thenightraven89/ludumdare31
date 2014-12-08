using UnityEngine;
using System.Collections;

public class TeleportFinal : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && StageManager.instance.seenBlood)
        {
            other.gameObject.transform.Translate(new Vector3(0f, -10f, 0f));
        }
    }
}
