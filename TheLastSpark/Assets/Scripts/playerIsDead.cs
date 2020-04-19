using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIsDead : MonoBehaviour
{
    bool demise = false;
    float deadtimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (demise == true)
        {
            deadtimer += Time.deltaTime;
        }
        if (deadtimer >= 5f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
    }

    public void Dead()
    {
        demise = true;
    }
}


