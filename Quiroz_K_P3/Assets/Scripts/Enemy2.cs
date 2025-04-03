using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    //once in range enemy punches

    //for navmesh (waypoints)
    public Transform wayPoint;
    NavMeshAgent navMeshAgent;
    public int currentWayPointIndex = 0; //there is 5 way points



    Vector3 Destination;
    float Distance;

    public Transform Player;

    //public bool isSus = false;
    //public bool isInRange = false;

    public GameObject EnemyBullet;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Walking();
        //SearchForTarget();

    }




    void SearchForTarget()
    {
        Destination = Player.transform.position;
        navMeshAgent.SetDestination(Destination);
        Distance = Vector3.Distance(gameObject.transform.position, Destination);


        if (Distance <= 10)
        {
            navMeshAgent.SetDestination(Destination);
        }
        else if (Distance < 5)
        {
            //enemy <2 units from charcter -------> chase & attack
            RangedAttack();

        }



    }

    void RangedAttack()
    {

        //Should PUNCH / Collide with player


        // currently can shoot at player
        GameObject newProjectile;
        newProjectile = Instantiate(EnemyBullet, transform.position, Quaternion.identity) as GameObject;
        //
    }


}
