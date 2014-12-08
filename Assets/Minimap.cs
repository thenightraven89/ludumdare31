using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour
{
    public Material[] maps;

    void SetMap(int mapIndex)
    {
        if (mapIndex < maps.Length)
        {
            renderer.material = maps[mapIndex];
        }
    }
}