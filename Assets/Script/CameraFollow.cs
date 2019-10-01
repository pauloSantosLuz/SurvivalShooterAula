using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform alvo;            
    public float suavidade = 5f;        

    Vector3 distanciaPadrao;                     

    void Start ()
    {
        
        distanciaPadrao = transform.position - alvo.position;
    }

    void FixedUpdate ()
    {
        
        Vector3 targetCamPos = alvo.position + distanciaPadrao;

        
        transform.position = Vector3.Lerp (transform.position, targetCamPos, suavidade * Time.deltaTime);
    }
}
