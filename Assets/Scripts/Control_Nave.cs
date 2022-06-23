using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Control_Nave : MonoBehaviour
{
    [SerializeField]
    private KeyCode[] Botones = { KeyCode.A, KeyCode.D, KeyCode.Space };

    private delegate void Mover(int i);
    private Mover accion_mover;
    private delegate void Disparar();
    private Disparar accion_disparar;

    [SerializeField]
    private Motor_Nave motor;
    [SerializeField]
    private Arma_Nave Arma;
    [SerializeField]
    private vida_nave vida;
    private void OnEnable()
    {
        accion_mover += motor.Mover;
        accion_disparar += Arma.Disparar;
    }
    private void OnDisable()
    {
        accion_mover -= motor.Mover;
        accion_disparar -= Arma.Disparar;
    }

    private void Update()
    {
        if (Input.GetKey(Botones[0])) accion_mover?.Invoke(-1) ;
        if (Input.GetKey(Botones[1])) accion_mover?.Invoke(1);

        if (Input.GetKey(Botones[2])) accion_disparar?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("enemigo"))
        {
            vida.Damage(1);
        }
    }

    public Motor_Nave get_nave (){ return motor; }
    public Arma_Nave get_arma() { return Arma; }
    public vida_nave get_vida() { return vida; }
}
