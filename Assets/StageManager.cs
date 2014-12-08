using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    private StageState state;

    public static StageManager instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
        state = StageState.Stage1;
        screen.renderer.material = maps[0];

        snowman.SetActive(false);
        noteConnor.SetActive(false);
        noteDimitri.SetActive(false);
    }

    [HideInInspector]
    public bool heardDimitri1;

    [HideInInspector]
    public bool heardDimitri2;

    [HideInInspector]
    public bool seenSnowman;

    [HideInInspector]
    public bool heardConnor;

    [HideInInspector]
    public bool seenCandles;

    [HideInInspector]
    public bool heardDimitri3;

    [HideInInspector]
    public bool heardRogers;

    [HideInInspector]
    public bool seenBlood;

    public GameObject screen;

    public Material[] maps;

    public GameObject snowman;

    public GameObject dimitriLaptop1;
    public GameObject dimitriLaptop2;
    public GameObject dimitriLaptop3;

    public GameObject noteConnor;

    public GameObject noteDimitri;

    public GameObject noteCantina;

    public void Progress()
    {
        switch (state)
        {
            case StageState.Stage1:
                state = StageState.Stage2;
                Debug.Log("2");
                screen.renderer.material = maps[1];

                dimitriLaptop1.SetActive(true);
                dimitriLaptop2.SetActive(false);
                dimitriLaptop3.SetActive(false);

                noteDimitri.SetActive(true);                

                break;

            case StageState.Stage2:
                if (heardDimitri1)
                {
                    state = StageState.Stage3;
                    Debug.Log("3");
                    screen.renderer.material = maps[2];

                    dimitriLaptop1.SetActive(false);
                    dimitriLaptop2.SetActive(true);
                    dimitriLaptop3.SetActive(false);

                    snowman.SetActive(true);
                }
                break;

            case StageState.Stage3:
                if (heardDimitri2 && seenSnowman)
                {
                    state = StageState.Stage4;
                    Debug.Log("4");
                    screen.renderer.material = maps[3];

                    noteConnor.SetActive(true);
                    snowman.SetActive(false);
                    noteCantina.SetActive(false);
                }
                break;

            case StageState.Stage4:
                if (heardConnor)
                {
                    state = StageState.Stage5;
                    Debug.Log("5");
                    screen.renderer.material = maps[4];

                    dimitriLaptop1.SetActive(false);
                    dimitriLaptop2.SetActive(false);
                    dimitriLaptop3.SetActive(true);
                    noteCantina.SetActive(true);
                }
                break;

            case StageState.Stage5:
                if (seenCandles && heardDimitri3)
                {
                    state = StageState.Stage6;
                    Debug.Log("6");
                    screen.renderer.material = maps[5];
                }
                break;

            case StageState.Stage6:
                if (heardRogers && seenBlood)
                {
                    state = StageState.Stage7;
                    Debug.Log("7");
                    screen.renderer.material = maps[6];
                }
                break;

            case StageState.Stage7:
                Debug.Log("8?");
                screen.renderer.material = maps[7];
                break;

            default:
                break;
        }
    }

    private enum StageState
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        Stage6,
        Stage7
    }
}