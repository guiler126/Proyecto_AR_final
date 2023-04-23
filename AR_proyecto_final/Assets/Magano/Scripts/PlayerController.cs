using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator _animator;
    
    
    [Header("--- MOVEMENT PARAMETERS ---")]
    [Space(10)]
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private float speed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float turnSmoothTime;
    [SerializeField] private float dashTimeCooldown;
    
    [Header("--- GRAVITY PARAMETERS ---")]
    [Space(10)]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float gravity;
    [SerializeField] private float sphereRadius;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool atackkRight;
    [SerializeField] private bool isDashing;
    [SerializeField] private bool canDash;
    [SerializeField] private bool canSecondAttack;
    
    public IEnumerator currentCorroutine;



    public GameObject Spawn_bullet_1;
    public GameObject Spawn_bullet_2;
    
    
    public GameObject Spawn_bullet_SecondAttack;

    public Rigidbody Rigidbody_bullet;
    
    

    public GameObject bullet;
    public GameObject bulletSecondAttack;

    public float bulletSpeed = 50f;
    public float bullet_SecondAttackSpeed = 50f;
   
    



    private void Awake()
    {
        speed = normalSpeed;

        canDash = true;

        canSecondAttack = true;
    }

    private void Update()
    {
        Movement();
        CalculateGravity();
        ShootBasic();
        Dash();
        SecondAttack();
    }

    private void Movement()
    {
        //Guardo en estas variables las teclas WASD

        horizontal = Input.GetAxisRaw("Horizontal");
        
        vertical = Input.GetAxisRaw("Vertical");
        

        //Recogemos los valores WASD en positivo y los guardo como "direction";
        direction = new Vector3(horizontal, 0f, vertical).normalized;
        _animator.SetFloat("x", horizontal);
        _animator.SetFloat("y", vertical);
        
        //Si el jugador está en movimiento...;
        if(direction.magnitude >= 0.1f)
        {
            //Recogemos el ángulo del input entre la dirección "X" y "Z" y la proyección del angulo entre esos 2 valores lo convertimos en grados para saber hacia donde mira nuestro player;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            //Smoothea la posición actual a la posición obtenida en "targetAngle";
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, turnSmoothTime);
            //rota el personaje en el eje "Y";
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //guardamos donde rota en "Y" el player por su eje "Z" (dando así que siempre donde mire el player será al frente);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //Movemos el player hacia el frente;
            _characterController.Move(moveDir.normalized * speed * Time.deltaTime);
            
        }
        
    
        
 
    
    }
    private void CalculateGravity()
    {
        //Seteamos el bool con una esfera invisible triggered;
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        //si estamos en el suelo y no estamos cayendo el eje "Y" será "-2";
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //El eje "Y" irá progresivamente a 0;
        velocity.y += gravity * Time.deltaTime;
        
        //Movemos al personaje en el eje "Y" cada vez que saltemos;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void ShootBasic()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            atackkRight = !atackkRight;
            
            
            if (atackkRight)
            {
                _animator.SetTrigger("BasicShootRight");
            }
            else
            {
                _animator.SetTrigger("BasicShootLeft");
            }
        }
    }
    

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            currentCorroutine = CorroutineDash();
            StartCoroutine(currentCorroutine);
        }
    }

    
    
    IEnumerator CorroutineDash()
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(1f);
        speed = normalSpeed;
        canDash = false;
        yield return new WaitForSeconds(3f);
        canDash = true;
    }


    public void Spawn_Bullet_Right()
    { 
        GameObject newBullet = Instantiate(bullet, Spawn_bullet_1.transform.position, Spawn_bullet_1.transform.rotation);
        
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        
        Destroy(newBullet, 4f);
    }
    public void Spawn_Bullet_Left()
    {
        GameObject newBullet =  Instantiate(bullet, Spawn_bullet_2.transform.position, Spawn_bullet_2.transform.rotation);
        
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        
        Destroy(newBullet, 4f);
    }


    public void SecondAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _animator.SetTrigger("SecondAttack");
        }
    }

    public void SpawnSecondAttack()
    {
        GameObject newBulletSecondAttack =  Instantiate(bulletSecondAttack, Spawn_bullet_SecondAttack.transform.position, Spawn_bullet_SecondAttack.transform.rotation);
        
        newBulletSecondAttack.GetComponent<Rigidbody>().AddForce(transform.forward * bullet_SecondAttackSpeed, ForceMode.Impulse);
        
        Destroy(newBulletSecondAttack, 2f);
    }

}
