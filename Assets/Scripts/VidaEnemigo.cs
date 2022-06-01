using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float vidas = 1;

    public GameObject score;

    public void RecibirDaño(float daño)
    {
        vidas -= daño;
        if (vidas <= 0)
        {
            score.GetComponent<Score>().puntuacion += 1;
            
            Destroy(gameObject);   
        }
    }
}
