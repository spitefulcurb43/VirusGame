using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTabGrowth : MonoBehaviour
{
    public float sizeLimit;
    public float growthPerSecond;
    void Update()
    {
        if(transform.localScale.x < sizeLimit) transform.localScale += new Vector3(growthPerSecond/60, growthPerSecond/60, growthPerSecond/60);
    }
}
