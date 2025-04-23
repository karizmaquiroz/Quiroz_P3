using System;
using UnityEngine;


//attache the script to camera or player
public class ProjectileScript : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public float speed = 5f;
    public Transform bulletSpawnPoint;



    float velocity = 50f;


    public Boolean Bullet1 = false;
    public Boolean Bullet2 = false;
    public Boolean Bullet3 = false;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {

       
        GameObject instantiatedProjectile;
        if (Bullet1 == true)
        {
            instantiatedProjectile = Instantiate(bullet1, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;
            instantiatedProjectile.GetComponent<Rigidbody>().linearVelocity = velocity * transform.forward * 0.5f;
        }
        if (Bullet2 == true)
        {
            instantiatedProjectile = Instantiate(bullet2, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;
            instantiatedProjectile.GetComponent<Rigidbody>().linearVelocity = velocity * transform.forward * 0.5f;
        }
        if (Bullet3 == true)
        {
            instantiatedProjectile = Instantiate(bullet3, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;
            instantiatedProjectile.GetComponent<Rigidbody>().linearVelocity = velocity * transform.forward * 0.5f;
        }


    }

}
