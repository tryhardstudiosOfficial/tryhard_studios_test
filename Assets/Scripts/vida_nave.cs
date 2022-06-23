using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida_nave : MonoBehaviour
{
    [SerializeField]
    private int Vida = 3;



    public void Damage(int cantidad)
    {
        Vida -= cantidad;
    } 
}
