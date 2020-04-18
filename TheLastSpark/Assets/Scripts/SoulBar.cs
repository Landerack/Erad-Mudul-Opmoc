using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulBar : MonoBehaviour
{
    public float soulHealth = 100.0f;
    public float maxHealth = 100.0f;
    public AnimationCurve Playfull = new AnimationCurve();
    public CharacterController2D controller; 

    public Image animatedHealth;
    public Image healthBarImage = null;
    private float whiteFlashTimer = 0.01f;

    public float incomeDmg = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D))) {
            if (controller.GetComponent<PlayerMovement>().run == false) { // for some reason the true and false are reversed? but that's how they work. no time to fix
                DecreaseHealth(3*incomeDmg*Time.deltaTime);
            }
            else if (controller.GetComponent<PlayerMovement>().run == true)// for some reason the true and false are reversed? but that's how they work. no time to fix
            {
                DecreaseHealth(incomeDmg * Time.deltaTime);
            }
        }
        else
        {
            IncreaseHealth(3 * incomeDmg * Time.deltaTime);
        }


        animatedHealth.rectTransform.sizeDelta = Vector2.Lerp(animatedHealth.rectTransform.sizeDelta, healthBarImage.rectTransform.sizeDelta, 0.01f);

        whiteFlashTimer += Time.deltaTime;

        float curvePosition = Playfull.Evaluate(whiteFlashTimer);
        float scaleFactor = curvePosition * 0.2f + 1.0f;
        GetComponent<RectTransform>().localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        


    }

    void DecreaseHealth(float amount) {
        float newHealth = soulHealth - amount;
        if (newHealth < 0.0f) {
            newHealth = 0.0f;
        }
        soulHealth = newHealth;
        whiteFlashTimer = 0.0f;

        if (healthBarImage != null)
        {
            healthBarImage.rectTransform.sizeDelta = new Vector2(soulHealth / maxHealth, healthBarImage.rectTransform.sizeDelta.y);
        }
    }
    void IncreaseHealth(float amount)
    {
        float newHealth = soulHealth + amount;
        if (newHealth > 100.0f)
        {
            newHealth = 100.0f;
        }
        soulHealth = newHealth;
        whiteFlashTimer = 0.0f;

        if (healthBarImage != null)
        {
            healthBarImage.rectTransform.sizeDelta = new Vector2(soulHealth / maxHealth, healthBarImage.rectTransform.sizeDelta.y);
        }
    }


}
