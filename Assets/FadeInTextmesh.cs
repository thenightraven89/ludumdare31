using UnityEngine;
using System.Collections;

public class FadeInTextmesh : MonoBehaviour
{

    // Use this for initialization
    void OnEnable()
    {
        LeanTween.value(gameObject, "SetA", 0f, 1f, 4f);
    }

    private void SetA(float value)
    {
        GetComponent<TextMesh>().color = new Color(0f, 0f, 0f, value);
    }
}