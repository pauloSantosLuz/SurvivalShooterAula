using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    Transform player;               
    PlayerHealth playerHealth;      
    EnemyHealth enemyHealth;        
	NavMeshAgent nav;               


    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent>();
    }


    void Update ()
    {
        
        if(enemyHealth.vidaAtual > 0 && playerHealth.vidaAtual > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination (player.position);
        }
        
        else
        {
        
            nav.enabled = false;
        }
    } 
}