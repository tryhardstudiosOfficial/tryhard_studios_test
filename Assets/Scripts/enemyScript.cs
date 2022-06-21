using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float speed;
    public float endPosY;

    public GameObject player;

    public float distanceOfPlayer;
    public float rangeOfView;
    public float reverseSpeed;
    public float reverseRange;
    public float rangoDeDisparo;

    public float deathTimer;
    public bool death;

    private Rigidbody2D rigidbody2D;
    private Collider2D collider2D;

    public GameObject projectile;

    public float timeToShoot;
    public float shootColdown;

    public AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();

        shootColdown = timeToShoot;
    }

    public void StartFloating(float endPosY)
    {
        this.endPosY = endPosY;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * Time.deltaTime * speed);

        if (transform.position.y < this.endPosY)
        {
            Destroy(gameObject);
        }

        distanceOfPlayer = Vector2.Distance(player.transform.position, rigidbody2D.position);

        if (distanceOfPlayer < rangeOfView && distanceOfPlayer > reverseRange && distanceOfPlayer > rangoDeDisparo)
        {
            Vector2 Objetivo = new Vector2(player.transform.position.x, rigidbody2D.position.y);
            Vector2 NewPosition = Vector2.MoveTowards(rigidbody2D.position, Objetivo, speed * Time.deltaTime);
            rigidbody2D.MovePosition(NewPosition);
        }
        else if (distanceOfPlayer < rangeOfView && distanceOfPlayer > reverseRange && distanceOfPlayer <= rangoDeDisparo)
        {
            //distancia para disparar
            Vector2 Objetivo = new Vector2(player.transform.position.x, transform.position.y);
            Vector2 NewPosition = Vector2.MoveTowards(rigidbody2D.position, Objetivo, 0 * Time.deltaTime);
            rigidbody2D.MovePosition(NewPosition);


        }
        else if (distanceOfPlayer < reverseRange)
        {
            Vector2 Objetivo = new Vector2(player.transform.position.x, rigidbody2D.position.y);
            Vector2 NewPosition = Vector2.MoveTowards(rigidbody2D.position, Objetivo, reverseSpeed * Time.deltaTime);
            rigidbody2D.MovePosition(NewPosition);
        }


        if (distanceOfPlayer < rangeOfView)
        {
            shootColdown -= Time.deltaTime;
            if (shootColdown < 0)
            {
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y-1);
                GameObject cross = Instantiate(projectile, newPosition, Quaternion.identity);
                shotSound.Play();
                cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 300f), ForceMode2D.Force);
                shootColdown = timeToShoot;
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, endPosY), 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeDisparo);
        Gizmos.DrawWireSphere(transform.position, rangeOfView);
        Gizmos.DrawWireSphere(transform.position, reverseRange);
    }
}
