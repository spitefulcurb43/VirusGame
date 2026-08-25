using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingButtons : MonoBehaviour
{
    public RotatingPuzzle puzzleManager;
    public float rotation;
    public bool isRotating;

    void Update()
    {
        if (isRotating) puzzleManager.rot.Rotate(0,0,rotation);
    }
    void OnMouseDown()
    {
        isRotating = true;
    }

    void OnMouseUp()
    {
        isRotating = false;
    }
}
