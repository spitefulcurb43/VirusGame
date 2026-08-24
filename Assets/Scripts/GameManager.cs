using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameStates { Intro, Playable, Win, Lose }; //Game States, starts at Intro. (I don't think we need a menu screen)
    public GameStates gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
