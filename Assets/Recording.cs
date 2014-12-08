using UnityEngine;
using System.Collections;

public class Recording : MonoBehaviour
{
    public AudioClip clip;

    public RecordingType recording;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, 100f))
            {
                audio.Stop();
                audio.PlayOneShot(clip);
            }

            switch (recording)
            {
                case RecordingType.Dimitri1:
                    StageManager.instance.heardDimitri1 = true;
                    break;

                case RecordingType.Dimitri2:
                    StageManager.instance.heardDimitri2 = true;
                    break;

                case RecordingType.Dimitri3:
                    StageManager.instance.heardDimitri3 = true;
                    break;

                case RecordingType.Connor:
                    StageManager.instance.heardConnor = true;
                    break;

                case RecordingType.Rogers:
                    StageManager.instance.heardRogers = true;
                    break;

                default:
                    break;
            }
        }
    }

    public enum RecordingType
    {
        Dimitri1,
        Dimitri2,
        Dimitri3,
        Connor,
        Rogers
    }
}