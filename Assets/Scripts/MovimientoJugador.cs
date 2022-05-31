using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad;
    Rigidbody2D rb;
    Vector2 movimiento;

    public GameObject score;
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (score.GetComponent<Score>().win)
        {
            gameObject.SetActive(false);
        }
        movimiento = new Vector2(Input.GetAxis("Horizontal"), 0);
    }

    void FixedUpdate()
    {
        transform.Translate(movimiento * velocidad * Time.deltaTime);

        Vector2 posicionLimite = transform.position;
        posicionLimite.x = Mathf.Clamp(posicionLimite.x, -9f, 9f);
    }
}
