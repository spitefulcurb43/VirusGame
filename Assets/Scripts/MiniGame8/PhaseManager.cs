using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public int phase;
    public GameObject startMenu;

    public GameObject phase1Parent;
    public GameObject phase2Parent;
    public GameObject phase3Parent;
    // Phase 1 variables
    public List<GameObject> phase1Projectiles;
    public float phase1Cooldown;
    public bool phase1Cooling;

    // Phase 2 variables
    public List<GameObject> phase2Projectiles;
    public float phase2Cooldown;
    public bool phase2Cooling;

    // Phase 3 variables
    public List<GameObject> phase3Projectiles;
    public float phase3Cooldown;
    public bool phase3Cooling;

    // pops up the start menu to prepare phase 3
    public Transform startMenuStart;
    public Transform startMenuFinish;
    public float startMenuSpeed;

    /*
    PLAN
    Checks the phase first
    Phase 1 turns random desktop icons into homing missiles one after another
    Phase 2 turns random items on the taskbar that fires at the player and then bounces on the screen
    Phase 3 pops up the start menu before firing gravity-affected projectiles towards the player
    */

    void Start()
    {
        foreach(Transform child in phase1Parent.transform)
        {
            phase1Projectiles.Add(child.gameObject);
        }
        foreach(Transform child in phase2Parent.transform)
        {
            phase2Projectiles.Add(child.gameObject);
        }
        foreach(Transform child in phase3Parent.transform)
        {
            phase3Projectiles.Add(child.gameObject);
        }

        Application.targetFrameRate = 60;
        phase = 1;
    }
    void Update()
    {
        if(phase > 3)
        {
            // CALLS GAMEMANAGER TO WIN
        }
        if(phase == 0 && Input.GetKeyDown(KeyCode.A))
        {
            phase++;
        }
        if(phase == 1)
        {
            if(phase1Projectiles.Count > 0 && !phase1Cooling)
            {
                int randomNum = Random.Range(0, phase1Projectiles.Count);
                phase1Projectiles[randomNum].GetComponent<DesktopProjectile>().Trigger();
                phase1Projectiles.RemoveAt(randomNum);
                StartCoroutine(FireProjectile1());
            }
            if (phase1Projectiles.Count == 0 && !phase1Cooling)
            {
                phase++;
            }
        }
        if(phase == 2)
        {
            if(phase2Projectiles.Count > 0 && !phase2Cooling)
            {
                int randomNum = Random.Range(0, phase2Projectiles.Count);
                phase2Projectiles[randomNum].GetComponent<TaskbarProjectile>().Trigger();
                phase2Projectiles.RemoveAt(randomNum);
                StartCoroutine(FireProjectile2());
            }
            if (phase2Projectiles.Count == 0 && !phase2Cooling)
            {
                phase++;
            }
        }
        if(phase == 3)
        {
            if(startMenu.transform.position != startMenuFinish.transform.position) 
            {
                startMenu.transform.position = Vector3.MoveTowards(startMenu.transform.position, startMenuFinish.position, startMenuSpeed);

                // Short delay to prevent instant attacks
                if (startMenu.transform.position == startMenuFinish.position) StartCoroutine(FireProjectile3(phase3Cooldown * 5));
            }
            if(phase3Projectiles.Count > 0 && !phase3Cooling)
            {
                int randomNum = Random.Range(0, phase3Projectiles.Count);
                phase3Projectiles[randomNum].GetComponent<UtilitiesOrStartMenuProjectile>().Trigger();
                phase3Projectiles.RemoveAt(randomNum);
                StartCoroutine(FireProjectile3(phase3Cooldown));
            }
            if (phase3Projectiles.Count == 0 && !phase3Cooling)
            {
                phase++;
            }
        }
        else
        {
            if(startMenu.transform.position != startMenuStart.transform.position) startMenu.transform.position = Vector3.MoveTowards(startMenu.transform.position, startMenuStart.position, startMenuSpeed * 2);
        }
    }

    IEnumerator FireProjectile1()
    {
        phase1Cooling = true;
        yield return new WaitForSeconds(phase1Cooldown);
        phase1Cooling = false;
    }
    
    IEnumerator FireProjectile2()
    {
        phase2Cooling = true;
        yield return new WaitForSeconds(phase2Cooldown);
        phase2Cooling = false;
    }

    IEnumerator FireProjectile3(float cd)
    {
        phase3Cooling = true;
        yield return new WaitForSeconds(cd);
        phase3Cooling = false;
    }
}
