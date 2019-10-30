using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;      
    public GameObject inimigo;               
    public float tempoDeRespawn = 3f;           
    public Transform[] pontosDeRespawn;        


    void Start ()
    {
        InvokeRepeating ("Spawn", tempoDeRespawn, tempoDeRespawn);
    }


    void Spawn ()
    {
        if(playerHealth.vidaAtual <= 0f)
        {
            return;
        }

        int indexDePontosDeSpawn = Random.Range (0, pontosDeRespawn.Length);

        Instantiate (inimigo, pontosDeRespawn[indexDePontosDeSpawn].position, pontosDeRespawn[indexDePontosDeSpawn].rotation);
    }
}

