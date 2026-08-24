using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameStates { Intro, Playable, Win, Lose }; //Game States, starts at Intro. (I don't think we need a menu screen)
    public GameStates gameState;


    //This should be useful.
    public Transform cursor;

    // Start is called before the first frame update
    void Start()
    {
        cursor = transform.Find("Cursor");
    }

    // Update is called once per frame
    void Update()
    {
        DoCursor();
    }


    private void DoCursor()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.position = mousePos;
    }
}
