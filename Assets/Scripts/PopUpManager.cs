using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameManager gameManager; //We need the cursor.


    public bool movable; //If you can drag to move the popup.
    public bool closable; //If you can close the popup. Minimising sounds too difficult.

    //Colour of disabled close button.
    public Color inactiveCloseColor;
    public Color activeCloseColor;

    //GameObjects relevant.
    private GameObject topBar;
    private GameObject closeButton;

    private Transform popUpParent;

    //Mouse info.
    private bool clickDown;
    private bool clickHeld;
    private bool clickUp;

    private bool connected;

    Bounds cursor;

    public GameObject nextConvoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Find all gameObjects.
        topBar = transform.Find("PopUpTopBar").gameObject;
        closeButton = topBar.transform.Find("CloseButton").gameObject;
        popUpParent = transform.parent;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //First, get cursor Bounds (for collision detection).
        cursor = gameManager.cursor.GetComponent<SpriteRenderer>().bounds;

        //Next, get click information.
        clickHeld = Input.GetMouseButton(0);
        clickDown = Input.GetMouseButtonDown(0);
        clickUp = Input.GetMouseButtonUp(0);

        //Do top bar stuff (dragging the top bar to move it)
        if (movable) DoTopBar();

        //Do close stuff (clicking the close button deletes it)
        if (closable) DoClose();

        //Set the colour of the close bar.
        closeButton.GetComponent<SpriteRenderer>().color = closable ? activeCloseColor : inactiveCloseColor;
    }

    private void DoTopBar()
    {
        bool touchingTopBar = cursor.Intersects(topBar.GetComponent<SpriteRenderer>().bounds);

        bool emptyCursor = gameManager.cursor.childCount == 0;

        //If mouse button down, connect.
        if(touchingTopBar && clickDown && emptyCursor)
        {
            transform.parent = gameManager.cursor;
            connected = true;
        }

        //If mouse button up, disconnect.
        if(connected && clickUp)
        {
            popUpParent.transform.position = transform.position;
            transform.parent = popUpParent;
            connected = false;
        }
    }

    private void DoClose()
    {
        bool touchingCloseButton = cursor.Intersects(closeButton.GetComponent<SpriteRenderer>().bounds);

        if (clickDown && touchingCloseButton)
        {
            //The first step is to disconnect - it'll be dragging the top bar ahh hell
            popUpParent.transform.position = transform.position;
            transform.parent = popUpParent;
            connected = false;

            Animator animator = popUpParent.GetComponent<Animator>();
            animator.Play("Close");
            Destroy(popUpParent.gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    public void DownloadPressed()
    {
        //The first step is to disconnect - it'll be dragging the top bar ahh hell
        popUpParent.transform.position = transform.position;
        transform.parent = popUpParent;
        connected = false;

        Animator animator = popUpParent.GetComponent<Animator>();
        animator.Play("Close");
        Destroy(popUpParent.gameObject, animator.GetCurrentAnimatorStateInfo(0).length);

        if(nextConvoPrefab != null) gameManager.SpawnSecondDialog(nextConvoPrefab);
    }
}
