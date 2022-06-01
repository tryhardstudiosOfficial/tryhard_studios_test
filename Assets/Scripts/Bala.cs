using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    public float daño;
    public int limite = 20;
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
        if (transform.position.y > limite)
        {
            gameObject.transform.position= new Vector2(20, 20);
            transform.Translate(Vector2.up * 0 * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemigo")
        {
            col.gameObject.GetComponent<VidaEnemigo>().RecibirDaño(daño);
            gameObject.transform.position = new Vector2(20, 20);
            transform.Translate(Vector2.up * 0 * Time.deltaTime);
        }
    }
}

