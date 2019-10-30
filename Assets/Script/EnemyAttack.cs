using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float tempoEntreAtaques = 0.5f;     
    public int poderDeAtaque = 10;               


    Animator animator;                              
    GameObject player;                          
    PlayerHealth playerHealth;                  
    EnemyHealth enemyHealth;                  
    bool jogadorEmAlcance;                         
    float cronometro;                                


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            jogadorEmAlcance = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            jogadorEmAlcance = false;
        }
    }


    void Update ()
    {
        cronometro += Time.deltaTime;

        if(cronometro >= tempoEntreAtaques && jogadorEmAlcance && enemyHealth.vidaAtual > 0)
        {
            Attack ();
        }

        if(playerHealth.vidaAtual <= 0)
        {
            animator.SetTrigger ("JogadorMorre");
        }
    }


    void Attack ()
    {
        cronometro = 0f;

        if(playerHealth.vidaAtual > 0)
        {
            playerHealth.TakeDamage (poderDeAtaque);
        }
    }
}
