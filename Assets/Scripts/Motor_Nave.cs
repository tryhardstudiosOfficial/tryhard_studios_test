using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor_Nave : MonoBehaviour
{
    [SerializeField]
    private float Velocidad;
    [SerializeField]
    private float range;

    [SerializeField]
    private float Descontrol_tiempo;

    private void Start()
    {
        var camara = Camera.main;
        var camara_size = (camara.orthographicSize * camara.aspect);
        range = camara_size;
        
    }
    public void Mover(int direccion)
    {
        direccion = Descontrol_tiempo > 0 ? direccion * -1 : direccion;
        var speed = direccion < 0 ? 
            transform.position.x > -range ? Velocidad * direccion : 0 
            : 
            transform.position.x < range ?
            Velocidad * direccion : 0;


        transform.Translate(speed*Time.deltaTime,0,0);
    }


    public void Descontrol()
    {
        Descontrol_tiempo = 10;
        StartCoroutine(Invertir());
    }

    private IEnumerator Invertir()
    {       
        while (Descontrol_tiempo > 0)
        {
            yield return null;      
            Descontrol_tiempo -= 1 * Time.deltaTime;
        }

    }
}
