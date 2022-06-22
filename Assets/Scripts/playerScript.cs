using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class playerScript : MonoBehaviour
{
    public Camera mainCamera;
    //public GameObject playerCanvas;

    public int vidas;
    public int maxVidas;
    //public BarScript healthBar;

    public GameManager gameManager;
    public Rigidbody2D rigidbody2D;

    private Animator animator;
    private SpriteRenderer spriteR;

    public float defaultSpeed;
    public float speed;

    public GameObject projectile;
    public int municion;
    public int maxMunicion;
    //
    public GameObject lastProjectile;
    public bool throwingWeapon = false;
    public bool canThrowWeapon = false;
    public float seconds;
    public float tick;
    private Collider2D collider2d;

    public AudioSource ShotSound;
    public AudioSource PowerSound;

    public Text vidasText;
    public Text municionText;
    public GameObject sinMunicionText;

    public float recargaDuracion;
    public bool recargando;
    public Text contadorRecarga;

    public Text PowerText;
    public float ShowPowerTextCount;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        //playerCanvas = transform.Find("playerCanvas").gameObject;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();

        playerStart();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime * tick; // multiply time between fixed update by tick

        if (gameManager.start == true && gameManager.gameOver == false)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && municion > 0)
            {
                municion--;
                municionText.text = "municion: " + municion;
                ShotSound.Play();
                throwingWeapon = true;
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + 1);
                GameObject cross = Instantiate(projectile, newPosition, Quaternion.identity);
                //cross.GetComponent<playerWeaponProjectileScript>().player = this;


                Physics2D.IgnoreCollision(cross.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                //cross.SetActive(true);
                cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500f), ForceMode2D.Force);
                lastProjectile = cross;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && municion <= 0 && !recargando)
            {
                sinMunicionText.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.R) && municion <= 0 && !recargando)
            {
                recargaDuracion = 3;
                sinMunicionText.SetActive(false);
                recargando = true;
            }

            if (recargaDuracion > 0)
            {
                contadorRecarga.text = "recargando: " + (int)recargaDuracion;
                recargaDuracion -= Time.deltaTime;
            }

            if (recargaDuracion <= 0 && recargando)
            {
                recargando = false;
                contadorRecarga.text = "";
                municion = maxMunicion;
                municionText.text = "municion: " + maxMunicion;
            }



            if (vidas <= 0)
            {
                gameManager.gameOver = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
                //transform.localScale = new Vector3(1, 1, 1);
                //animator.SetBool("isRunning", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
                //transform.localScale = new Vector3(-1, 1, 1);
                //animator.SetBool("isRunning", true);
            }
            else
            {
                //detenerse cuando termina de caminar
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                // animator.SetBool("isRunning", false);
                //animator.SetBool("DodgeRoll", false);
            }


        }

        if (gameManager.gameOver == true)
        {
            //animator.SetBool("isRunning", false);
            //animator.SetBool("isDeath", true);
            //deathAudio.enabled = true;
        }

        if(ShowPowerTextCount > 0 ){
            ShowPowerTextCount -= Time.deltaTime;
            PowerText.gameObject.SetActive(true);
        } else {
            PowerText.gameObject.SetActive(false);
        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Power")
        {

            powerScript.PowerType powerType = collision.gameObject.GetComponent<powerScript>().powerType;
            
            switch (powerType)
            {
                default:
                case powerScript.PowerType.Limpiador: gameManager.killAllEnemies();
                    break;
                case powerScript.PowerType.Curador: heal(1);
                    break;
                case powerScript.PowerType.Invencibilidad: Invencibilidad();
                    break;
                case powerScript.PowerType.Descontrol: Descontrol();
                    break;
                case powerScript.PowerType.Aniquilador: takeDamage(2);
                    break;
            }

            print ("se uso: " + powerType.ToString()); 
            ShowPowerTextCount = 3;
            PowerText.text = "Power: " + powerType.ToString();   
            PowerSound.Play();
            Destroy(collision.gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        vidas = vidas - damage;
        vidasText.text = "vidas: " + vidas;
    }


    public void heal(int vida)
    {
        vidas = vidas+vida;
        vidasText.text = "vidas: " + vidas;
    }

    public void Invencibilidad(){
        Debug.Log("Invencible");
    }

    public void Descontrol(){
        Debug.Log("descontrol");
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void playerStart()
    {
        speed = defaultSpeed;
        municion = maxMunicion;
        vidas = maxVidas;
        municionText.text = "municion: " + maxMunicion;
        vidasText.text = "vidas: " + maxVidas;
    }
}
