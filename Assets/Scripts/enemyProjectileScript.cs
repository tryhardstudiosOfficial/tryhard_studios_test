using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectileScript : MonoBehaviour
{

    public float destroyTime;
    public float destroyColdown;
    public int damage;
    public int speed;

    public GameObject player;
    public playerScript playerClass;
    public Rigidbody2D rigidbody2D;
    public float distanceOfTarget;

    public Vector3 target;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerClass = player.GetComponent<playerScript>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        destroyColdown = destroyTime;
        target = new Vector3(player.transform.position.x, player.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        destroyColdown -= Time.deltaTime;
        distanceOfTarget = Vector2.Distance(target, rigidbody2D.position);

        // rigidbody2D.velocity = (player.transform.position - transform.position).normalized * speed;

        rigidbody2D.velocity = (target - transform.position).normalized * speed;

        if(distanceOfTarget <= 0.5f){
            target = new Vector3(transform.position.x, transform.position.y-3);
            //Destroy(gameObject);
        }

            

        if (destroyColdown <= 0)
        {
            Destroy(gameObject);
            destroyColdown = destroyTime;
        }

    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(target, 0.3f);;
    }
}
