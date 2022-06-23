using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionador : MonoBehaviour
{
    public bool enemigo = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemigo) GameController.Instance.SumarPuntos();
            gameObject.SetActive(false);
    
    }
}
