using UnityEngine;
using System.Collections;

public class Digit : MonoBehaviour
{
    public DigitValidator validator;

    public TextMesh digitText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (collider.Raycast(ray, out hit, 100f))
            {
                validator.AddDigit(digitText.text);
            }
        }
    }
}