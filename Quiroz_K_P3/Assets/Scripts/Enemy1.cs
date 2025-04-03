using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;


public class Enemy1 : MonoBehaviour
{
    //for navmesh (waypoints)
    public List<Transform> wayPoint;
    NavMeshAgent navMeshAgent;
    public int currentWayPointIndex = 0; //there is 5 way points


    //public enum Behaviors {Idle, Guard,Combat, Flee};
    //public Behaviors aiBehaviors = Behaviors.Idle;

    bool ReversePath = false;
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
        Walking();
        SearchForTarget();

    }


    /* void RunBehaviors()
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


     void CHangeBahavior(Behaviors newBehaviors)
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
         if (FightRange)
         {
             RangedAttack();
         }
         else { return; }
     }
     void RunFleeNode()
     {
         Flee();
     }

     void Idle()
     {

     }
    */


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

    //method for chase & attacking player PUNCHING
    void Combat()
    {
        //chase player

        RangedAttack();
    }

    //flee should be called when enemy health is below <=25 
    //currently health not set

    /*
void Flee()
{
    for (int fleePoint = 0; fleePoint < wayPoint.Count; fleePoint++)
    {
        Distance = Vector3.Distance(gameObject.transform.position, wayPoint[fleePoint].position);

        if(Distance > 10.00f)
        {
            Destination = wayPoint[currentWayPointIndex].position;
            navMeshAgent.SetDestination(Destination);
            break;
        }

    }
}
*/


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
        else if (Distance <= 2)
        {
            //enemy <2 units from charcter -------> chase & attack
            Combat();

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
