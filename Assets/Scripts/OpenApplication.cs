using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenApplication : MonoBehaviour
{
    private GameManager gameManager;
    private Bounds cursorBounds;
    private SpriteRenderer renderer;

    public SpriteRenderer highlightRenderer;
    public float highlightAlpha;
    public float selectedAlpha;

    private bool closing = false;

    public bool clickedOnce;

    public GameObject applicationPopUp;
    public int spawnMinigame;
    public bool closeApplication;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cursorBounds = gameManager.cursor.GetComponent<SpriteRenderer>().bounds;

        if (cursorBounds.Intersects(renderer.bounds))
        {
            if (!clickedOnce) highlightRenderer.color = new(1f, 1f, 1f, highlightAlpha);

            if (Input.GetMouseButtonDown(0))
            {
                clickedOnce = true;
                highlightRenderer.color = new(1f, 1f, 1f, selectedAlpha);
            }
        }
        else if (!clickedOnce)
        {
            highlightRenderer.color = new(1f, 1f, 1f, 0f);
        }

        if (clickedOnce)
        {
            if (Input.GetMouseButtonDown(0)) //clicked again
            {
                //is touching object?
                if (cursorBounds.Intersects(renderer.bounds) && !closing)
                {
                    //You've double clicked, it will open
                    Open();
                }
                else
                {   //you've unclicked it
                    highlightRenderer.color = Color.clear;
                    clickedOnce = false;
                }
            }
        }
    }

    void Open()
    {
        print("yes it is open blud");
        if (applicationPopUp != null)
        {
            Instantiate(applicationPopUp);
        }
        if(spawnMinigame != 0)
        {
            gameManager.SpawnMinigame(spawnMinigame);
        }

        highlightRenderer.color = new(1f, 1f, 1f, 0f);

        if (closeApplication)
        {
            StartCoroutine(CloseAndDestroy());
        }
    }

    private IEnumerator CloseAndDestroy()
    {
        closing = true;
        Animator thisAnim = transform.parent.GetComponent<Animator>();

        thisAnim.Play("close");

        gameManager.SpawnMinigame(1);

        yield return new WaitForSeconds(thisAnim.GetCurrentAnimatorStateInfo(0).length);

        Destroy(transform.parent.gameObject);
    }
}
