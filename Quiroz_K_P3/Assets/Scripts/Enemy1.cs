using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


//Enemy guards waypoints when distance >10 from player
//distance < 2 from player, punches/or/collides for attacks




public class Enemy1 : MonoBehaviour
{
    public enum Behaviors { Idle, Guard, Combat, Flee };
    //for navmesh (waypoints)
    public List<Transform> wayPoint;
    NavMeshAgent navMeshAgent;
    public int currentWayPointIndex = 0; //there is 5 way points


    public Behaviors aiBehaviors = Behaviors.Idle;

    float nextAttack = 5.0f;


    //bool ReversePath = false;
    Vector3 Destination;
    float Distance;

    public Transform Player;

    public bool isSus = false;
    public bool isInRange = false;




    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Walking();
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

         }
     }


     void ChangeBahavior(Behaviors newBehaviors)
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


    void Idle()
    {
        Destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        navMeshAgent.SetDestination(Destination);
        Distance = Vector3.Distance(gameObject.transform.position, Destination);
        if (Distance < 10.0f)
        {
            ChangeBahavior(Behaviors.Guard);
        }
    }

    void Guard()
    {
        if (isSus)
        {
            SearchForTarget();
            if (Distance < 4.00f)
            {
                isInRange = true;
                ChangeBahavior(Behaviors.Combat);
            }
        }
        else
        {
            Walking();
        }
    }

    //method for chase & attacking player PUNCHING
    void Combat()
    {
        Destination = GameObject.FindGameObjectWithTag("Player").transform.position;
        navMeshAgent.SetDestination(Destination);
        Distance = Vector3.Distance(gameObject.transform.position, Destination);
        if (isInRange)
        {
            if (2.0f >= Distance && Distance <= 4.0f)
            {
                if (Time.time >= nextAttack)
                {
                    nextAttack = Time.time + 2.0f;
                    RangedAttack();
                }
            }
          
        }
        else if (Distance > 4.0f)
        {
            isInRange = false;
            SearchForTarget();
        }
    }

    
    


    void Walking()
    {
        if (wayPoint.Count == 0) { return; }

        float distanceToWayPoint = Vector3.Distance(wayPoint[currentWayPointIndex].position, transform.position);

        if (distanceToWayPoint <= 3)
        {
            currentWayPointIndex = (currentWayPointIndex + 1) % wayPoint.Count;

        }

        navMeshAgent.SetDestination(wayPoint[currentWayPointIndex].position);

    }


    void SearchForTarget()
    {
        Destination = Player.transform.position;
        navMeshAgent.SetDestination(Destination);
        Distance = Vector3.Distance(gameObject.transform.position, Destination);

        if (Distance > 10)
        {
            //enmey >10 units from charcter -----> guard waypoints
            Walking();
        }
        else if (Distance <= 4)
        {
            //enemy <2 units from charcter -------> chase & attack
            isInRange = true;

        }
    }

    void RangedAttack()
    {

        //Should PUNCH // Collide with player
    }
}
