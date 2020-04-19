using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) { 
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
