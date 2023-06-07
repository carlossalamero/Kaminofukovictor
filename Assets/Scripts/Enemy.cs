using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 4.5f;    
    private int directionZ = -1;
    private Rigidbody rigiBody;
    public bool isAlive = true;
    private CharacterController Enemycontroller;
    //private GameManager gameManager;


     void Awake()
    {
        rigiBody = GetComponent<Rigidbody>();
        
        Enemycontroller = GetComponent<CharacterController>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

     void FixedUpdate()
    {
        if(isAlive)
        {

            rigiBody.velocity = new Vector3(rigiBody.velocity.x, rigiBody.velocity.y , directionZ * speed);

        }else
        {

            rigiBody.velocity = Vector3.zero;

        }
        
        
    }

     void OnTriggerEnter(Collider collider)
     {
         
        if(collider.gameObject.CompareTag("Enemigo") && directionZ == -1){

            directionZ = 1;
            transform.rotation = Quaternion.Euler(0,-90,0);
                  
        }else if(collider.gameObject.CompareTag("Enemigo") && directionZ == 1){


            directionZ = -1;
            transform.rotation = Quaternion.Euler(0,90,0);

        }
     }
    void OnCollisionEnter(Collision hit)
    {

        if(hit.gameObject.tag == "Player")
                {
                    
                  Destroy(hit.gameObject);
                  
                }




    }
}
