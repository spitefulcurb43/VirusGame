using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmBar : MonoBehaviour
{
    public float drainrate;
    public float bonusOnKeyScore;
    public float maxBarSize;

    // REMOVE WHEN GAMEMANAGER CAPS FPS
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (transform.localScale.y > 0) transform.localScale -= Vector3.up * drainrate;
        else transform.localScale = new Vector3 (transform.localScale.x, 0, 1);
    }

    public void ExtendBar()
    {
        if (transform.localScale.y < maxBarSize) transform.localScale += Vector3.up * bonusOnKeyScore;
        else transform.localScale = new Vector3 (transform.localScale.x, maxBarSize, 1);
    }

    public void DamageBar()
    {
        // Half damage to account for the drain
        if (transform.localScale.y < maxBarSize) transform.localScale -= Vector3.up * bonusOnKeyScore / 2;
        else transform.localScale = new Vector3 (transform.localScale.x, maxBarSize, 1);
    }
}
