using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class IntroMessageSequence : MonoBehaviour
{
    public float downAmount;
    public float upAmount;

    public float timeBetween;
    public float animTime;

    public Transform messageDisappearer;
    public Transform messages;

    public Transform disappearParent;
    public Transform messageParent;

    public float timeLastMoved;

    public int moveAmt;

    public int downs;

    public int messageAmt;

    public float d;
    public float m;

    public List<int> pauses;


    public Button okButton;

    // Start is called before the first frame update
    void Start()
    {
        d = downs * timeBetween;
        m = messageAmt * timeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if you have to pause on this dialog box. (So the player can 'reply')
        bool paused = pauses.Contains(moveAmt);

        //Check if enough time has passed for another message to appear.
        bool timePassed = timeLastMoved + timeBetween < Time.time;

        //Check if you have reached the end of the dialog.
        bool dialogOver = moveAmt > m;

        //Set activity of the OK button.
        okButton.interactable = paused;

        if(!paused && timePassed && !dialogOver)
        {
            MoveScreen();
            moveAmt++;
        }
    }

    private void MoveScreen()
    {
        if(moveAmt < d)
        {
            messageDisappearer.localPosition -= Vector3.up * downAmount;
            timeLastMoved = Time.time;
        }
        else
        {
            messages.localPosition += Vector3.up * upAmount;
            timeLastMoved = Time.time;
        }
    }

    public void ButtonPress()
    {
        MoveScreen();
        moveAmt++;
    }

}
