using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class InternetExplorerScript : MonoBehaviour
{
    public TextMeshPro text;
    public string searchBarText;
    public float letterDelay;
    public string searchTerm;

    public GameObject searchBit;
    public GameObject resultsBit;
    public GameObject webPageBit;
    public bool startProperly = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnterSearchTerm(searchTerm, letterDelay));
        if (startProperly)
        {
            searchBit.SetActive(true);
            resultsBit.SetActive(false);
            webPageBit.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator EnterSearchTerm(string message, float letterDelay)
    {
        //Do this for each character consecutively.
        foreach(char c in message)
        {
            searchBarText += c;
            text.text = searchBarText;

            float randMod = Random.Range(0.2f, 0.75f); //random modifier to the delay.
            yield return new WaitForSeconds(letterDelay * randMod * 2f);
        }

        float rand2Mod = Random.Range(0.2f, 0.75f); //random modifier to the delay.
        yield return new WaitForSeconds(letterDelay * rand2Mod * 3.5f);

        //Then, we search.
        searchBit.SetActive(false);
        resultsBit.SetActive(true);
    }

    public void LinkClicked()
    {
        resultsBit.SetActive(false);
        webPageBit.SetActive(true);
    }
}
