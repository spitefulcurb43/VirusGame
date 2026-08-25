using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTabExit : MonoBehaviour
{
    public Transform parent;
    void OnMouseDown()
    {
        Destroy(parent.gameObject);
    }
}
