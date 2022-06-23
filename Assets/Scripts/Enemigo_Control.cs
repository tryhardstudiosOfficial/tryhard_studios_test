using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Control : MonoBehaviour
{

  
    [SerializeField]
    private float tiempo_disparo= 2;
    [SerializeField]
    private float tiempo_pasado = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(tiempo_pasado >= tiempo_disparo)
        {
            Pool_Balas.instance.Invocar_Bala(this.transform.position);
            tiempo_pasado = 0;
        }
        tiempo_pasado += Time.deltaTime;
    }
    
   
}
