using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//READ THIS
//This script calculates what the top bar of a pop up window should look like based on its size.
//This could allow for scalable windows, but should also just be convenient.

[ExecuteInEditMode]
public class ScaleTopBar : MonoBehaviour
{
    //This will be put on the top bar. It will scale it properly.
    public float height = 0.45f;

    private float windowSize;

    private Transform topBar;
    private Transform closeButton;

    private void Start()
    {
        topBar = transform.Find("PopUpTopBar");
        closeButton = transform.Find("CloseButton");
    }

    void Update()
    {
        //Find the width of the window.
        windowSize = transform.lossyScale.x;

        //Set the desired size of top bar to the width of the window & height defined by the above variable.
        Vector2 topBarScale = new(windowSize, height);

        //Set local scale (this is a funny trick but it works)
        topBar.localScale = Vector3.one;
        topBar.localScale = new Vector2(topBarScale.x / topBar.lossyScale.x, topBarScale.y / topBar.lossyScale.y);

        Vector2 closeButtonScale = new(topBar.lossyScale.y, topBar.lossyScale.y);

        //Next, do the close button.
        closeButton.localScale = Vector3.one;
        closeButton.localScale = new Vector2(closeButtonScale.x / closeButton.lossyScale.x, closeButtonScale.y / closeButton.lossyScale.y);

    }
}
