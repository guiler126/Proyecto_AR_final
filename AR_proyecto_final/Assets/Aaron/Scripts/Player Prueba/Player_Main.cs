using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Main : MonoBehaviour
{
    [Header("--- Player Components ---")]
    [SerializeField] private Transform feetTransform;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private LayerMask floormask;
    [SerializeField] public Slider Health_bar;


    [Header("--- Player Attributes ---")]
    [SerializeField] private float speed;
    [SerializeField] private float Initialspeed;
    [SerializeField] public int runspeed;
    [SerializeField] private float rotationspeed;
    [SerializeField] private float jumpforce;
    [SerializeField] public int HP = 100;
    
    public Camera playerCamera;

    private Vector3 playermovementInput;
    private float horizontalinput;

    public static Player_Main instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        speed = Initialspeed;
    }
    private void Update()
    {
        //Healthbar.value = HP;

        playermovementInput = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        horizontalinput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * (rotationspeed * horizontalinput * Time.deltaTime));
        //animator.SetFloat("Velx", horizontalinput);
        //animator.SetFloat("Vely", playermovementInput.z);

        MovePlayer();

        


        //ANIMACION CORRER
        if (Input.GetKey(KeyCode.P))
        {
            speed = runspeed;
          
        }
        else
        {
            speed = Initialspeed;
        }

        
    }

    

    public void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playermovementInput) * speed;
        rigidbody.velocity = new Vector3(moveVector.x, rigidbody.velocity.y, moveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.CheckSphere(feetTransform.position, 0.1f, floormask))
            {
                rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
                GetComponent<Animator>().SetTrigger("Jump");
            }
        }
    }

    /**public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        Health_bar.value = HP;
        if (HP <= 0)
        {
            Debug.Log("Estoy muerto");
            
        }
    }*/
}
