using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator _animator;

    [Header("--- MOVEMENT PARAMETERS ---")]
    [Space(10)]
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] public float speed;
    [SerializeField] private float normalSpeed;
    [SerializeField] public float dashSpeed;
    [SerializeField] private float SecondaryAttackSpeed;
    [SerializeField] private float turnSmoothTime;

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
    [SerializeField] public bool canDash;

    public IEnumerator currentCorroutine;

    [Space]
    [Header("---- Sapwns Attacks ----")]
    public GameObject Spawn_bullet_1;
    public GameObject Spawn_bullet_2;
    public GameObject Spawn_bullet_SecondAttack;
    
    [Space]
    [Header("---- Prefabs Attacks ----")]
    public GameObject bullet;
    public GameObject bullet_2;
    public GameObject bulletSecondAttack;

    [Space]
    [Header("---- CONFIG ATTACKS ----")]
    public float bulletSpeed = 50f;
    public float bullet_SecondAttackSpeed = 10f;
    public bool canUseSecundaryAttack;
    public float timeBetweenSecondaryAttack;
    public float currentTimeLastSecundaryAttack;
    [FormerlySerializedAs("puedo_atacar")] public bool tengo_mana;

    public bool imAttacking;

    [Space]
    [Header("---- STATS PLAYER ----")]
    public float health = 10;
    public bool isDie;

    public CapsuleCollider _Capsule;

    [Space]
    [Header("---- Object Pooling ----")]
    // Canviar per nom bullet que toqui
    public PoolingItemsEnum bullet_1_op;
    public PoolingItemsEnum bullet_2_op;
    public PoolingItemsEnum bulletSecondAttack_op;
    
    [Space]
    [Header("---- Json Local ----")]
    public Player_Data player_data_localRequest;

    private void Awake()
    {
        instance = this;
        
        speed = normalSpeed;

        canDash = true;

        canUseSecundaryAttack = true;
        
        
        isDie = false;

        imAttacking = false;

        tengo_mana = true;

    }

    private void Update()
    {
        if (!isDie)
        {
            Movement();
            NoMana();
            ShootBasic();
            SecondAttack();
            Dash();
            GodMode();
            CalculateGravity();
        }
         
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
        if (isGrounded)
        {
            velocity.y = -2f;
        } else
        {
            velocity.y -= gravity * -7f * Time.deltaTime;
        }

        //Movemos al personaje en el eje "Y" cada vez que saltemos;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void ShootBasic()
    {
        if (tengo_mana)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (imAttacking) return;
                    
                atackkRight = !atackkRight;
            
                
                if (atackkRight)
                {
                    _animator.SetBool("BasicShootLeft", false);
                    _animator.SetBool("BasicShootRight", true);
                    _animator.SetBool("imAttacking", true);
                    imAttacking = true;
                }
                else
                {
                    _animator.SetBool("BasicShootRight", false);
                    _animator.SetBool("BasicShootLeft", true);
                    _animator.SetBool("imAttacking", true);
                    imAttacking = true;
                }
            }
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            currentCorroutine = CorroutineDash();
            StartCoroutine(currentCorroutine);
            
            // Aina: Sistema Missions
            Mission_Dash.instance.DeductMissionMaxUses();
            // Aina: Sistema Logros
            Sistema_Logros.instance.AddADash_Achievement();
            // Aina: Json Local
            ++player_data_localRequest.dashUsedTimes;
        }
    }

    IEnumerator CorroutineDash()
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(0.5f);
        speed = normalSpeed;
        canDash = false;
        yield return new WaitForSeconds(3f);
        canDash = true;
    }

    public void Spawn_Bullet_Right()
    { 
        //GameObject newBullet = Instantiate(bullet, Spawn_bullet_1.transform.position, Spawn_bullet_1.transform.rotation);
        GameObject newBullet = PoolingManager.Instance.GetPooledObject((int)bullet_1_op);
        newBullet.transform.position = Spawn_bullet_1.transform.position;
        newBullet.transform.rotation = Spawn_bullet_1.transform.rotation;
        newBullet.SetActive(true);
        
        //newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        
        Mana_Controller.instance.Slider_Mana.value -= 10f;
        
        // No destruir, es fa en el script de la bala
        //Destroy(newBullet, 2f);
        
        // Aina: Sistema Missions
        Mission_Habilitat1.instance.DeductMissionMaxUses();
        Mission_Mana.instance.CheckFailedManaMission(Mana_Controller.instance.Slider_Mana.value);
        // Aina: Sistema Logros
        Sistema_Logros.instance.AddAttack1_Achievement();
        // Aina: Json Local
        ++player_data_localRequest.attack1UsedTimes;
    }
    
    public void Spawn_Bullet_Left()
    {
        //GameObject newBullet =  Instantiate(bullet_2, Spawn_bullet_2.transform.position, Spawn_bullet_2.transform.rotation);
        GameObject newBullet = PoolingManager.Instance.GetPooledObject((int)bullet_2_op);
        newBullet.transform.position = Spawn_bullet_2.transform.position;
        newBullet.transform.rotation = Spawn_bullet_2.transform.rotation;
        newBullet.SetActive(true);

        //newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        
        Mana_Controller.instance.Slider_Mana.value -= 10f;
        
        //Destroy(newBullet, 4f);
        
        // Aina: Sistema Missions
        Mission_Habilitat1.instance.DeductMissionMaxUses();
        Mission_Mana.instance.CheckFailedManaMission(Mana_Controller.instance.Slider_Mana.value);
        // Aina: Sistema Logros
        Sistema_Logros.instance.AddAttack1_Achievement();
        // Aina: Json Local
        ++player_data_localRequest.attack1UsedTimes;
    }
    
    public void SecondAttack()
    {
        if (tengo_mana)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (canUseSecundaryAttack)
                {
                    _animator.SetBool("SecondAttack", true);
                    imAttacking = true;
                    speed = SecondaryAttackSpeed;
                    canUseSecundaryAttack = false;
                    StartCoroutine(ReloadSecondaryAttack());
                }
                else
                {
                    _animator.SetBool("SecondAttack", false);  
                }
            }
        }
    }


    private IEnumerator ReloadSecondaryAttack()
    {
        currentTimeLastSecundaryAttack = 0;
        
        while (!canUseSecundaryAttack)
        {
            currentTimeLastSecundaryAttack += Time.deltaTime;

            if (currentTimeLastSecundaryAttack >= timeBetweenSecondaryAttack)
            {
                canUseSecundaryAttack = true;
            }

            yield return null;
        }
        
    }

    public void SpawnSecondAttack()
    {
        //GameObject newBulletSecondAttack =  Instantiate(bulletSecondAttack, Spawn_bullet_SecondAttack.transform.position, Spawn_bullet_SecondAttack.transform.rotation);
        GameObject newBulletSecondAttack = PoolingManager.Instance.GetPooledObject((int)bulletSecondAttack_op);
        newBulletSecondAttack.transform.position = Spawn_bullet_SecondAttack.transform.position;
        newBulletSecondAttack.transform.rotation = Spawn_bullet_SecondAttack.transform.rotation;
        newBulletSecondAttack.SetActive(true);

        newBulletSecondAttack.GetComponent<Rigidbody>().AddForce(transform.forward * bullet_SecondAttackSpeed, ForceMode.Impulse);

        speed = normalSpeed;
        
        Mana_Controller.instance.Slider_Mana.value -= 30f;
        
        //Destroy(newBulletSecondAttack, 2f);
        
        // Aina: Sistema Missions
        Mission_Habilitat2.instance.DeductMissionMaxUses();
        Mission_Mana.instance.CheckFailedManaMission(Mana_Controller.instance.Slider_Mana.value);
        // Aina: Sistema Logros
        Sistema_Logros.instance.AddAttack2_Achievement();
        // Aina: Json Local
        ++player_data_localRequest.attack2UsedTimes;
    }

    public void TakeDamage(float damage)
    {
        health-= damage;
        Ui_Manager.instance.slider_health.value = health;
        Debug.Log(Ui_Manager.instance.slider_health.value);
        
        // Aina: Json Local
        player_data_localRequest.damageTaken += damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _animator.SetTrigger("Die");
        Ui_Manager.instance.LoseCondition();        
        isDie = true;

        if (isDie == true)
        {
            LookAtMouse.instance.enabled = false;
        }
        else
        {
            isDie = false;
            LookAtMouse.instance.enabled = true;
        }
    }

    public void FinishAtttack()
    {
        imAttacking = false;
        _animator.SetBool("imAttacking", false);
        _animator.SetBool("BasicShootRight", false);
        _animator.SetBool("BasicShootLeft", false);
        _animator.SetBool("SecondAttack", false);
    }
    
    public void NoMana()
    {
        if (Mana_Controller.instance.Slider_Mana.value <= 1)
        {
            tengo_mana = false;
        }
        
        if (Mana_Controller.instance.Slider_Mana.value >= 18f)
        {
            tengo_mana = true;
        }

    }

    public void GodMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Arma.Instance.damage_enemy = 0;
        }
    }
}
