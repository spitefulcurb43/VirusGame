using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Enum Stuff
    public enum GameStates { Intro, Playable, Win, Lose }; //Game States, starts at Intro. (I don't think we need a menu screen)
    public GameStates gameState;



    //Relevant variables
    public int hp = 100; //How many files you have left.
    public int progress = 0; //How complete the antivirus installation is.


    

    // Start is called before the first frame update
    void Start()
    {
        //Initialise cursor
        cursor = transform.Find("Cursor");
    }

    // Update is called once per frame
    void Update()
    {
        DoCursor();
    }

    //Cursor
    public Transform cursor;
    private void DoCursor()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor.position = mousePos;
    }



    /*This is a struct I made to store some simple info about each minigame. 
    With this we could:
    - Load specific minigames
    - Load a minigame of a certain difficulty
    - Keep track of which minigames have previously spawned.

    (don't worry if you don't get how to add stuff to it, just ask me(freddie)!!!)
    */

    public MinigameInfo[] minigameInfos;

    [Serializable]
    public struct MinigameInfo
    {
        public string name;
        public Difficulty difficulty;
        public GameObject prefab;
    }
    public enum Difficulty { easy, medium, hard};
}
