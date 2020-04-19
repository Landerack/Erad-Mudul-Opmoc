using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineScript : MonoBehaviour
{
    public Canvas hpbar;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            
            hpbar.GetComponent<HealthBar>().IncreaseHealth(100f);
        }
    }
}
