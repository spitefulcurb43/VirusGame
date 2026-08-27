using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatingPuzzle : MonoBehaviour
{
    public Transform rot;
    public TextMesh text;
    public TextMesh rotateMeText;
    public GameObject rotatingMiniGame;
    private int randomDegree;
    private bool hasWon = false;
    // This will stay until gameManager caps it.
    void Start()
    {
        Application.targetFrameRate = 60;

        randomDegree = UnityEngine.Random.Range(0, 361);
    }

    void Update()
    {
        text.text = $"{Math.Round(rot.eulerAngles.z, 2)}°";
        rotateMeText.text = $"Rotate me: {randomDegree}";

        bool releasedArrow = Input.GetMouseButtonUp(0);

        if(!hasWon && releasedArrow && Mathf.DeltaAngle(rot.eulerAngles.z, randomDegree) == 0)
        {
            Win();
        }
    }

    void Win() // reference gamemanager here
    {
        hasWon = true;
        rotatingMiniGame.gameObject.SetActive(false);
        Debug.Log("you won!");
    }
}
