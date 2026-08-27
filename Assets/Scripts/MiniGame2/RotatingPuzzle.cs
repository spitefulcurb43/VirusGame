using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatingPuzzle : MonoBehaviour
{
    public Transform rot;
    public TextMesh text;
    public int frames;

    // This will stay until gameManager caps it.
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        text.text = $"{Math.Round(rot.eulerAngles.z, 2)}°";

        if(rot.eulerAngles.z == 0)
        {
            frames++;
        }
        else
        {
            frames = 0;
        }

        if(frames == 100)
        {
            // CALLS GAMEMANAGER HERE
        }
    }
}
