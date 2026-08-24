using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public bool movable; //If you can drag to move the popup.
    public bool scalable; //If you can resize the popup. Scaling will likely have to be proportionate.
    public bool closable; //If you can close the popup. Minimising sounds too difficult.


    private GameObject topBar;
    private GameObject resizeTriangle;
    private GameObject closeButton;

    // Start is called before the first frame update
    void Start()
    {
        topBar = transform.Find("PopUpTopBar").gameObject;
        resizeTriangle = transform.Find("ScalableTriangle").gameObject;
        closeButton = transform.Find("CloseButton").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
