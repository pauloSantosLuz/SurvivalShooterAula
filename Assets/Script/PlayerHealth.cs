using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {

    public int vidaInicial = 100;                     
    public int vidaAtual;                            
    public Slider barraDeVida;                          
    public Image imageDano;                            
    public AudioClip gritoDeMorte;                          
    public float velocideFlash = 5f;                           
    public Color corFlash = new Color(1f, 0f, 0f, 0.1f); 


    Animator animator;                                          
    AudioSource audioJogador;                                
    PlayerMovement playerMovement;                          
    PlayerShooting playerShooting;                        
    bool estaMorto;                                            
    bool machucado;                                           


    void Awake ()
    {
        animator = GetComponent <Animator> ();
        audioJogador = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();

        vidaAtual = vidaInicial;
    }


    void Update ()
    {
        if(machucado)
        {
            imageDano.color = corFlash;
        }
        else
        {
            imageDano.color = Color.Lerp (imageDano.color, Color.clear, velocideFlash * Time.deltaTime);
        }

        machucado = false;
    }


    public void TakeDamage (int amount)
    {
        machucado = true;

        vidaAtual -= amount;

        barraDeVida.value = vidaAtual;

        audioJogador.Play ();

        if(vidaAtual <= 0 && !estaMorto)
        {
            Death ();
        }
    }


    void Death ()
    {
        playerShooting.DisableEffects ();

        animator.SetTrigger ("Dead");

        audioJogador.clip = gritoDeMorte;
        audioJogador.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;

        estaMorto = true;
    }        
}