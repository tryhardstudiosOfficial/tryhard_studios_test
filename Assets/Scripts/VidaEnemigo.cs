using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float vidas = 1;

    public GameObject score;

    void Update() {
        if (score.GetComponent<Score>().win)
        {
            gameObject.SetActive(false);
        }
    }
    
    public void RecibirDaño(float daño)
    {
        vidas -= daño;
        if (vidas <= 0)
        {
            score.GetComponent<Score>().puntuacion += 1;
            if (score.GetComponent<Score>().puntuacion >= 10)
            {
                score.GetComponent<Score>().win = true;
            }
            Destroy(gameObject);   
        }
    }
}
