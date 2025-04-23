using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 100;
    public float maxHealth = 100;


    public float currentBarLength;
    public float maxBarLength = 100;

    private float timestamp = 0.0f;

    public Transform HealthBar;
    Vector3 origScale;


    public bool hasChanged = false;
    void Start()
    {
        origScale = HealthBar.transform.localScale;
    }

    void Update()
    {
        currentBarLength = currentHealth / maxHealth;
        HealthBar.transform.LookAt(Camera.main.transform);
        Healing();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentHealth > 0)
        {
            if (collision.gameObject.CompareTag("Enemy1"))
            {
                currentHealth -= 10;
                timestamp = Time.time;
                print("Oh no Player cillided with a Enemy1");

            }
            if (collision.gameObject.CompareTag("Enemy2"))
            {
                currentHealth -= 5;
                timestamp = Time.time;
                print("Oh no Player collided with a Enemy2");

            }
            if (collision.gameObject.CompareTag("Eb"))
            {
                currentHealth -= 10;
                timestamp = Time.time;
                print("Oh no Player got shot by a Eb");

            }
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            print( "Oh no Player is dead");
        }
    }
    void Healing()
    {
        if (currentHealth < maxHealth && Time.time > (timestamp + 10.0f))
        {
            currentHealth += 2.0f;
            timestamp = Time.time;
        }
    }

   void ChangeBar()
    {
        HealthBar.transform.localScale = Vector3.Lerp(origScale, new Vector3(currentBarLength, origScale.y, origScale.z), Time.time);

        hasChanged = true;
    }
  
   
}
