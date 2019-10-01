using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;            

    Vector3 movimento;                   
    Animator animator;                      
    Rigidbody playerRigidbody;          
    int floorMask;                      
    float distanciaRaioCamera = 100f;          

   	public Camera cam;


    void Awake ()
    {
        
        floorMask = LayerMask.GetMask ("Floor");


        animator = GetComponent <Animator> ();
        playerRigidbody = GetComponent <Rigidbody> ();
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    void FixedUpdate ()
    {

        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");


        Movimenta (h, v);


        Gira ();


        Anima (h, v);
    }

    void Movimenta (float h, float v)
    {

        movimento.Set (h, 0f, v);
        

        movimento = movimento.normalized * speed * Time.deltaTime;


        playerRigidbody.MovePosition (transform.position + movimento);
    }

    void Gira ()
    {

        Ray camRay = cam.ScreenPointToRay (Input.mousePosition);


        RaycastHit tocaChao;


        if(Physics.Raycast (camRay, out tocaChao, distanciaRaioCamera, floorMask))
        {

            Vector3 playerToMouse = tocaChao.point - transform.position;


            playerToMouse.y = 0f;


            Quaternion novaRotacao = Quaternion.LookRotation (playerToMouse);


            playerRigidbody.MoveRotation (novaRotacao);
        }
    }

    void Anima (float h, float v)
    {

        bool anda = h != 0f || v != 0f;


        animator.SetBool ("IsWalking", anda);
    }
}

