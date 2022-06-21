using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{

    public float destroyTime;
    public float destroyColdown;
    public int damage;

    public float speed;

    private Rigidbody2D rigidbody2D;


    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("player");
    }

    void Start()
    {
        destroyColdown = destroyTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyColdown > 0)
        {
            destroyColdown -= Time.deltaTime;
        }
        destroyColdown -= Time.deltaTime;

        if (destroyColdown <= 0 && this.gameObject.activeSelf)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Debug.Log("colision with tag: " + collision.gameObject.tag.ToString());
            Destroy(gameObject);
        }
    }

}
