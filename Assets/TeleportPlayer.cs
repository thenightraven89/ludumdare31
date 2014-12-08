using UnityEngine;
using System.Collections;

public class TeleportPlayer : MonoBehaviour
{
    public Transform destination;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageManager.instance.Progress();

            Vector3 distance = transform.position - other.transform.position;

            other.transform.position = new Vector3(destination.position.x + distance.z, other.transform.position.y, destination.position.z - distance.x);
            other.transform.rotation = Quaternion.Euler(0f, -90f, 0f) * other.transform.rotation;

            Vector3 v = other.GetComponent<CharacterMotor>().movement.velocity;
            other.GetComponent<CharacterMotor>().movement.velocity = new Vector3(-v.z, v.y, v.x);
        }
    }
}