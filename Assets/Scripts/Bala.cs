using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    public float daño;
    public int limite = 10;
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
        if (transform.position.y > limite)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemigo")
        {
            col.gameObject.GetComponent<VidaEnemigo>().RecibirDaño(daño);
            gameObject.SetActive(false);
        }
    }
}

