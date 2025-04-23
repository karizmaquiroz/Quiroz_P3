using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


//enmey is idle distance >=10 from player. 

//shoots distance less than <4 from player
//shoots two bullets





public class Enemy2 : MonoBehaviour
{

    public enum Behaviors { Idle, Guard, Combat, Flee };
    public Behaviors aiBehaviors = Behaviors.Idle;

    //once in range enemy punches

    //for navmesh (waypoints)
    public List<Transform> wayPoint;
    NavMeshAgent navMeshAgent;
    public int currentWayPointIndex = 0; //there is 5 way points
    Vector3 Destination;
    float Distance;


    float attackAgain = 5.0f;
    public Transform Player;
    public GameObject EnemyBullet;

    public bool isSus = false;
    public bool isInRange = false;
    bool ReversePath = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
       
        SearchForTarget();
        RunBehaviors();

    }
    void RunBehaviors()
    {
        switch (aiBehaviors)
        {
            case Behaviors.Idle:
                RunIdleNode();
                break;
            case Behaviors.Guard:
                RunGuardNode();
                break;
            case Behaviors.Combat:
                RunCombatNode();
                break;
            case Behaviors.Flee:
                RunFleeNode();
                break;
        }
    }

    void ChangeBehavior(Behaviors newBehaviors)
    {
        aiBehaviors = newBehaviors;
        RunBehaviors();
    }

    void RunIdleNode()
    {
        Idle();
    }

    void RunGuardNode()
    {
        Guard();
    }
    void RunCombatNode()
    {
        Combat();
    }
    void RunFleeNode()
    {
        Flee();
    }

    void Idle()
    {
        Destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        navMeshAgent.SetDestination(Destination);
        Distance = Vector3.Distance(gameObject.transform.position, Destination);
        if (Distance < 20.0f)
        {
            ChangeBehavior(Behaviors.Guard);
        }
    }

    void Guard()
    {
        if (isSus)
        {
            SearchForTarget();
            if (Distance < 5.00f)
            {
                isInRange = true;
                ChangeBehavior(Behaviors.Combat);
            }
        }
        else
        {
            Patrol();
        }
    }

    void Combat()
    {
        Destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        navMeshAgent.SetDestination(Destination);
        Distance = Vector3.Distance(gameObject.transform.position, Destination);
        if (isInRange)
        {
            if (2.0f >= Distance && Distance <= 5.0f)
            {
                if (Time.time >= attackAgain)
                {
                    attackAgain = Time.time + 2.0f;
                    RangedAttack();
                }
            }
          
        }
        else if (Distance > 5.0f)
        {
            isInRange = false;
            SearchForTarget();
        }
    }

    void Flee()
    {
        for (int fleePoint = 0; fleePoint < wayPoint.Count; fleePoint++)
        {
            Distance = Vector3.Distance(gameObject.transform.position, wayPoint[fleePoint].position);
            if (Distance > 10.00f)
            {
                Destination = wayPoint[currentWayPointIndex].position;
                navMeshAgent.SetDestination(Destination);
                break;
            }
            else if (Distance < 2.00f)
            {
                ChangeBehavior(Behaviors.Idle);
            }
        }
    }




    void SearchForTarget()
    {
        Destination = Player.transform.position;

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
    void Patrol()
    {

        Destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        navMeshAgent.SetDestination(Destination);
        Distance = Vector3.Distance(gameObject.transform.position, Destination);
        
        if (Distance > 2.00f)
        {
            Destination = wayPoint[currentWayPointIndex].position;
            navMeshAgent.SetDestination(Destination);
        }
        else
        {
            if (ReversePath)
            {
                if (currentWayPointIndex <= 0)
                {
                    ReversePath = false;
                }
                else
                {
                    currentWayPointIndex--;
                    Destination = wayPoint[currentWayPointIndex].position;
                }
            }
            else
            {
                if (currentWayPointIndex >= wayPoint.Count - 1)
                {
                    ReversePath = true;
                }
                else
                {
                    currentWayPointIndex++;
                    Destination = wayPoint[currentWayPointIndex].position;
                }
            }
        }
        if (Distance < 10.0f)
        {
            isSus = true;
        }
        else
        {
            isSus = false;
        }
        if (Distance > 20.0f)
        {
            ChangeBehavior(Behaviors.Idle);
        }
        
    }

    void RangedAttack()
    {

        //Should PUNCH / Collide with player

        // currently can shoot at player
        GameObject newProjectile;
        newProjectile = Instantiate(EnemyBullet, transform.position, Quaternion.identity) as GameObject;
        newProjectile.GetComponent<Rigidbody>().linearVelocity = 5.0f * transform.forward * 0.5f;
        Destroy(newProjectile, 5);

    }


}
