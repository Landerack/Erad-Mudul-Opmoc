using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageComponent : MonoBehaviour
{
    public Canvas body;

    public float damageAmount = 10.0f;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            body.GetComponent<HealthBar>().DecreaseHealth(damageAmount);
        }

    }

}
