using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTopBar : MonoBehaviour
{
    //This will be put on the top bar. It will scale it properly.
    public float height = 0.45f;

    

    [ExecuteInEditMode]
    void Update()
    {
        Vector2 globalScale = Vector2.one;

        transform.localScale = Vector3.one;
        transform.localScale = new Vector2(globalScale.x / transform.lossyScale.x, globalScale.y / transform.lossyScale.y);
    }
}
