using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animatronix;

    //variables para controlar velocidad, altura de salto y gravedad
    public float speed = 5;
    public float jumpHeight = 1;
    public float gravity = -9.81f;

    //variables para el ground sensor
    public bool isGrounded;
    public Transform groundSensor;
    public float sensorRadius = 0.1f;
    public LayerMask ground;
    private Vector3 playerVelocity;

    //variables para rotacion del personaje
    private float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    //variables sonido
    //SFXManager sfxmanager; 
    //BGMManager bgmmanager;

    public GameObject[] cameras;

    //Variables Ragdoll
    private Rigidbody[] ragdollBodies;
    //private SphereCollider[] sphereCollider;
    //private CapsuleCollider[] capsuleCollider;
    //private bool isRagdoll = false;


    
    // Start is called before the first frame update
    void Start()
    {
        //Asignamos el character controller a su variable
        controller = GetComponent<CharacterController>();

        //Asignamos el animator a su variable
        animatronix = GetComponentInChildren<Animator>();

        //Asignamos el SFXManager a su variable

        //sfxmanager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        //bgmmanager = GameObject.Find("BGMManager").GetComponent<BGMManager>();

        //Con esto podemos esconder el icono del raton para que no moleste
        Cursor.lockState = CursorLockMode.Locked;

        //ragdollBodies = GetComponentsInChildren<Rigidbody>();
        //sphereCollider = GetComponentsInChildren<SphereCollider>();
        //capsuleCollider = GetComponentsInChildren<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        /*if(!isRagdoll)
        {*/
        
        MovementTPS();
        Jump(); 

    }

    void MovementTPS()
    {
        float x = Input.GetAxisRaw("Horizontal");        
        animatronix.SetFloat("VelX", x);
        Vector3 move = new Vector3(0, 0, -Input.GetAxisRaw("Horizontal"));

        if(move != Vector3.zero)
        {
            //bgmmanager.StopBGM();
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }

    void Jump()
    {
        
        isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, ground);
        animatronix.SetBool("Jump", !isGrounded);
        //bgmmanager.StopBGM();

        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        //si estamos en el suelo y pulasamos el imput de salto hacemos que salte el personaje
        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); 
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
        {

            if(other.gameObject.layer == 6)
            {

                 Destroy(this);
                 SceneManager.LoadScene(2);


            }

            



        }

    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.layer == 7)
            {

                 Destroy(this);
                 SceneManager.LoadScene(2);


            }


    }


    
}
