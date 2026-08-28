using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    //Enum Stuff
    public enum GameStates { Intro, Playable, Win, Lose }; //Game States, starts at Intro. (I don't think we need a menu screen)
    public GameStates gameState;



    //Relevant variables
    public int hp = 100; //How many files you have left.
    public int progress = 0; //How complete the antivirus installation is.

    //For help messages
    public Animator helpAnimator;
    public TextMeshPro helpText;
    

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

    public void SpawnSecondDialog(GameObject prefab)
    {
        StartCoroutine(DialogDelay(prefab));
    }
    private IEnumerator DialogDelay(GameObject prefab)
    {
        yield return new WaitForSeconds(3);
        Vector2 offset = new(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        Instantiate(prefab, offset, Quaternion.identity);
    }

    public void DoHelpMessage(string message, float time)
    {
        //Spawns in a help message for a certain amount of time.

        //The animation takes 0.5s to appear and 0.5s to disappear. We will spawn it, wait x time, and despawn it.

        helpText.text = message;
        StartCoroutine(HelpMessageTimer(time));
    }

    private IEnumerator HelpMessageTimer(float time)
    {
        helpAnimator.Play("Open");
        yield return new WaitForSeconds(time + helpAnimator.GetCurrentAnimatorStateInfo(0).length);
        helpAnimator.Play("Close");
    }

    public void SpawnMinigame(int minigameNumber)
    {
        if(minigameNumber == 1)
        {
            print("spawn minigame 1 one the first");
        }
        else if (minigameNumber == 2)
        {
            print("spawn minigame 2 two the second");
        }
    }


    public GameObject minigame1EndPrefab;
    public void EndMinigame(int minigameNumber)
    {
        if(minigameNumber == 1)
        {
            print("spawn next thing (google browser thing)");
            Instantiate(minigame1EndPrefab);
        }
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
