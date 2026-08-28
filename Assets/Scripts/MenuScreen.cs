using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public GameObject dotPrefab;
    public Transform dotParent;

    public string password;
    public string correctPassword = "password";

    public int maxPasswordLength;

    public GameObject messageScreen;

    public bool enableOnStart;
    // Start is called before the first frame update
    void Start()
    {
        if (enableOnStart) GetComponent<Canvas>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        foreach (char c in Input.inputString)
        {
            if(c == '\b') //backspace pressed
            {
                //do backspace
                if(password.Length > 0)
                {
                    Destroy(dotParent.GetChild(dotParent.childCount - 1).gameObject); //remove last kid
                    password = password.Substring(0, password.Length - 1); //remove 1 from password
                }
            }
            else if ((c == '\n') || (c == '\r')) //enter
            {
                CheckPassword();
            }
            else if (password.Length <= maxPasswordLength)
            {
                Instantiate(dotPrefab, Vector3.zero, Quaternion.identity, dotParent); //Add a dot.
                password += c; //Add character to password.
            }
        }
    }

    public void CheckPassword()
    {
        if (password == correctPassword)
        {
            print("UNLOCKED! " + password);
            GetComponent<Canvas>().enabled = false;

            StartCoroutine(ActivateWithDelay(messageScreen, 0.75f));
        }
        else
        {
            print("incorrect " + password);
            foreach (Transform kid in dotParent) Destroy(kid.gameObject);
            password = "";
        }
    }

    private IEnumerator ActivateWithDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }
}
