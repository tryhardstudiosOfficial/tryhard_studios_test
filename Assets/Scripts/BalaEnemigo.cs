using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velocidad;
    public float daño;
    public int limite = -10;
    void FixedUpdate()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
        if (transform.position.y < limite)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            col.gameObject.GetComponent<VidaJugador>().RecibirDaño(daño);
            gameObject.SetActive(false);
        }
    }	
}

