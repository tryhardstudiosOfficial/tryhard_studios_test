using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class playerScript : MonoBehaviour
{
    public Camera mainCamera;
    //public GameObject playerCanvas;

    public int maxHealth = 100;
    public int currentHealth;
    //public BarScript healthBar;

    public GameManager gameManager;
    public Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteR;
    public float defaultSpeed;
    public float speed;
    public GameObject projectile;
    //
    public GameObject lastProjectile;
    public bool throwingWeapon = false;
    public bool canThrowWeapon = false;
    public float seconds;
    public float tick;
    private Collider2D collider2d;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        speed = defaultSpeed;
        //playerCanvas = transform.Find("playerCanvas").gameObject;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime * tick; // multiply time between fixed update by tick

        if (gameManager.start == true && gameManager.gameOver == false)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                throwingWeapon = true;
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + 1);
                GameObject cross = Instantiate(projectile, newPosition, Quaternion.identity);
                //cross.GetComponent<playerWeaponProjectileScript>().player = this;


                Physics2D.IgnoreCollision(cross.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                //cross.SetActive(true);
                cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500f), ForceMode2D.Force);
                lastProjectile = cross;
            }

            if (currentHealth <= 0)
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
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //Physics2D.IgnoreLayerCollision(7, 10, true);
            //takeDamage(3,collision.gameObject.GetComponent<enemy>().lookingRight);
        }
    }

    public void takeDamage(int damage, bool directionOfHit)
    {
        /*if ((currentHealth - damage) > 0)
        { 
            if (directionOfHit){
                rigidbody2D.AddForce(new Vector2(200, 50));
            } else {
                rigidbody2D.AddForce(new Vector2(-200, 50));
            }
            inmune = true;
            inmuneCountDown = 2;
            gameManager.inmune.SetActive(true);

            audioS.enabled = true;
            currentHealth -= damage;
            healthBar.SetValue(currentHealth);
        }
        else if ((currentHealth - damage) <= 0)
        {
            currentHealth = 0;
            healthBar.SetValue(0);
        }
*/
    }


    public void heal(int hp)
    {
        /*currentHealth += hp;
        healthBar.SetValue(currentHealth);*/
    }

    /*public void getVelocity()
    {
        Debug.Log("velocidad * 2");
        defaultRunSpeed = defaultRunSpeed * 2;
        runSpeed = defaultRunSpeed;
    }*/

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
