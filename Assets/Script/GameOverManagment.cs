using UnityEngine;

public class GameOverManagment : MonoBehaviour
{
    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;         


    Animator animator;                          
    float restartTimer;                     


    void Awake ()
    {
        
        animator = GetComponent <Animator> ();
    }


    void Update ()
    {
        
        if(playerHealth.vidaAtual <= 0)
        {
            animator.SetTrigger ("GameOver");

            restartTimer += Time.deltaTime;

            if(restartTimer >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
