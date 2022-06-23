using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Item : MonoBehaviour
{
    [SerializeField]
    private float velocidad_vertical;

   
    void Update()
    {
        transform.Translate(0, -velocidad_vertical * Time.deltaTime,0);

        
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
