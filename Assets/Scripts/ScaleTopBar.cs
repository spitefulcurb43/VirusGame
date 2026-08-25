using System.Collections;
using System.Collections.Generic;
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

    private Vector2 windowSize;

    private Transform topBar;
    private Transform closeButton;

    public RectTransform popUpName;

    public Transform topBorder;
    public Transform bottomBorder;
    public Transform leftBorder;
    public Transform rightBorder;

    private void Start()
    {
        topBar = transform.Find("PopUpTopBar");
        closeButton = transform.Find("CloseButton");

        popUpName = topBar.Find("Name").GetComponent<RectTransform>();
    }

    void Update()
    {
        //Find the width of the window.
        windowSize = transform.lossyScale;

        //Set the desired size of top bar to the width of the window & height defined by the above variable.
        Vector2 topBarScale = new(windowSize.x + borderSize * 2, height);
        topBar.localScale = Vector3.one;
        topBar.localScale = new Vector2(topBarScale.x / topBar.lossyScale.x, topBarScale.y / topBar.lossyScale.y);

        Vector2 closeButtonScale = new(topBar.lossyScale.y, topBar.lossyScale.y);

        //Next, do the close button.
        closeButton.localScale = Vector3.one;
        closeButton.localScale = new Vector2(closeButtonScale.x / closeButton.lossyScale.x, closeButtonScale.y / closeButton.lossyScale.y);

        //Now, sort out the pop up name.
        Vector2 textScale = new(popUpName.lossyScale.x, popUpName.lossyScale.x);
        popUpName.localScale = Vector3.one;
        popUpName.localScale = new Vector2(textScale.x / popUpName.lossyScale.x, textScale.y / popUpName.lossyScale.y);


        popUpName.sizeDelta = new(popUpName.sizeDelta.x, 1f / popUpName.localScale.y);

        //Do borders!

        Vector2 verticalBorderScale   = new(windowSize.x + borderSize * 2, borderSize); //Top, Bottom
        Vector2 horizontalBorderScale = new(borderSize, windowSize.y); //Left, Right

        topBorder.localScale = Vector3.one;
        leftBorder.localScale = Vector3.one;

        Vector2 verticalBorderSize = new(verticalBorderScale.x / topBorder.lossyScale.x, verticalBorderScale.y / topBorder.lossyScale.y);
        Vector2 horizontalBorderSize = new(horizontalBorderScale.x / leftBorder.lossyScale.x, horizontalBorderScale.y / leftBorder.lossyScale.y);

        topBorder.localScale = verticalBorderSize;
        bottomBorder.localScale = verticalBorderSize;
        leftBorder.localScale = horizontalBorderSize;
        rightBorder.localScale = horizontalBorderSize;
    }
}
