using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidad;
    public int limite = -10;
    Rigidbody2D rb;
    Vector2 movimiento;
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        movimiento = new Vector2(0, -1);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
        if (transform.position.y < limite)
        {
            Destroy(gameObject);
        }
    }
}
