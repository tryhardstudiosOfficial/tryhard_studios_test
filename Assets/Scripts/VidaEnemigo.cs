using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float vidas = 3;
    
    public void RecibirDaño(float daño)
    {
        vidas -= daño;
        if (vidas <= 0)
        {
            Destroy(gameObject);
        }
    }
}
