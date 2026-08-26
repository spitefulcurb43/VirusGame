using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Jobs;


//READ THIS
//This script calculates what the top bar of a pop up window should look like based on its size.
//This could allow for scalable windows, but should also just be convenient.

[ExecuteInEditMode]
public class ScaleTopBar : MonoBehaviour
{
    //This will be put on the top bar. It will scale it properly.
    public float height = 0.45f;
    public float borderSize;
    public float fontSize;
    private float nameWidth = 40;

    private static float blueBarRatio = 0.57692307692f;
    private static float cornerRatio = 0.07692307692f;

    private Vector2 windowSize;

    public Transform topBar;
    public Transform closeButton;

    public RectTransform popUpName;

    public Transform bottomBorder;
    public Transform leftBorder;
    public Transform rightBorder;
    public Transform topLeftBorder;
    public Transform topRightBorder;

    private void Start()
    {
        popUpName = topBar.Find("Name").GetComponent<RectTransform>();

        blueBarRatio = 30f/52f;
        cornerRatio = 1f/13f;
    }

    void Update()
    {
        //Find the width of the window.
        windowSize = transform.lossyScale;

        //Set the desired size of top bar to the width of the window & height defined by the above variable.
        Vector2 topBarScale = new(windowSize.x, height);
        topBar.localScale = Vector3.one;
        topBar.localScale = new Vector2(topBarScale.x / topBar.lossyScale.x, topBarScale.y / topBar.lossyScale.y);

        Vector2 closeButtonScale = new(topBar.lossyScale.y * blueBarRatio, topBar.lossyScale.y * blueBarRatio);

        //Next, do the close button.
        closeButton.localScale = Vector3.one;
        closeButton.localScale = new Vector2(closeButtonScale.x / closeButton.lossyScale.x, closeButtonScale.y / closeButton.lossyScale.y);

        //Now, sort out the pop up name.
        Vector2 textScale = new(popUpName.lossyScale.x, popUpName.lossyScale.x);
        popUpName.localScale = Vector3.one;
        popUpName.localScale = new Vector2(textScale.x / popUpName.lossyScale.x, textScale.y / popUpName.lossyScale.y);

        //Make the size of the pop up bar consistent & not buggy.

        //First, get the width of the popups size (delta).
        float nameX = nameWidth * ((windowSize.x - borderSize - height) / windowSize.x);

        popUpName.sizeDelta = new(nameX, 1f / popUpName.localScale.y * blueBarRatio); //ratio

        //Do borders!

        Vector2 verticalBorderScale   = new(windowSize.x + borderSize * 2, borderSize); //Top, Bottom
        Vector2 horizontalBorderScale = new(borderSize, windowSize.y); //Left, Right

        bottomBorder.localScale = Vector3.one;
        leftBorder.localScale = Vector3.one;

        Vector2 verticalBorderSize = new(verticalBorderScale.x / bottomBorder.lossyScale.x, verticalBorderScale.y / bottomBorder.lossyScale.y);
        Vector2 horizontalBorderSize = new(horizontalBorderScale.x / leftBorder.lossyScale.x, horizontalBorderScale.y / leftBorder.lossyScale.y);

        bottomBorder.localScale = verticalBorderSize;
        leftBorder.localScale = horizontalBorderSize;
        rightBorder.localScale = horizontalBorderSize;

        //Top Corners of the Border!
        topLeftBorder.localScale  = new(horizontalBorderSize.x, topBar.localScale.y / 13); //13 is to do with the window sprite ratio
        topRightBorder.localScale = new(horizontalBorderSize.x, topBar.localScale.y / 13);

    }
}
