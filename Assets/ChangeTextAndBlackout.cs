using UnityEngine;
using System.Collections;

public class ChangeTextAndBlackout : MonoBehaviour
{
    public TextMesh endtext;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EndTheGame());
        }
    }

    private IEnumerator EndTheGame()
    {
        endtext.text = "THE END";
        yield return new WaitForSeconds(3f);
        Camera.main.enabled = false;
    }
}