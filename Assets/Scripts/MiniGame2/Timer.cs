using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMesh timerText;
    public GameObject miniGame;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                timeLeft = 0;
                Lose();
            }
            timerText.text = timeLeft.ToString("0");
        }
    }

    void Lose() // you can reference gameManager here
    {
        print("you've lost!");
        miniGame.gameObject.SetActive(false);
    }
}
