using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health = 100.0f;
    public float maxHealth = 100.0f;
    public AnimationCurve Playfull = new AnimationCurve();
    public Animator animator;
    public AudioSource hurtsounds;

    public Image animatedHealth;
    public Image healthBarImage = null;
    private float whiteFlashTimer = 0.01f;
    public float damageTimer = 0.0f;
    public float Imunity = 1.0f;
    public GameObject deathManager;

    public float incomeDmg = 10.0f;


    // Update is called once per frame
    void Update()
    {
        if (damageTimer < Imunity)
        {
            damageTimer += Time.deltaTime;
        }

        animatedHealth.rectTransform.sizeDelta = Vector2.Lerp(animatedHealth.rectTransform.sizeDelta, healthBarImage.rectTransform.sizeDelta, 0.01f);

        whiteFlashTimer += Time.deltaTime;

        float curvePosition = Playfull.Evaluate(whiteFlashTimer);
        float scaleFactor = curvePosition * 0.2f + 1.0f;
        GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }



    public void DecreaseHealth(float amount) {
        if (Imunity <= damageTimer)
        {

            float newHealth = health - amount;
            if (newHealth < 0.0f) {
                newHealth = 0.0f;
                hurtsounds.GetComponent<HurtSound>().DeathSound();
                //death animation.
                animator.SetBool("Dead", true);
                //trigger level end code.
                    deathManager.GetComponent<PlayerIsDead>().Dead();

            }
            else if (newHealth >= 0.0f)
            {
                hurtsounds.GetComponent<HurtSound>().RandomSoundness();
            }
            health = newHealth;
            whiteFlashTimer = 0.0f;

            if (healthBarImage != null)
            {
                healthBarImage.rectTransform.sizeDelta = new Vector2(health / maxHealth, healthBarImage.rectTransform.sizeDelta.y);
            }

            damageTimer = 0f;
        }
    }

    public void IncreaseHealth(float amount)
    {

        float newHealth = health + amount;
        hurtsounds.GetComponent<HurtSound>().HealSound();

        if (newHealth > 100.0f)
        {
            newHealth = 100.0f;
        }
            health = newHealth;

        if (healthBarImage != null)
        {
            healthBarImage.rectTransform.sizeDelta = new Vector2(health / maxHealth, healthBarImage.rectTransform.sizeDelta.y);
        }

    }


}
