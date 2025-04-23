using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 100;
    public float maximumHealth = 100;


    float currentBarLength;
    public Transform HealthBar;
    Vector3 OriganalScale;

    public Boolean MoreDamage = false;
    // Start is called before the first frame update
    void Start()
    {
        OriganalScale = HealthBar.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        currentBarLength = currentHealth / maximumHealth;
        HealthBar.transform.LookAt(Camera.main.transform);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet1")
        {
            if (MoreDamage == true)
            {
                currentHealth -= 25.0f;
                ChangeBar();
            }
            else
            {
                currentHealth -= 20.0f;
                ChangeBar();
            }
        }
        if (collision.gameObject.tag == "Bullet2")
        {
            if (MoreDamage == true)
            {
                currentHealth -= 15.0f;
                ChangeBar();
            }
            else
            {
                currentHealth -= 10.0f;
                ChangeBar();
            }
        }
        if (collision.gameObject.tag == "Bullet3")
        {
            if (MoreDamage == true)
            {
                currentHealth -= 20.0f;
                ChangeBar();
            }
            else
            {
                currentHealth -= 15.0f;
                ChangeBar();
            }
        }
        if (collision.gameObject.tag == "Bud")
        {
            currentHealth -= 20.0f;
            ChangeBar();
        }
    }
    void ChangeBar()
    {
        HealthBar.transform.localScale = Vector3.Lerp(OriganalScale, new Vector3(currentBarLength,
            OriganalScale.y, OriganalScale.z), Time.time);
    }
}
