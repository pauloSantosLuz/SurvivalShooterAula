using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int danoPorTiro = 20;                 
    public float tempoEntreTiros = 0.15f;       
    public float alcance = 100f;                     

    float cronometro;                                   
    Ray raioDeTiro;                                  
    RaycastHit pancadaDoTiro;                           
    int mascaraDeTiro;                             
    ParticleSystem particulaDaArma;                   
    LineRenderer linhaDoTiro;                          
    AudioSource somDaArma;                          
    Light luzDaArma;                                
    float tempoDeEfeitosDeDisplay = 0.2f;               

    void Awake ()
    {
        mascaraDeTiro = LayerMask.GetMask ("Shootable");

        particulaDaArma = GetComponent<ParticleSystem> ();
        linhaDoTiro = GetComponent <LineRenderer> ();
        somDaArma = GetComponent<AudioSource> ();
        luzDaArma = GetComponent<Light> ();
    }

    void Update ()
    {
        cronometro += Time.deltaTime;

        if(Input.GetButton ("Fire1") && cronometro >= tempoEntreTiros)
        {
            Shoot ();
        }

        if(cronometro >= tempoEntreTiros * tempoDeEfeitosDeDisplay)
        {
            DisableEffects ();
        }
    }

    public void DisableEffects ()
    {
        linhaDoTiro.enabled = false;
        luzDaArma.enabled = false;
    }

    void Shoot ()
    {
        cronometro = 0f;

        somDaArma.Play ();

        luzDaArma.enabled = true;

        particulaDaArma.Stop ();
        particulaDaArma.Play ();

        linhaDoTiro.enabled = true;
        linhaDoTiro.SetPosition (0, transform.position);

        raioDeTiro.origin = transform.position;
        raioDeTiro.direction = transform.forward;

        if(Physics.Raycast (raioDeTiro, out pancadaDoTiro, alcance, mascaraDeTiro))
        {
            EnemyHealth enemyHealth = pancadaDoTiro.collider.GetComponent <EnemyHealth> ();

            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (danoPorTiro, pancadaDoTiro.point);
            }

            linhaDoTiro.SetPosition (1, pancadaDoTiro.point);
        }
        else
        {
            linhaDoTiro.SetPosition (1, raioDeTiro.origin + raioDeTiro.direction * alcance);
        }
    }
}