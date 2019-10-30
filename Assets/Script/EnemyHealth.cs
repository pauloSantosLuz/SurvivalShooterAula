using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int vidaInicial = 100;            
    public int vidaAtual;                   
    public float velocidadeDeAfundamento = 2.5f;              
    public int valorNaPontuacao = 10;                 
    public AudioClip clipeDeMorte;                 


    Animator animator;                              
    AudioSource audioDoInimigo;                     
    ParticleSystem particulasDePancada;                
    CapsuleCollider capsuleCollider;            
    bool estaMorto;                                
    bool estaAfundando;                             


    void Awake ()
    {
        animator = GetComponent <Animator> ();
        audioDoInimigo = GetComponent <AudioSource> ();
        particulasDePancada = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        vidaAtual = vidaInicial;
    }

    void Update ()
    {
        if(estaAfundando)
        {
            transform.Translate (-Vector3.up * velocidadeDeAfundamento * Time.deltaTime);
        }
    }


    public void TakeDamage (int quantidade, Vector3 pontoDePancada)
    {
        if(estaMorto)
            return;

        audioDoInimigo.Play ();

        vidaAtual -= quantidade;

        particulasDePancada.transform.position = pontoDePancada;

        particulasDePancada.Play();

        if(vidaAtual <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        estaMorto = true;

        capsuleCollider.isTrigger = true;

        animator.SetTrigger ("Morte");

        audioDoInimigo.clip = clipeDeMorte;
        audioDoInimigo.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;

        GetComponent <Rigidbody> ().isKinematic = true;

        estaAfundando = true;

        ScoreManager.placar += valorNaPontuacao;

        Destroy (gameObject, 2f);
    }
}
