using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad;
    Score score;
    Rigidbody2D rb;
    Vector2 movimiento;
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        score = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score.win)
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
